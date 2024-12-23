#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for integer vectors with two elements.
    /// </summary>
    public struct Vector2IElement : TypedElement<Vector2I>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Vector2I Value
        {
            get
            {
                return new Vector2I(
                    (IntElement)Element.Children[0],
                    (IntElement)Element.Children[1]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.ToString();
                Element.Children[1].InnerText = value.Y.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Vector2IElement(Element element)
        {
            return new Vector2IElement() { Element = element };
        }

        public static implicit operator Element(Vector2IElement element)
        {
            return element.Element;
        }

        public static implicit operator Vector2I(Vector2IElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Vector2I)this).ToString();
        }

        /// <summary>
        /// Generate a Vector2I XML element.
        /// </summary>
        public static Vector2IElement Generate(string name, Vector2I value)
        {
            Element element = new Element(name, "");
            element.AddChild(IntElement.Generate("x", value.X));
            element.AddChild(IntElement.Generate("y", value.Y));
            return (Vector2IElement)element;
        }
    }
}
#endif