using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// see https://docs.sentry.io/clientdev/interfaces/stacktrace/ for information about fields.
    /// </summary>
    public class Frame
    {
        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("lineno")]
        public int LineNumber { get; set; }

        [JsonProperty("colno")]
        public int ColumnNumber { get; set; }

        [JsonProperty("abs_path")]
        public string AbsolutePath { get; set; }

        [JsonProperty("context_line")]
        public string ContextLine { get; set; }

        [JsonProperty("pre_context")]
        public List<string> PreContext { get; set; } = new List<string>();

        [JsonProperty("post_context")]
        public List<string> PostContext { get; set; } = new List<string>();

        [JsonProperty("in_app")]
        public bool InApp { get; set; }

        [JsonProperty("vars")]
        public Dictionary<string, string> Vars { get; set; } = new Dictionary<string, string>();

        [JsonProperty("package")]
        public string Assembly { get; set; }

        [JsonProperty("platform")]
        public string PLatform { get; set; }

        [JsonProperty("img_addr")]
        public string ImageAddress { get; set; }

        [JsonProperty("instruction_addr")]
        public string InstructionAddress { get; set; }

        [JsonProperty("symbol_addr")]
        public string SymbolAddress { get; set; }

        [JsonProperty("instruction_offset")]
        public string InstructionOffset { get; set; }

        public Frame(string fileName, string function, string module)
        {
            if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(function) || string.IsNullOrWhiteSpace(module))
            {
                throw new NullReferenceException();
            }
            FileName = fileName;
            Function = function;
            Module = module;
        }
    }
}
