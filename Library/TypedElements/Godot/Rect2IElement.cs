#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 2D, integer rectangles.
    /// </summary>
    public struct Rect2IElement : TypedElement<Rect2I>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Rect2I Value
        {
            get
            {
                return new Rect2I(
                    (IntElement)Element.Children[0],
                    (IntElement)Element.Children[1],
                    (IntElement)Element.Children[2],
                    (IntElement)Element.Children[3]
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
        public static implicit operator Rect2IElement(Element element)
        {
            return new Rect2IElement() { Element = element };
        }

        public static implicit operator Element(Rect2IElement element)
        {
            return element.Element;
        }

        public static implicit operator Rect2I(Rect2IElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Rect2I)this).ToString();
        }

        /// <summary>
        /// Generate a Rect2I XML element.
        /// </summary>
        public static Rect2IElement Generate(string name, Rect2I value)
        {
            Element element = new Element(name, "");
            element.AddChild(IntElement.Generate("x", value.Position.X));
            element.AddChild(IntElement.Generate("y", value.Position.Y));
            element.AddChild(IntElement.Generate("w", value.Size.X));
            element.AddChild(IntElement.Generate("h", value.Size.Y));
            return (Rect2IElement)element;
        }
    }
}
#endif