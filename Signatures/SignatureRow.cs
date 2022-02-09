using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    internal class SignatureRow : BaseParserCollection
    {
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            return name.ToLower() switch
            {
                "column" => new SignatureColumn(),
                "text" => new SignatureText(),
                "row" => new SignatureRow(),
                "table" => new SignatureTable(),
                "newline" => new SignatureNewline(),
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
            generator.StartElement("tr", style);
            base.Generate(generator);
            generator.EndElement();
        }
    }
}