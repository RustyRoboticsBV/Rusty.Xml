#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 2D transform matrix.
    /// </summary>
    public struct Transform2DElement : ITypedElement<Transform2D>
    {
        /* Public properties. */
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Transform2D Value
        {
            get
            {
                return new Transform2D(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2],
                    (FloatElement)Element.Children[3],
                    (FloatElement)Element.Children[4],
                    (FloatElement)Element.Children[5]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.X.ToString();
                Element.Children[1].InnerText = value.X.Y.ToString();
                Element.Children[2].InnerText = value.Y.X.ToString();
                Element.Children[3].InnerText = value.Y.Y.ToString();
                Element.Children[4].InnerText = value.Origin.X.ToString();
                Element.Children[5].InnerText = value.Origin.Y.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Transform2DElement(Element element)
        {
            return new Transform2DElement() { Element = element };
        }

        public static implicit operator Element(Transform2DElement element)
        {
            return element.Element;
        }

        public static implicit operator Transform2D(Transform2DElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Transform2D)this).ToString();
        }

        /// <summary>
        /// Generate a Transform2D XML element.
        /// </summary>
        public static Transform2DElement Generate(string name, Transform2D value)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("xx", value.X.X));
            element.AddChild(FloatElement.Generate("xy", value.X.Y));
            element.AddChild(FloatElement.Generate("yx", value.Y.X));
            element.AddChild(FloatElement.Generate("yy", value.Y.Y));
            element.AddChild(FloatElement.Generate("ox", value.Origin.X));
            element.AddChild(FloatElement.Generate("oy", value.Origin.Y));
            return (Transform2DElement)element;
        }
    }
}
#endif