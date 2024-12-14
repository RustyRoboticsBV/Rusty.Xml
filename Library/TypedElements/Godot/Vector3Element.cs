#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for floating-point vectors with three elements.
    /// </summary>
    public struct Vector3Element : ITypedElement<Vector3>
    {
        /* Public properties. */
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Vector3 Value
        {
            get
            {
                return new Vector3(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.ToString();
                Element.Children[1].InnerText = value.Y.ToString();
                Element.Children[2].InnerText = value.Z.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Vector3Element(Element element)
        {
            return new Vector3Element() { Element = element };
        }

        public static implicit operator Element(Vector3Element element)
        {
            return element.Element;
        }

        public static implicit operator Vector3(Vector3Element element)
        {
            return element.Value;
        }

        /* Public methods. */
        public override string ToString()
        {
            return ((Vector3)this).ToString();
        }

        /// <summary>
        /// Generate a Vector3 XML element.
        /// </summary>
        public static Vector3Element Generate(string name, Vector3 value)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("x", value.X));
            element.AddChild(FloatElement.Generate("y", value.Y));
            element.AddChild(FloatElement.Generate("z", value.Z));
            return (Vector3Element)element;
        }
    }
}
#endif