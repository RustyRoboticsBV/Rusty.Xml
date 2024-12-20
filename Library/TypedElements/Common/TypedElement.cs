namespace Rusty.Xml
{
    /// <summary>
    /// An interface for XML element parsers.
    /// </summary>
    public interface TypedElement<T> : ElementContainer
    {
        /// <summary>
        /// The value of the parsed XML element.
        /// </summary>
        public T Value { get; set; }
    }
}