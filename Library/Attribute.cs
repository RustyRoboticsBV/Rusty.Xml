#if GODOT
using Godot;
#elif UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An attribute of an XML element.
    /// </summary>
    [Serializable]
    public readonly struct Attribute
    {
        /* Fields. */
#if GODOT
        [Export] readonly string name;
        [Export] readonly string value;
#elif UNITY_5_3_OR_NEWER
        [SerializeField] readonly string name;
        [SerializeField] readonly string value;
#else
        readonly string name;
        readonly string value;
#endif

        /* Public properties. */
        /// <summary>
        /// The name of this XML attribute.
        /// </summary>
        public string Name => name;
        /// <summary>
        /// The value of this XML attribute.
        /// </summary>
        public string Value => value;

        /* Constuctors. */
        /// <summary>
        /// Create a new XML attribute.
        /// </summary>
        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        /* Public methods. */
        /// <summary>
        /// Return a copy of this XML attribute with a different name.
        /// </summary>
        public readonly Attribute Rename(string name)
        {
            return new Attribute(name, value);
        }

        /// <summary>
        /// Return a copy of this XML attribute with a different value.
        /// </summary>
        public readonly Attribute Revalue(string value)
        {
            return new Attribute(name, value);
        }
    }
}