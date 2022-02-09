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
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            return name.ToLower() switch
            {
                "text" => new SignatureText(),
                "image" => new SignatureImage(),
                _ => null,
            };
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
            DataSource = GetAttribute(node, "datasource");
            Value = GetAttribute(node, "href");
            Selector = GetAttribute(node, "selector");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            var style = generator.Styles?.GetStyle(Selector)?.ToString(Selector);
            generator.StartLink(Value, style);
            base.Generate(generator);
            generator.EndLink();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            base.Parse(provider);
            Value = provider.GetLinkValue(DataSource, Selector);
        }
    }
}