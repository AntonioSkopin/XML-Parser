using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureText : BaseParserObject
    {
        public string DataSource { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }


        public override void Parse(XmlNode node)
        {
            DataSource = GetAttribute(node, "datasource");
            FieldName = GetAttribute(node, "fieldname");
            Value = node.InnerText;
        }

        public override void Generate(ISignatureGenerator generator)
        {
            // generator.StartElement("p", "");
            generator.InsertText(Value);
            // generator.EndElement();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            this.Value += provider.GetValue(DataSource, FieldName)?.ToString();
        }
    }
}