using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for integer vectors with two elements.
    /// </summary>
    public struct Vector3IElement : ITypedElement<Vector3I>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Vector3I Value
        {
            get
            {
                return new Vector3I(
                    (IntElement)Element.Children[0],
                    (IntElement)Element.Children[1],
                    (IntElement)Element.Children[2]
                );
            }
            set
            {
                Element.Children[0].InnerText = value.X.ToString();
                Element.Children[1].InnerText = value.Y.ToString();
                Element.Children[2].InnerText = value.Z.ToString();
            }
        }

        public static implicit operator Vector3IElement(Element element)
        {
            return new Vector3IElement() { Element = element };
        }

        public static implicit operator Element(Vector3IElement element)
        {
            return element.Element;
        }

        public static implicit operator Vector3I(Vector3IElement element)
        {
            return element.Value;
        }

        public static Vector3IElement Generate(string name, Vector3I value)
        {
            Element element = new Element(name);
            element.AddChild(IntElement.Generate("x", value.X));
            element.AddChild(IntElement.Generate("y", value.Y));
            element.AddChild(IntElement.Generate("z", value.Z));
            return (Vector3IElement)element;
        }
    }
}