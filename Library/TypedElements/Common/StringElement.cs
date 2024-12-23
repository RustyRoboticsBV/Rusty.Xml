namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for text strings.
    /// </summary>
    public struct StringElement : TypedElement<string>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public string Value
        {
            get => Element.InnerText;
            set => Element.InnerText = value;
        }

        /* Conversion operators. */
        public static implicit operator StringElement(Element element)
        {
            return new StringElement() { Element = element };
        }

        public static implicit operator Element(StringElement element)
        {
            return element.Element;
        }

        public static implicit operator string(StringElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((string)this).ToString();
        }

        /// <summary>
        /// Generate a string XML element.
        /// </summary>
        public static StringElement Generate(string name, string value)
        {
            Element element = new Element(name, "");
            StringElement stringElement = element;
            stringElement.Value = value;
            return stringElement;
        }
    }
}