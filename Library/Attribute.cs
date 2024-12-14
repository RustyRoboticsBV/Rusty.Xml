using Godot;
using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An attribute of an XML element.
    /// </summary>
    [Serializable]
    public struct Attribute
    {
        /* Fields. */
        [Export] string name;
        [Export] string value;

        /* Public properties. */
        public string Name => name;
        public string Value => value;

        /* Constuctors. */
        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
