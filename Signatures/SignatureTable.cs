using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureTable : BaseParserCollection
    {
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            return name.ToLower() switch
            {
                "table" => new SignatureTable(),
                "row" => new SignatureRow(),
                _ => null,
            };
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
            Selector = GetAttribute(node, "selector");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            var style = generator.Styles?.GetStyle(Selector)?.ToString(Selector);
            generator.StartElement("table", style);
            base.Generate(generator);
            generator.EndElement();
        }
    }
}
