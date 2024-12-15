using Rusty.Xml;
using System;

try
{
    string path = "../../../Test.xml";
    Document document = new Document(path);
    Element root = document.Root;
    Console.WriteLine($"Opened file: '{path}'");
    Console.WriteLine(document.GenerateXml());

    Console.WriteLine();
    Console.WriteLine("Elements:");
    Console.WriteLine("bool:\t\t" + (BoolElement)root.GetChild("bool"));
    Console.WriteLine("int:\t\t" + (IntElement)root.GetChild("int"));
    Console.WriteLine("float:\t\t" + (FloatElement)root.GetChild("float"));
    Console.WriteLine("char:\t\t" + (CharElement)root.GetChild("char"));
    Console.WriteLine("string:\t\t" + (StringElement)root.GetChild("string"));
    Console.WriteLine("Vector2:\t" + (Vector2Element)root.GetChild("Vector2"));
    Console.WriteLine("Vector2I:\t" + (Vector3Element)root.GetChild("Vector3"));
    Console.WriteLine("Vector3:\t" + (Vector4Element)root.GetChild("Vector4"));
    Console.WriteLine("Vector3I:\t" + (Vector2IElement)root.GetChild("Vector2I"));
    Console.WriteLine("Vector3:\t" + (Vector3IElement)root.GetChild("Vector3I"));
    Console.WriteLine("Vector4I:\t" + (Vector4IElement)root.GetChild("Vector4I"));
    Console.WriteLine("Quaternion:\t" + (QuaternionElement)root.GetChild("Quaternion"));
    Console.WriteLine("Plane:\t\t" + (PlaneElement)root.GetChild("Plane"));
    Console.WriteLine("Rect2:\t\t" + (Rect2Element)root.GetChild("Rect2"));
    Console.WriteLine("Rect2I:\t\t" + (Rect2IElement)root.GetChild("Rect2I"));
    Console.WriteLine("Aabb:\t\t" + (AabbElement)root.GetChild("Aabb"));
    Console.WriteLine("Color:\t\t" + (ColorElement)root.GetChild("Color"));
    Console.WriteLine("Transform2D:\t" + (Transform2DElement)root.GetChild("Transform2D"));
    Console.WriteLine("Basis:\t\t" + (BasisElement)root.GetChild("Basis"));
    Console.WriteLine("Transform3D:\t" + (Transform3DElement)root.GetChild("Transform3D"));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}