using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PluginManager.Model
{
    [XmlRoot("PluginStore")]
    public class PluginStore
    {
        public List<PluginInfo> Plugins { get; set; }

        public PluginStore() { Plugins = new List<PluginInfo>(); } 
    }

    public class PluginInfo
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }

        [XmlAttribute("AssemblyFile")]
        public string AssemblyFile { get; set; }

        [XmlAttribute("InstallPath")]
        public string InstallPath { get; set; }

        [XmlAttribute("Icon")]
        public string Icon { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
