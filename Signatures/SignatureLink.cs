using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureLink : BaseParserCollection
    {
        public string DataSource { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "text":
                    return new SignatureText();
                case "image":
                    return new SignatureImage();
                default:
                    return null;
            }
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
            DataSource = GetAttribute(node, "datasource");
            Value = GetAttribute(node, "href");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartLink(Value);
            base.Generate(generator);
            generator.EndLink();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            base.Parse(provider);
            this.Value = provider.GetLinkValue(DataSource, "href");
        }
    }
}