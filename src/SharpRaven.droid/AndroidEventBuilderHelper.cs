using System;
using Android.Content;
using SharpRaven.Core.Data;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;

namespace SharpRaven
{
    internal class AndroidEventBuilderHelper : IEventBuilderHelper
    {
        private Context context;
        private static bool IsEmulator = CalculateIsEmulator();
        private static string  KERNEL_VERSION = CalculateKernel();

        private static string CalculateKernel()
        {
            throw new NotImplementedException();
        }

        private static bool CalculateIsEmulator()
        {
            return false;
        }

        public AndroidEventBuilderHelper(Context context)
        {
            this.context = context;
        }

        public void helpBuildingEvent(SentryEventBuilder eventBuilder)
        {
            //eventBuilder.withSdkIntegration("android");
            PackageInfo packageInfo = getPackageInfo(context);
            if (packageInfo != null)
            {
                //eventBuilder.withRelease(packageInfo.packageName + "-" + packageInfo.versionName);
                eventBuilder.SetEventDist(packageInfo.VersionCode.ToString());
            }

            String androidId = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            if (androidId != null && !androidId.Trim().Equals(""))
            {
                //SentryUser user = new SentryUser("android:" + androidId);
                // set user interface but *don't* replace if it's already there
                eventBuilder.GetEventUser().Id = androidId;
            }

            //String[] proGuardsUuids = getProGuardUuids(context);
            //if (proGuardsUuids != null && proGuardsUuids.length > 0)
            //{
            //    DebugMetaInterface debugMetaInterface = new DebugMetaInterface();
            //    for (String proGuardsUuid : proGuardsUuids)
            //    {
            //        debugMetaInterface.addDebugImage(new DebugMetaInterface.DebugImage(proGuardsUuid));
            //    }
            //    eventBuilder.withSentryInterface(debugMetaInterface);
            //}

            eventBuilder.SetEVentContext(getContexts());
        }

        private Dictionary<String, Dictionary<String, Object>> getContexts()
        {
            Dictionary<String, Dictionary<String, Object>> contexts = new Dictionary<String, Dictionary<String, Object>>();
            Dictionary <String, Object> deviceMap = new Dictionary<String, Object>();
            Dictionary<String, Object> osMap = new Dictionary<String, Object>();
            Dictionary<String, Object> appMap = new Dictionary<String, Object>();
            contexts.Add("os", osMap);
            contexts.Add("device", deviceMap);
            contexts.Add("app", appMap);

            // Device
            deviceMap.Add("manufacturer", Build.Manufacturer);
            deviceMap.Add("brand", Build.Brand);
            deviceMap.Add("model", Build.Model);
            deviceMap.Add("family", getFamily());
            deviceMap.Add("model_id", Build.Id);
            deviceMap.Add("battery_level", getBatteryLevel(context));
            deviceMap.Add("orientation", getOrientation(context));
            deviceMap.Add("simulator", IsEmulator);
            deviceMap.Add("arch", Build.CpuAbi);
            deviceMap.Add("storage_size", getTotalInternalStorage());
            deviceMap.Add("free_storage", getUnusedInternalStorage());
            deviceMap.Add("external_storage_size", getTotalExternalStorage());
            deviceMap.Add("external_free_storage", getUnusedExternalStorage());
            deviceMap.Add("charging", isCharging(context));
            deviceMap.Add("online", isConnected(context));

            DisplayMetrics displayMetrics = getDisplayMetrics(context);
            if (displayMetrics != null)
            {
                int largestSide = Math.Max(displayMetrics.WidthPixels, displayMetrics.HeightPixels);
                int smallestSide = Math.Min(displayMetrics.WidthPixels, displayMetrics.HeightPixels);
                String resolution = largestSide.ToString() + "x" + smallestSide.ToString();
                deviceMap.Add("screen_resolution", resolution);
                deviceMap.Add("screen_density", displayMetrics.Density);
                deviceMap.Add("screen_dpi", displayMetrics.DensityDpi);
            }

            ActivityManager.MemoryInfo memInfo = getMemInfo(context);
            if (memInfo != null)
            {
                deviceMap.Add("free_memory", memInfo.AvailMem);
                deviceMap.Add("memory_size", memInfo.TotalMem);
                deviceMap.Add("low_memory", memInfo.LowMemory);
            }

            // Operating System
            osMap.Add("name", "Android");
            osMap.Add("version", Build.VERSION.Release);
            osMap.Add("build", Build.Display);
            osMap.Add("kernel_version", KERNEL_VERSION);
            osMap.Add("rooted", isRooted());

            // App
            PackageInfo packageInfo = getPackageInfo(context);
            if (packageInfo != null)
            {
                appMap.Add("app_version", packageInfo.VersionName);
                appMap.Add("app_build", packageInfo.VersionCode);
                appMap.Add("app_identifier", packageInfo.PackageName);
            }

            appMap.Add("app_name", getApplicationName(context));
            //appMap.Add("app_start_time", stringifyDate(new Date()));

            return contexts;
        }

        private object getApplicationName(Context context)
        {
            throw new NotImplementedException();
        }

        private PackageInfo getPackageInfo(Context context)
        {
            throw new NotImplementedException();
        }

        private object isRooted()
        {
            throw new NotImplementedException();
        }

        private ActivityManager.MemoryInfo getMemInfo(Context context)
        {
            throw new NotImplementedException();
        }

        private DisplayMetrics getDisplayMetrics(Context context)
        {
            throw new NotImplementedException();
        }

        private object isConnected(Context context)
        {
            throw new NotImplementedException();
        }

        private object isCharging(Context context)
        {
            throw new NotImplementedException();
        }

        private object getUnusedExternalStorage()
        {
            throw new NotImplementedException();
        }

        private object getTotalExternalStorage()
        {
            throw new NotImplementedException();
        }

        private object getUnusedInternalStorage()
        {
            throw new NotImplementedException();
        }

        private object getTotalInternalStorage()
        {
            throw new NotImplementedException();
        }

        private object getOrientation(object ctx)
        {
            throw new NotImplementedException();
        }

        private object getBatteryLevel(object ctx)
        {
            throw new NotImplementedException();
        }

        private object getFamily()
        {
            throw new NotImplementedException();
        }
    }
}