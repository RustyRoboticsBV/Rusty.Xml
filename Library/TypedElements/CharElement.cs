using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for text characters.
    /// </summary>
    public struct CharElement : ITypedElement<char>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public char Value
        {
            get => Convert.ToChar(Element.InnerText);
            set => Element.InnerText = value.ToString();
        }

        public static implicit operator CharElement(Element element)
        {
            return new CharElement() { Element = element };
        }

        public static implicit operator Element(CharElement element)
        {
            return element.Element;
        }

        public static implicit operator char(CharElement element)
        {
            return element.Value;
        }

        public static CharElement Generate(string name, char value)
        {
            Element element = new Element(name);
            CharElement charElement = element;
            charElement.Value = value;
            return charElement;
        }
    }
}