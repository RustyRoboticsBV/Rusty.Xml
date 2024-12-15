#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 2D, floating-point rectangles.
    /// </summary>
    public struct Rect2Element : ITypedElement<Rect2>
    {
        /* Public properties. */
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Rect2 Value
        {
            get
            {
                return new Rect2(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2],
                    (FloatElement)Element.Children[3]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.Position.X.ToString();
                Element.Children[1].InnerText = value.Position.Y.ToString();
                Element.Children[2].InnerText = value.Size.X.ToString();
                Element.Children[3].InnerText = value.Size.Y.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Rect2Element(Element element)
        {
            return new Rect2Element() { Element = element };
        }

        public static implicit operator Element(Rect2Element element)
        {
            return element.Element;
        }

        public static implicit operator Rect2(Rect2Element element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Rect2)this).ToString();
        }

        /// <summary>
        /// Generate a Rect2 XML element.
        /// </summary>
        public static Rect2Element Generate(string name, Rect2 value)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("x", value.Position.X));
            element.AddChild(FloatElement.Generate("y", value.Position.Y));
            element.AddChild(FloatElement.Generate("w", value.Size.X));
            element.AddChild(FloatElement.Generate("h", value.Size.Y));
            return (Rect2Element)element;
        }
    }
}
#endif