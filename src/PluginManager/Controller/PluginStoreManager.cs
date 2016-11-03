using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PluginLoader;
using System.Windows.Forms;

using PluginManager.Model;

namespace PluginManager.Controller
{
    /// <summary>
    /// Event arguments to notify about plugin store refersh progress
    /// </summary>
    public class PluginStoreRefreshProgressEventArgs : EventArgs
    {
        /// <summary>
        /// The total number of files to process
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// The current file being processed
        /// </summary>
        public int Current { get; private set; }

        /// <summary>
        /// The plugin just discovered
        /// </summary>
        public PluginInfo CurrentPlugin { get; private set; }

        /// <summary>
        /// Creates a new  instance of <see cref="PluginStorerefershProgressEventArgs"/>
        /// </summary>
        /// <param name="currentPlugin"></param>
        /// <param name="total"></param>
        /// <param name="current"></param>
        public PluginStoreRefreshProgressEventArgs(PluginInfo currentPlugin, int total, int current)
        {
            Total = total;
            Current = current;
            CurrentPlugin = currentPlugin;
        }
    }

    /// <summary>
    /// Handler delegate for plugin store refersh progress event
    /// </summary>
    /// <param name="e"></param>
    public delegate void PluginStoreRefreshHandler(PluginStoreRefreshProgressEventArgs e);

    /// <summary>
    /// Handler delegate for plugin store refersh process start event
    /// </summary>
    public delegate void PluginStoreRefreshOnStartHandler();

    /// <summary>
    /// Handler delegate for plugin store refersh completed event
    /// </summary>
    public delegate void PluginStoreRefreshOnCompleteHandler();

    /// <summary>
    /// Provide methods to refersh to refersh the Plugin Store. This class cannot be inherited
    /// </summary>
    public sealed class PluginStoreManager
    {
        /// <summary>
        /// The path to the plugin store XML file
        /// </summary>
        public static readonly string PluginStoreFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins/PluginStore.xml");

        /// <summary>
        /// The base directory to search for installed plugins
        /// </summary>
        public static readonly string PluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        private static XmlSerializer serializer = new XmlSerializer(typeof(PluginStore));

        /// <summary>
        /// Event that is fired when the plugin store is being refreshed
        /// </summary>
        public static event PluginStoreRefreshHandler OnPluginStoreRefreshProgress;

        /// <summary>
        /// Event that is fired when the plugin store refresh is starting
        /// </summary>
        public static event PluginStoreRefreshOnStartHandler OnPluginStoreRefreshStarting;

        /// <summary>
        /// Event that is fired when the plugin store refresh has completed
        /// </summary>
        public static event PluginStoreRefreshOnCompleteHandler OnPluginStoreRefreshCompleted;

        /// <summary>
        /// Notifies listeners of plugin store refresh progress
        /// </summary>
        /// <param name="e"></param>
        private static void NotifyOnPluginStoreRefreshProgress(PluginStoreRefreshProgressEventArgs e)
        {
            if (null != OnPluginStoreRefreshProgress)
                OnPluginStoreRefreshProgress(e);
        }

        /// <summary>
        /// Notifies listeners of plugin store refresh start
        /// </summary>
        private static void NotifyOnPluginStoreRefreshStarted()
        {
            if (null != OnPluginStoreRefreshStarting)
                OnPluginStoreRefreshStarting();
        }

        /// <summary>
        /// Notifies listeners of plugin store refresh end
        /// </summary>
        private static void NotifyOnPluginStoreRefreshCompleted()
        {
            if (null != OnPluginStoreRefreshCompleted)
                OnPluginStoreRefreshCompleted();
        }

        /// <summary>
        /// Loads the plugins set up in the plugin store
        /// </summary>
        /// <returns></returns>
        public static PluginStore LoadPuginStore()
        {
            if (!File.Exists(PluginStoreFile))
                return null;

            StreamReader reader = new StreamReader(PluginStoreFile);
            PluginStore pluginStore = (PluginStore)serializer.Deserialize(reader);
            reader.Close();

            return pluginStore;
        }

        /// <summary>
        /// Refreshes the plugin store
        /// </summary>
        /// <returns></returns>
        public static PluginStore RefreshPuginStore()
        {
            IconSet.Clear();
            PluginStore pluginStore = new PluginStore();

            string[] pluginDirs = Directory.GetDirectories(PluginsDirectory);
            int[] cumulativeFileCount = new int[pluginDirs.Length];
            int totalFiles = 0;
            int currentFileCount = 0;
            for (int d = 0; d < pluginDirs.Length; d++)
            {
                currentFileCount = Directory.GetFiles(pluginDirs[d]).Length;
                cumulativeFileCount[d] = currentFileCount;
                if (d > 0)
                {
                    cumulativeFileCount[d] = cumulativeFileCount[d] + cumulativeFileCount[d - 1];
                }
                totalFiles += currentFileCount;
            }
            cumulativeFileCount[0] = 0;

            // Raise start of plugin store refresh
            NotifyOnPluginStoreRefreshStarted();

            for (int d = 0; d < pluginDirs.Length; d++)
            {
                string[] files = Directory.GetFiles(pluginDirs[d]);
                LoadPluginsInDirectory(ref pluginStore, pluginDirs[d], files, totalFiles, cumulativeFileCount[d]);
            }            

            // Save the new plugin store
            XmlSerializer w = new XmlSerializer(typeof(PluginStore));
            StreamWriter storeFile = new StreamWriter(PluginStoreFile);
            w.Serialize(storeFile, pluginStore);
            storeFile.Close();

            // Raise event that refresh has been completed
            NotifyOnPluginStoreRefreshCompleted();

            return pluginStore;
        }

        /// <summary>
        /// Inspects assemblies and executables in the specified directory
        /// using reflection and searches for controls with the PluginAttribute
        /// marked against its type. Updates the plugin store with discovered
        /// plugins
        /// </summary>
        /// <param name="pluginStore"></param>
        /// <param name="directory"></param>
        /// <param name="files"></param>
        private static void LoadPluginsInDirectory(ref PluginStore pluginStore, string directory, string[] files, int totalFiles, int currentCumulate)
        {
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                // Process only dll and exe files
                if (file.EndsWith(".dll") || file.EndsWith(".exe"))
                {
                    try
                    {
                        Assembly a = Assembly.LoadFile(file);
                        Type[] types = a.GetTypes();
                        foreach (Type t in types)
                        {
                            if (t.IsSubclassOf(typeof(Control)))
                            {
                                object[] pluginAttributes = t.GetCustomAttributes(typeof(PluginAttribute), false);
                                if (null != pluginAttributes && pluginAttributes.Length > 0)
                                {
                                    PluginAttribute pluginAttribute = (PluginAttribute)pluginAttributes[0];


                                    // Check if an icon file is present
                                    string iconFile = Path.Combine(directory, t.Name + ".ico");
                                    if (!File.Exists(iconFile))
                                        iconFile = "\\Resources\\PluginManager.ico";

                                    PluginInfo currentPlugin = new PluginInfo()
                                    {
                                        Name = pluginAttribute.Name,
                                        Description = pluginAttribute.Description,
                                        Type = t.FullName,
                                        AssemblyFile = file.Replace(AppDomain.CurrentDomain.BaseDirectory, ""),
                                        InstallPath = directory.Replace(AppDomain.CurrentDomain.BaseDirectory, ""),
                                        Icon = iconFile.Replace(AppDomain.CurrentDomain.BaseDirectory, "")
                                    };

                                    pluginStore.Plugins.Add(currentPlugin);
                                    NotifyOnPluginStoreRefreshProgress(
                                        new PluginStoreRefreshProgressEventArgs(
                                            currentPlugin,
                                            totalFiles,                                            
                                            currentCumulate + i + 1
                                        )
                                    );
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
