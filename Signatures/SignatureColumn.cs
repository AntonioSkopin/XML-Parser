﻿using System.Xml;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureColumn : BaseParserCollection
    {
        public string Styles { get; set; }
        public string Selector { get; set; }

        protected override BaseParserObject CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "row":
                    return new SignatureRow();
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
                case "table":
                    return new SignatureTable();
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
            generator.StartElement("td", Styles);
            base.Generate(generator);
            generator.EndElement();
        }

        public override void Parse(DataProviders.ISignatureDataProvider provider)
        {
            base.Parse(provider);
            Styles = provider.GetStylesValue(Selector);
        }
    }
}