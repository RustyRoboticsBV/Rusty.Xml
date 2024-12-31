#if GODOT
using Godot;
using System;

#elif UNITY_5_3_OR_NEWER
using UnityEngine;
#endif

using System.IO;
using System.Xml;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML document.
    /// </summary>
    [Serializable]
    public class Document
    {
        /* Fields. */
#if GODOT
        [Export] string name;
        [Export] Element root;
#elif UNITY_5_3_OR_NEWER
        [SerializeField] string name;
        [SerializeField] Element root;
#else
        private string name;
        private Element root;
#endif

        /* Public properties. */
        /// <summary>
        /// The name of the XML document.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// The root element of this XML document.
        /// </summary>
        public Element Root
        {
            get => root;
            set => root = value;
        }

        /* Constructors. */
        /// <summary>
        /// Create a new XML document from a root XML element.
        /// </summary>
        public Document(string name, Element root)
        {
            this.name = name;
            this.root = root;
        }

        /// <summary>
        /// Create a new XML document from a string of XML code.
        /// </summary>
        public Document(string name, string xml)
        {
            this.name = name;
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            root = FindRoot(document);
        }

        /// <summary>
        /// Create an XML document object by loading it from a file.
        /// </summary>
        public Document(string filePath)
        {
            name = Path.GetFileName(filePath);
            Read(filePath);
        }

        /* Conversion operators. */
        /// <summary>
        /// Convert to an XML element by returning the document's root element.
        /// </summary>
        public static implicit operator Element(Document document)
        {
            return document.Root;
        }

        /* Public methods. */
        /// <summary>
        /// Read contents from an XML file. Deletes the current contents of the XML document object.
        /// </summary>
        public void Read(string filePath)
        {
            filePath = GetAbsolutePath(filePath);

            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            root = FindRoot(document);
        }

        /// <summary>
        /// Write an XML document to a file.
        /// </summary>
        public void Write(string filePath)
        {
            filePath = GetAbsolutePath(filePath);

            File.WriteAllText(filePath, GenerateXml());
        }

        /// <summary>
        /// Serialize this XML document.
        /// </summary>
        public string GenerateXml()
        {
            if (root != null)
                return root.GenerateXml();
            else
                return "";
        }

        /// <summary>
        /// Check if a file exists.
        /// </summary>
        public static bool Exists(string filePath)
        {
            filePath = GetAbsolutePath(filePath);

            return File.Exists(filePath);
        }

        /* Private methods. */
        /// <summary>
        /// Convert a path to an absolute path. If the path already was an absolute path, the same path is returned.
        /// </summary>
        private static string GetAbsolutePath(string path)
        {
            if (path.StartsWith("."))
                return Path.GetFullPath(path);
            else
                return path;
        }

        /// <summary>
        /// Find the root element of an System.XmlDocument.
        /// </summary>
        private static Element FindRoot(XmlDocument document)
        {
            foreach (XmlNode child in document.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                    return new Element(child);
            }
            return null;
        }
    }
}