#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 3x3 rotation & scale matrix.
    /// </summary>
    public struct BasisElement : ITypedElement<Basis>
    {
        /* Public properties. */
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Basis Value
        {
            get
            {
                return new Basis(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2],
                    (FloatElement)Element.Children[3],
                    (FloatElement)Element.Children[4],
                    (FloatElement)Element.Children[5],
                    (FloatElement)Element.Children[6],
                    (FloatElement)Element.Children[7],
                    (FloatElement)Element.Children[8]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.X.ToString();
                Element.Children[1].InnerText = value.X.Y.ToString();
                Element.Children[2].InnerText = value.X.Z.ToString();
                Element.Children[3].InnerText = value.Y.X.ToString();
                Element.Children[4].InnerText = value.Y.Y.ToString();
                Element.Children[5].InnerText = value.Y.Z.ToString();
                Element.Children[6].InnerText = value.Z.X.ToString();
                Element.Children[7].InnerText = value.Z.Y.ToString();
                Element.Children[8].InnerText = value.Z.Z.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator BasisElement(Element element)
        {
            return new BasisElement() { Element = element };
        }

        public static implicit operator Element(BasisElement element)
        {
            return element.Element;
        }

        public static implicit operator Basis(BasisElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public override string ToString()
        {
            return ((Basis)this).ToString();
        }

        /// <summary>
        /// Generate a Basis XML element.
        /// </summary>
        public static BasisElement Generate(string name, Basis value)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("xx", value.X.X));
            element.AddChild(FloatElement.Generate("xy", value.X.Y));
            element.AddChild(FloatElement.Generate("xz", value.X.Z));
            element.AddChild(FloatElement.Generate("yx", value.Y.X));
            element.AddChild(FloatElement.Generate("yy", value.Y.Y));
            element.AddChild(FloatElement.Generate("yz", value.Y.Z));
            element.AddChild(FloatElement.Generate("zx", value.Z.X));
            element.AddChild(FloatElement.Generate("zy", value.Z.Y));
            element.AddChild(FloatElement.Generate("zz", value.Z.Z));
            return (BasisElement)element;
        }
    }
}
#endif