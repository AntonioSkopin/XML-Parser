using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    internal class SignatureRow : BaseParserCollection
    {
        public string Styles { get; set; }

        protected override BaseParserCollection CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "column":
                    return new SignatureColumn();
                default:
                    return null;
            }
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
            Styles = GetAttribute(node, "style");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartElement("tr", Styles);
            base.Generate(generator);
            generator.EndElement();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            base.Parse(provider);
            Styles = provider.GetStylesValue("row");
        }
    }
}