using Godot;
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
        [Export] string name = "";
        [Export] List<Attribute> attributes = new List<Attribute>();
        [Export] string innerText = "";
        [Export] List<Element> children = new List<Element>();

        /* Public properties. */
        public string Name
        {
            get => name;
            set => name = value;
        }
        public List<Attribute> Attributes => attributes;
        public string InnerText
        {
            get => innerText;
            set => innerText = value;
        }
        public List<Element> Children => children;

        /* Constructors. */
        public Element(string name) : this(name, "") { }

        public Element(string name, string innerText)
        {
            this.name = name;
            attributes = new List<Attribute>();
            this.innerText = innerText;
            children = new List<Element>();
        }

        internal Element(XmlDocument doc)
        {
            foreach (XmlNode child in doc.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    FromXmlNode(child);
                    return;
                }
            }
        }

        internal Element(XmlNode node)
        {
            FromXmlNode(node);
        }

        /* Public methods. */
        public void AddChild(Element child)
        {
            children.Add(child);
        }

        public Element GetChild(string name)
        {
            foreach (Element child in Children)
            {
                if (child.Name == name)
                    return child;
            }
            return null;
        }

        public string GenerateXml()
        {
            return GenerateXml(0);
        }

        /* Private methods. */
        private void FromXmlNode(XmlNode node)
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
