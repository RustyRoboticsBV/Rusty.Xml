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
    public class Attribute
    {
        /* Fields. */
#if GODOT
        [Export] string name;
        [Export] string value;
#elif UNITY_5_3_OR_NEWER
        [SerializeField] string name;
        [SerializeField] string value;
#else
        private string name;
        private string value;
#endif

        /* Public properties. */
        /// <summary>
        /// The name of this XML attribute.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// The value of this XML attribute.
        /// </summary>
        public string Value
        {
            get => value;
            set => this.value = value;
        }

        /* Constuctors. */
        /// <summary>
        /// Create a new XML attribute.
        /// </summary>
        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        /* Casting operators. */
        /// <summary>
        /// Returns the attribute's value.
        /// </summary>
        public static implicit operator string(Attribute attribute)
        {
            return attribute.value;
        }
    }
}