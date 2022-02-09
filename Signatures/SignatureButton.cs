using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureButton : BaseParserObject
    {
        public string DataSource { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public string Styles { get; set; }
        public string Selector { get; set; }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartElement("button", Styles);
            generator.InsertText(Value?.ToString());
            generator.EndElement();
        }

        public override void Parse(XmlNode node)
        {
            DataSource = GetAttribute(node, "datasource");
            FieldName = GetAttribute(node, "fieldname");
            Selector = GetAttribute(node, "selector");
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            this.Value = provider.GetValue(DataSource, FieldName).ToString();
            this.Styles = provider.GetStylesValue(Selector);
        }
    }
}
