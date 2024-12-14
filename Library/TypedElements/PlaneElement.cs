using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for planes.
    /// </summary>
    public struct PlaneElement : ITypedElement<Plane>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Plane Value
        {
            get
            {
                return new Plane(
                    new Vector3(
                        (FloatElement)Element.Children[0],
                        (FloatElement)Element.Children[1],
                        (FloatElement)Element.Children[2]
                    ),
                    (FloatElement)Element.Children[3]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.Normal.X.ToString();
                Element.Children[1].InnerText = value.Normal.Y.ToString();
                Element.Children[2].InnerText = value.Normal.Z.ToString();
                Element.Children[3].InnerText = value.D.ToString();
            }
        }

        public static implicit operator PlaneElement(Element element)
        {
            return new PlaneElement() { Element = element };
        }

        public static implicit operator Element(PlaneElement element)
        {
            return element.Element;
        }

        public static implicit operator Plane(PlaneElement element)
        {
            return element.Value;
        }

        public static PlaneElement Generate(string name, Plane value)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("x", value.Normal.X));
            element.AddChild(FloatElement.Generate("y", value.Normal.Y));
            element.AddChild(FloatElement.Generate("z", value.Normal.Z));
            element.AddChild(FloatElement.Generate("d", value.D));
            return (PlaneElement)element;
        }
    }
}