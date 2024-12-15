#if GODOT
using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for 3D transform matrix.
    /// </summary>
    public struct Transform3DElement : ITypedElement<Transform3D>
    {
        /* Public properties. */
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Transform3D Value
        {
            get
            {
                return new Transform3D(
                    (FloatElement)Element.Children[0],
                    (FloatElement)Element.Children[1],
                    (FloatElement)Element.Children[2],
                    (FloatElement)Element.Children[3],
                    (FloatElement)Element.Children[4],
                    (FloatElement)Element.Children[5],
                    (FloatElement)Element.Children[6],
                    (FloatElement)Element.Children[7],
                    (FloatElement)Element.Children[8],
                    (FloatElement)Element.Children[9],
                    (FloatElement)Element.Children[10],
                    (FloatElement)Element.Children[11]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.Basis.X.X.ToString();
                Element.Children[3].InnerText = value.Basis.Y.X.ToString();
                Element.Children[6].InnerText = value.Basis.Z.X.ToString();
                Element.Children[1].InnerText = value.Basis.X.Y.ToString();
                Element.Children[4].InnerText = value.Basis.Y.Y.ToString();
                Element.Children[7].InnerText = value.Basis.Z.Y.ToString();
                Element.Children[2].InnerText = value.Basis.X.Z.ToString();
                Element.Children[5].InnerText = value.Basis.Y.Z.ToString();
                Element.Children[8].InnerText = value.Basis.Z.Z.ToString();
                Element.Children[9].InnerText = value.Origin.X.ToString();
                Element.Children[10].InnerText = value.Origin.Y.ToString();
                Element.Children[11].InnerText = value.Origin.Z.ToString();
            }
        }

        /* Conversion operators. */
        public static implicit operator Transform3DElement(Element element)
        {
            return new Transform3DElement() { Element = element };
        }

        public static implicit operator Element(Transform3DElement element)
        {
            return element.Element;
        }

        public static implicit operator Transform3D(Transform3DElement element)
        {
            return element.Value;
        }

        /* Public methods. */
        public override string ToString()
        {
            return ((Transform3D)this).ToString();
        }

        /// <summary>
        /// Generate a Transform3D XML element.
        /// </summary>
        public static Transform3DElement Generate(string name, Transform3D value)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("xx", value.Basis.X.X));
            element.AddChild(FloatElement.Generate("yx", value.Basis.Y.X));
            element.AddChild(FloatElement.Generate("zx", value.Basis.Z.X));
            element.AddChild(FloatElement.Generate("xy", value.Basis.X.Y));
            element.AddChild(FloatElement.Generate("yy", value.Basis.Y.Y));
            element.AddChild(FloatElement.Generate("zy", value.Basis.Z.Y));
            element.AddChild(FloatElement.Generate("xz", value.Basis.X.Z));
            element.AddChild(FloatElement.Generate("yz", value.Basis.Y.Z));
            element.AddChild(FloatElement.Generate("zz", value.Basis.Z.Z));
            element.AddChild(FloatElement.Generate("ox", value.Origin.X));
            element.AddChild(FloatElement.Generate("oy", value.Origin.Y));
            element.AddChild(FloatElement.Generate("oz", value.Origin.Z));
            return (Transform3DElement)element;
        }
    }
}
#endif