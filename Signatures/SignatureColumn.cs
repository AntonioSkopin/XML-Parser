using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureColumn : BaseParserCollection
    {
        public string Styles { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "column":
                    return new SignatureColumn();
                case "text":
                    return new SignatureText();
                case "link":
                    return new SignatureLink();
                case "image":
                    return new SignatureImage();
                case "button":
                    return new SignatureButton();
                case "newline":
                    return new SignatureNewline();
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
            generator.StartElement("td", Styles);
            base.Generate(generator);
            generator.EndElement();
        }

        public override void Parse(DataProviders.ISignatureDataProvider provider)
        {
            base.Parse(provider);
            Styles = provider.GetStylesValue("column");
        }
    }
}