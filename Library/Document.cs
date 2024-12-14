using System.IO;
using System.Xml;

namespace Rusty.Xml
{
    /// <summary>
    /// Utility for reading or creating XML documents.
    /// </summary>
    public static class Document
    {
        /* Public methods. */
        /// <summary>
        /// Read an XML document and return the root node.
        /// </summary>
        public static Element Read(string filePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            return new Element(document);
        }

        /// <summary>
        /// Write an XML document to a file.
        /// </summary>
        public static void Write(Element root, string filePath)
        {
            File.WriteAllText(filePath, root.GenerateXml());
        }

        /// <summary>
        /// Check if a file exists.
        /// </summary>
        public static bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
