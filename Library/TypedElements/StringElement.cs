namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for text strings.
    /// </summary>
    public struct StringElement : ITypedElement<string>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public string Value
        {
            get => Element.InnerText;
            set => Element.InnerText = value;
        }

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

        public static StringElement Generate(string name, string value)
        {
            Element element = new Element(name);
            StringElement stringElement = element;
            stringElement.Value = value;
            return stringElement;
        }
    }
}