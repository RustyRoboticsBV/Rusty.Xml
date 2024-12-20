namespace Rusty.Xml
{
    /// <summary>
    /// An interface for XML element parsers.
    /// </summary>
    public interface ElementContainer
    {
        /// <summary>
        /// The XML element that this parser is based on.
        /// </summary>
        public Element Element { get; set; }
        /// <summary>
        /// The name of the parsed XML element.
        /// </summary>
        public string Name { get; }
    }
}