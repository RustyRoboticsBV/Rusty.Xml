using Godot;

namespace Rusty.Xml
{
    /// <summary>
    /// An XML element parser for RGB(A) colors.
    /// </summary>
    public struct ColorElement : ITypedElement<Color>
    {
        public Element Element { get; private set; }
        public string Name => Element.Name;
        public Color Value
        {
            get
            {
                float r = (FloatElement)Element.Children[0];
                float g = (FloatElement)Element.Children[1];
                float b = (FloatElement)Element.Children[2];
                float a = Element.Children.Count > 3 ? (FloatElement)Element.Children[3] : 1f;
                return new Color(r, g, b, a);
            }
            set
            {
                Element.Children[0].InnerText = value.R.ToString();
                Element.Children[1].InnerText = value.G.ToString();
                Element.Children[2].InnerText = value.B.ToString();
                if (Element.Children.Count > 3)
                    Element.Children[3].InnerText = value.A.ToString();
            }
        }

        public static implicit operator ColorElement(Element element)
        {
            return new ColorElement() { Element = element };
        }

        public static implicit operator Element(ColorElement element)
        {
            return element.Element;
        }

        public static implicit operator Color(ColorElement element)
        {
            return element.Value;
        }

        public static ColorElement Generate(string name, Color value, bool alpha = true)
        {
            Element element = new Element(name);
            element.AddChild(FloatElement.Generate("r", value.R));
            element.AddChild(FloatElement.Generate("g", value.G));
            element.AddChild(FloatElement.Generate("b", value.B));
            if (alpha)
                element.AddChild(FloatElement.Generate("a", value.A));
            return (ColorElement)element;
        }
    }
}