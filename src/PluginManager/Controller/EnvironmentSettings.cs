using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PluginManager.Controller
{
    public static class EnvironmentSettings
    {
        public static string GetFullPath(string path)
        {
            return AppDomain.CurrentDomain.BaseDirectory + path;
        }
    }
}
