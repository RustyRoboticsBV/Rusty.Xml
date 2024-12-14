using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for booleans.
    /// </summary>
    public struct BoolElement : ITypedElement<bool>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public bool Value
        {
            get => Convert.ToBoolean(Element.InnerText);
            set => Element.InnerText = value.ToString();
        }

        public static implicit operator BoolElement(Element element)
        {
            return new BoolElement() { Element = element };
        }

        public static implicit operator Element(BoolElement element)
        {
            return element.Element;
        }

        public static implicit operator bool(BoolElement element)
        {
            return element.Value;
        }

        public static BoolElement Generate(string name, bool value)
        {
            Element element = new Element(name);
            BoolElement boolElement = element;
            boolElement.Value = value;
            return boolElement;
        }
    }
}