using System.IO;
using System.Xml;

namespace Rusty.Xml
{
    // TODO: Make non-static.
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
            filePath = GetAbsolutePath(filePath);

            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            return new Element(document);
        }

        /// <summary>
        /// Write an XML document to a file.
        /// </summary>
        public static void Write(Element root, string filePath)
        {
            filePath = GetAbsolutePath(filePath);

            File.WriteAllText(filePath, root.GenerateXml());
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
    }
}
