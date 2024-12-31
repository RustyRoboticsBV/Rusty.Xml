#if GODOT
using Godot;
#elif UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

using System;
using System.Collections.Generic;
using System.Xml;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element.
    /// </summary>
    [Serializable]
    public class Element
    {
        /* Fields. */
#if GODOT
        [Export] string name = "";
        [Export] List<Attribute> attributes = new List<Attribute>();
        [Export] string innerText = "";
        [Export] List<Element> children = new List<Element>();
#elif UNITY_5_3_OR_NEWER
        [SerializeField] string name = "";
        [SerializeField] List<Attribute> attributes = new List<Attribute>();
        [SerializeField] string innerText = "";
        [SerializeField] List<Element> children = new List<Element>();
#else
        private string name = "";
        private List<Attribute> attributes = new List<Attribute>();
        private string innerText = "";
        private List<Element> children = new List<Element>();
#endif

        /* Public properties. */
        /// <summary>
        /// The name of the XML element.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// The attributes of the XML element.
        /// </summary>
        public List<Attribute> Attributes => attributes;
        /// <summary>
        /// The inner text of the XML attribute.
        /// </summary>
        public string InnerText
        {
            get => innerText;
            set => innerText = value;
        }
        /// <summary>
        /// The child elements of the XML attribute.
        /// </summary>
        public List<Element> Children => children;

        /* Constructors. */
        /// <summary>
        /// Create a new XML element.
        /// </summary>
        public Element(string name, string innerText)
        {
            this.name = name;
            attributes = new List<Attribute>();
            this.innerText = innerText;
            children = new List<Element>();
        }

        /// <summary>
        /// Create a new XML element from a string of XML code.
        /// </summary>
        public Element(string xml)
        {
            Document document = new Document("", xml);
            name = document.Root.name;
            attributes = document.Root.attributes;
            innerText = document.Root.innerText;
            children = document.Root.children;
        }

        /// <summary>
        /// Create a new XML element object from a System.XmlNode.
        /// </summary>
        internal Element(XmlNode node)
        {
            name = node.Name;

            attributes = new List<Attribute>();
            foreach (XmlAttribute attribute in node.Attributes)
            {
                attributes.Add(new Attribute(attribute.Name, attribute.Value));
            }

            innerText = node.InnerText;

            children = new List<Element>();
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                    children.Add(new Element(child));
            }
        }

        /* Public methods. */
        /// <summary>
        /// Add a child element to this element. Make sure to not introduce any cycles!
        /// </summary>
        public void AddChild(Element child)
        {
            children.Add(child);
        }

        /// <summary>
        /// Get a child element by name.
        /// </summary>
        public Element GetChild(string name)
        {
            foreach (Element child in Children)
            {
                if (child.Name == name)
                    return child;
            }
            throw new KeyNotFoundException($"XML element '{Name}' has no child element with the name '{name}'.");
        }

        /// <summary>
        /// Check if this element has a child element with some name.
        /// </summary>
        public bool HasChild(string name)
        {
            foreach (Element child in Children)
            {
                if (child.Name == name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Get an attribute by name.
        /// </summary>
        public Attribute GetAttribute(string name)
        {
            foreach (Attribute attribute in Attributes)
            {
                if (attribute.Name == name)
                    return attribute;
            }
            throw new KeyNotFoundException($"XML element '{Name}' has no attribute with the name '{name}'.");
        }

        /// <summary>
        /// Check if this element has an attribute with some name.
        /// </summary>
        public bool HasAttribute(string name)
        {
            foreach (Attribute attribute in Attributes)
            {
                if (attribute.Name == name)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Serialize this XML element and all child elements.
        /// </summary>
        public string GenerateXml()
        {
            return GenerateXml(0);
        }

        /* Private methods. */
        /// <summary>
        /// Create XML text for this element, starting at some indentation level.
        /// </summary>
        private string GenerateXml(int indentLevel)
        {
            string indent = new string(' ', indentLevel);

            if (children.Count == 0 && innerText == "")
                return indent + $"<{name}/>";

            else if (children.Count == 0)
                return indent + $"<{name}>{innerText}</{name}>";

            else
            {
                string xml = indent + $"<{name}>";
                foreach (Element child in children)
                {
                    xml += "\n" + child.GenerateXml(indentLevel + 1);
                }
                xml += "\n" + indent + $"</{name}>";
                return xml;
            }
        }
    }
}