using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginLoader
{
    [global::System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PluginAttribute : Attribute
    {
        readonly string name;
        readonly string description;

        // This is a positional argument
        public PluginAttribute(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get { return name; } }
        public string Description { get { return description; } }
    }
}
