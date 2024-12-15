namespace Rusty.Xml
{
    /// <summary>
    /// An interface for XML element parsers.
    /// </summary>
    public interface ITypedElement<T>
    {
        /// <summary>
        /// The XML element that this parser is based on.
        /// </summary>
        public Element Element { get; }
        /// <summary>
        /// The name of the parsed XML element.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The value of the parsed XML element.
        /// </summary>
        public T Value { get; set; }
    }
}