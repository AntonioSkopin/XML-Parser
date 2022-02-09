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
            switch (name.ToLower())
            {
                case "column":
                    return new SignatureColumn();
                case "text":
                    return new SignatureText();
                case "row":
                    return new SignatureRow();
                case "table":
                    return new SignatureTable();
                case "newline":
                    return new SignatureNewline();
                default:
                    return null;
            }
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