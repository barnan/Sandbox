using System;

namespace ConsoleApp4
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ConfigurationAttribute : Attribute
    {
        public ConfigurationAttribute(string description, string name = null, bool loadComponent = false)
        {
            Name = name;
            Description = description;
            LoadComponent = loadComponent;
        }

        public string Name;

        public string Value;

        public string Description;

        public bool LoadComponent;
    }
}
