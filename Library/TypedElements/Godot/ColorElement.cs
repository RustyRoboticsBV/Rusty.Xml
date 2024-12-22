#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for RGB(A) colors.
    /// </summary>
    public struct ColorElement : TypedElement<Color>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Color Value
        {
            get
            {
                return Color.FromHtml(Element.InnerText);
            }
            set
            {
                Element.InnerText = value.ToHtml(value.A < 1);
            }
        }

        /* Conversion operators. */
        public static implicit operator ColorElement(Element element)
        {
            return new ColorElement() { Element = element };
        }

        public static implicit operator Element(ColorElement element)
        {
            return element.Element;
        }

        public static implicit operator Color(ColorElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Color)this).ToString();
        }

        /// <summary>
        /// Generate a color XML element.
        /// </summary>
        public static ColorElement Generate(string name, Color value, bool alpha = true)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("r", value.R));
            element.AddChild(FloatElement.Generate("g", value.G));
            element.AddChild(FloatElement.Generate("b", value.B));
            if (alpha)
                element.AddChild(FloatElement.Generate("a", value.A));
            return (ColorElement)element;
        }
    }
}
#endif