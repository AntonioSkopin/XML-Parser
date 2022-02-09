using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureTable : BaseParserCollection
    {
        public string Styles { get; set; }
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "table":
                    return new SignatureTable();
                case "row":
                    return new SignatureRow();
                default:
                    return null;
            }
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
            Styles = GetAttribute(node, "style");
            Selector = GetAttribute(node, "selector");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartElement("table", Styles);
            base.Generate(generator);
            generator.EndElement();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            base.Parse(provider);
            Styles = provider.GetStylesValue(Selector);
        }
    }
}
