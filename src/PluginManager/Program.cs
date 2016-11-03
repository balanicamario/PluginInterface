using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Citrus.Forms.PluginManager.View;
using System.Reflection;
using PluginManager.Controller;
using PluginManager.Model;
using System.IO;

namespace Citrus.Forms.PluginManager.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PluginManager());
        }

        /// <summary>
        /// The following allows the plugin manager to load external assemblies
        /// that are referenced by plugins. These plugins are assumed to be
        /// in the plugins folder, and is resolved after the CLR heuristics
        /// for loading a assembly fails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            PluginStore pluginStore = PluginStoreManager.LoadPuginStore();
            if (null == pluginStore) return null;

            int index = args.Name.IndexOf(',');
            string assemblyName;
            if (index > 0)
            {
                assemblyName = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
            }
            else
                assemblyName = args.Name + ".dll";

            foreach (PluginInfo plugin in pluginStore.Plugins)
            {
                string assemblyFile = Path.Combine(plugin.InstallPath, assemblyName);
                assemblyFile = EnvironmentSettings.GetFullPath(Path.Combine(plugin.InstallPath, assemblyName));
                if (File.Exists(assemblyFile))
                {
                    return Assembly.LoadFile(assemblyFile);
                }
            }
            return null;
        }
    }
}
