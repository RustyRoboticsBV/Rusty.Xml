using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for floating-point numbers.
    /// </summary>
    public struct FloatElement : ITypedElement<float>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public float Value
        {
            get => Convert.ToSingle(Element.InnerText);
            set => Element.InnerText = value.ToString();
        }

        public static implicit operator FloatElement(Element element)
        {
            return new FloatElement() { Element = element };
        }

        public static implicit operator Element(FloatElement element)
        {
            return element.Element;
        }

        public static implicit operator float(FloatElement element)
        {
            return element.Value;
        }

        public static FloatElement Generate(string name, float value)
        {
            Element element = new Element(name);
            FloatElement floatElement = element;
            floatElement.Value = value;
            return floatElement;
        }
    }
}