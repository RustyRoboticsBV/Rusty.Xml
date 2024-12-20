#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for floating-point vectors with four elements.
    /// </summary>
    public struct Vector4Element : TypedElement<Vector4>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Vector4 Value
        {
            get
            {
                return new Vector4(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2],
                    (FloatElement)Element.Children[3]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.ToString();
                Element.Children[1].InnerText = value.Y.ToString();
                Element.Children[2].InnerText = value.Z.ToString();
                Element.Children[3].InnerText = value.W.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Vector4Element(Element element)
        {
            return new Vector4Element() { Element = element };
        }

        public static implicit operator Element(Vector4Element element)
        {
            return element.Element;
        }

        public static implicit operator Vector4(Vector4Element element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Vector4)this).ToString();
        }

        /// <summary>
        /// Generate a Vector4 XML element.
        /// </summary>
        public static Vector4Element Generate(string name, Vector4 value)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("x", value.X));
            element.AddChild(FloatElement.Generate("y", value.Y));
            element.AddChild(FloatElement.Generate("z", value.Z));
            element.AddChild(FloatElement.Generate("w", value.W));
            return (Vector4Element)element;
        }
    }
}
#endif