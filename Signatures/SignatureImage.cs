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
        public string Styles { get; set; }

        public override void Parse(XmlNode node)
        {
            DataSource = GetAttribute(node, "datasource");
            FieldName = GetAttribute(node, "fieldname");
            Value = GetAttribute(node, "src");
            Styles = GetAttribute(node, "style");
        }

        public override void Generate(ISignatureGenerator generator)
        {
            generator.StartImage(Value, Styles);
            generator.EndElement();
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            this.Value = provider.GetImageValue(DataSource, "src");
            this.Styles = provider.GetStylesValue("image");
        }
    }
}