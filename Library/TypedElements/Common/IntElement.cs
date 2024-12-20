using System;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for integer numbers.
    /// </summary>
    public struct IntElement : TypedElement<int>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public int Value
        {
            get => Convert.ToInt32(Element.InnerText);
            set => Element.InnerText = value.ToString();
        }

        /* Conversion operators. */
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

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((int)this).ToString();
        }

        /// <summary>
        /// Generate an int XML element.
        /// </summary>
        public static IntElement Generate(string name, int value)
        {
            Element element = new Element(name, "");
            IntElement intElement = element;
            intElement.Value = value;
            return intElement;
        }
    }
}