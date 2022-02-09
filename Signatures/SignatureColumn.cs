using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureColumn : BaseParserCollection
    {
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            return name.ToLower() switch
            {
                "row" => new SignatureRow(),
                "column" => new SignatureColumn(),
                "text" => new SignatureText(),
                "link" => new SignatureLink(),
                "image" => new SignatureImage(),
                "button" => new SignatureButton(),
                "newline" => new SignatureNewline(),
                "table" => new SignatureTable(),
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
            var style = generator.Styles.GetStyle(Selector)?.ToString(Selector);
            generator.StartElement("td", style);
            base.Generate(generator);
            generator.EndElement();
        }
    }
}