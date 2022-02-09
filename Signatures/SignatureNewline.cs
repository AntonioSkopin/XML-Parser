using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureNewline : BaseParserObject
    {
        public string Styles { get; set; }
        public string Selector { get; set; }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartElement("hr", Styles);
            generator.EndElement();
        }

        public override void Parse(XmlNode node)
        {
            Styles = GetAttribute(node, "style");
            Selector = GetAttribute(node, "selector");
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            Styles = provider.GetStylesValue(Selector);
        }
    }
}