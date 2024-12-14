using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for integer numbers.
    /// </summary>
    public struct IntElement : ITypedElement<int>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public int Value
        {
            get => Convert.ToInt32(Element.InnerText);
            set => Element.InnerText = value.ToString();
        }

        public static implicit operator IntElement(Element element)
        {
            return new IntElement() { Element = element };
        }

        public static implicit operator Element(IntElement element)
        {
            return element.Element;
        }

        public static implicit operator int(IntElement element)
        {
            return element.Value;
        }

        public static IntElement Generate(string name, int value)
        {
            Element element = new Element(name);
            IntElement intElement = element;
            intElement.Value = value;
            return intElement;
        }
    }
}