#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for floating-point vectors with two elements.
    /// </summary>
    public struct Vector2Element : TypedElement<Vector2>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Vector2 Value
        {
            get
            {
                return new Vector2(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.ToString();
                Element.Children[1].InnerText = value.Y.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Vector2Element(Element element)
        {
            return new Vector2Element() { Element = element };
        }

        public static implicit operator Element(Vector2Element element)
        {
            return element.Element;
        }

        public static implicit operator Vector2(Vector2Element element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Vector2)this).ToString();
        }

        /// <summary>
        /// Generate a Vector2 XML element.
        /// </summary>
        public static Vector2Element Generate(string name, Vector2 value)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("x", value.X));
            element.AddChild(FloatElement.Generate("y", value.Y));
            return (Vector2Element)element;
        }
    }
}
#endif