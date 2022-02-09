using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureImage : BaseParserObject
    {
        public string DataSource { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public string Selector { get; set; }

        public override void Parse(XmlNode node)
        {
            DataSource = GetAttribute(node, "datasource");
            FieldName = GetAttribute(node, "fieldname");
            Value = GetAttribute(node, "src");
            Selector = GetAttribute(node, "selector");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            var style = generator.Styles.GetStyle(Selector)?.ToString(Selector);
            generator.StartImage(Value, style);
            generator.EndElement();
        }

        public override void Parse(ISignatureDataProvider provider) => Value = provider.GetImageValue(DataSource, "src");
    }
}