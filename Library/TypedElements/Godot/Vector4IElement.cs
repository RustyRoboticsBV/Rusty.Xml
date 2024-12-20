#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for integers vectors with four elements.
    /// </summary>
    public struct Vector4IElement : TypedElement<Vector4I>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Vector4I Value
        {
            get
            {
                return new Vector4I(
                    (IntElement)Element.Children[0],
                    (IntElement)Element.Children[1],
                    (IntElement)Element.Children[2],
                    (IntElement)Element.Children[3]
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
        public static implicit operator Vector4IElement(Element element)
        {
            return new Vector4IElement() { Element = element };
        }

        public static implicit operator Element(Vector4IElement element)
        {
            return element.Element;
        }

        public static implicit operator Vector4I(Vector4IElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Vector4I)this).ToString();
        }

        /// <summary>
        /// Generate a Vector4I XML element.
        /// </summary>
        public static Vector4IElement Generate(string name, Vector4I value)
        {
            Element element = new Element(name, "");
            element.AddChild(IntElement.Generate("x", value.X));
            element.AddChild(IntElement.Generate("y", value.Y));
            element.AddChild(IntElement.Generate("z", value.Z));
            element.AddChild(IntElement.Generate("w", value.W));
            return (Vector4IElement)element;
        }
    }
}
#endif