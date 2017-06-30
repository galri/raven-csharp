using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

using SharpRaven.Core.Service.Models;

using Exception = SharpRaven.Core.Service.Models.Exception;
using StackTrace = SharpRaven.Core.Service.Models.StackTrace;

namespace SharpRaven.Core.Service
{
    class ExceptionFactory
    {
        public static List<Exception> Create(System.Exception ex)
        {
            if (ex == null)
                return null;

            var result = new List<Exception>
            {
                new Exception
                {
                    Assembly = ex.TargetSite?.ReflectedType?.Name,
                    Type = ex.GetType().FullName,
                    Value = ex.Message,
                    StackTrace = CreateStackTrace(ex)
                },
            };
            
            return result;
        }


        private static StackTrace CreateStackTrace(System.Exception exception)
        {
            var result = new StackTrace();
            var currentException = exception;

        
            result.Frames = CreateFrames(exception);
            return result;
        }


        private static List<Frame> CreateFrames(System.Exception exception)
        {
            var stackTrace = new System.Diagnostics.StackTrace(exception);

            var frames = stackTrace.GetFrames();

            if (frames == null)
                return null;

            var stackframes = frames.Select(GetFrames).ToList();

            return stackframes;
        }
        private static Frame GetFrames(StackFrame x)
        {
            var m = x.GetMethod();

            string asmName;
            if (m.DeclaringType != null)
            {
                var asm = m.DeclaringType.Assembly;

                var title =
                    asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).OfType<AssemblyTitleAttribute>()
                        .FirstOrDefault();

                if (title != null)
                    asmName = title.Title;
                else
                    asmName = asm.FullName;
            }
            else
                asmName = "";

            //TODO: find solution to write correct error stack when exception is thrown in  async method
            //if (m.Name == "MoveNext")
            //{
            //    //info is wrapped around async info.
            //}

            var fileName = x.GetFileName() ?? "unknown";
            var methodName = GetMethodName(m) ?? "unknown";
            var name = m.Module.Name ?? "unknown";

            var frame = new Frame(fileName, methodName, name);
            frame.ColumnNumber = x.GetFileColumnNumber();
            frame.LineNumber = x.GetFileLineNumber();
            frame.Module = asmName;

            return frame;
        }

        protected static string GetMethodName(MethodBase m)
        {
            var parameters = string.Join(", ", m.GetParameters().Select(x => x.ParameterType.Name));
            if (m.DeclaringType == null)
            {

                return $"{m.Name}({parameters})";
            }
            return
                $"{m.DeclaringType.FullName}.{m.Name}({parameters})";
        }

    }
}
