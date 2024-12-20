#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 3D, floating-point, axis-aligned bounding-boxes.
    /// </summary>
    public struct AabbElement : TypedElement<Aabb>
    {
        /* Public properties. */
        public Element Element { get; set; }
        public string Name => Element.Name;
        public Aabb Value
        {
            get
            {
                return new Aabb(
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
                Element.Children[0].InnerText = value.Position.X.ToString();
                Element.Children[1].InnerText = value.Position.Y.ToString();
                Element.Children[2].InnerText = value.Position.Z.ToString();
                Element.Children[3].InnerText = value.Size.X.ToString();
                Element.Children[4].InnerText = value.Size.Y.ToString();
                Element.Children[5].InnerText = value.Size.Z.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator AabbElement(Element element)
        {
            return new AabbElement() { Element = element };
        }

        public static implicit operator Element(AabbElement element)
        {
            return element.Element;
        }

        public static implicit operator Aabb(AabbElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public readonly override string ToString()
        {
            return ((Aabb)this).ToString();
        }

        /// <summary>
        /// Generate an Aabb XML element.
        /// </summary>
        public static AabbElement Generate(string name, Aabb value)
        {
            Element element = new Element(name, "");
            element.AddChild(FloatElement.Generate("x", value.Position.X));
            element.AddChild(FloatElement.Generate("y", value.Position.Y));
            element.AddChild(FloatElement.Generate("z", value.Position.Z));
            element.AddChild(FloatElement.Generate("w", value.Size.X));
            element.AddChild(FloatElement.Generate("h", value.Size.Y));
            element.AddChild(FloatElement.Generate("d", value.Size.Z));
            return (AabbElement)element;
        }
    }
}
#endif