using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for quaternions.
    /// </summary>
    public struct QuaternionElement : ITypedElement<Quaternion>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Quaternion Value
        {
            get
            {
                return new Quaternion(
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

        public static implicit operator QuaternionElement(Element element)
        {
            return new QuaternionElement() { Element = element };
        }

        public static implicit operator Element(QuaternionElement element)
        {
            return element.Element;
        }

        public static implicit operator Quaternion(QuaternionElement element)
        {
            return element.Value;
        }

        public static QuaternionElement Generate(string name, Quaternion value)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("x", value.X));
            element.AddChild(FloatElement.Generate("y", value.Y));
            element.AddChild(FloatElement.Generate("z", value.Z));
            element.AddChild(FloatElement.Generate("w", value.W));
            return (QuaternionElement)element;
        }
    }
}