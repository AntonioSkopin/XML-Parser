using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureNewline : BaseParserObject
    {
        public string Selector { get; set; }

        public override void Generate(ISignatureGenerator generator)
        {
            var style = generator.Styles.GetStyle(Selector)?.ToString(Selector);
            generator.StartElement("hr", style);
            generator.EndElement();
        }

        public override void Parse(XmlNode node)
        {
            Selector = GetAttribute(node, "selector");
        }

        public override void Parse(ISignatureDataProvider provider) {}
    }
}