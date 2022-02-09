using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureStyle : BaseParserObject
    {
        public string Name { get; set; }
        // Will hold all the key: value pairs for styling where => selector: styles
        public IDictionary<string, string> Properties = new Dictionary<string, string>();
        // For now supported css attributes
        public string[] KnownProperties =
        {
            "background-color",
            "font-size",
            "color",
            "height",
            "width",
            "position",
            "name"
        };

        public override void Parse(XmlNode node)
        {
            Name = GetAttribute(node, "name");
            // Fill properties dictionary with all attribute values
            GetStylesOfElement(node);
        }

        public string ToString(string selector)
        {
            return GetStylesValue(selector);
        }

        public void GetStylesOfElement(XmlNode node)
        {
            string styles = ""; // Will hold all styles of a selector
            foreach (var property in KnownProperties)
            {
                // Name will be the key of the dictionary
                // So add all other properties of element to styles
                if (property != "name" && !string.IsNullOrWhiteSpace(GetAttribute(node, property)))
                    styles += $"{property}: {GetAttribute(node, property)}; ";
                else
                {
                    // We are now at the name property which will be the key
                    if (Properties.ContainsKey(Name))
                        Properties[Name] = styles;
                    else
                        Properties.Add(Name, styles);
                }
            }
        }

        // Get value of dictionary where key is the css selector
        public string GetStylesValue(string selector)
        {
            if (Properties.ContainsKey(selector))
                return Properties[selector];
            return null;
        }

        public override void Generate(ISignatureGenerator generator) {}

        public override void Parse(DataProviders.ISignatureDataProvider provider) {}
    }
}