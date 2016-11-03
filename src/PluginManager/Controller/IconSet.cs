using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace PluginManager.Controller
{
    /// <summary>
    /// A cached storage of plugin icons
    /// </summary>
    public static class IconSet
    {
        /// <summary>
        /// The simple in memory cache if icons
        /// </summary>
        private static ListDictionary Icons = new ListDictionary();

        /// <summary>
        /// Returns the icon specified by the icon file
        /// </summary>
        /// <param name="iconFile"></param>
        /// <returns></returns>
        public static Icon GetIcon(string iconFile)
        {
            // Check if its already cached
            if (null != Icons[iconFile])
                return (Icon)Icons[iconFile];

            // Load the icon file
            iconFile = EnvironmentSettings.GetFullPath(iconFile);
            if (!File.Exists(iconFile))
            {
                // If the specified icon is not found,
                // the default icon will be used
                Icons[iconFile] = Resources.PluginManager;
            }
            else
            {
                if (!Icons.Contains(iconFile))
                    Icons[iconFile] = new Icon(iconFile);
            }
            return (Icon)Icons[iconFile];
        }

        public static Icon Default
        {
            get { return Resources.PluginManager; }
        }

        public static void Clear()
        {
            Icons.Clear();
        }
    }
}
