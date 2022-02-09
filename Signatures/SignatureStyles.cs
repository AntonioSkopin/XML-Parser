using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser.Signatures
{
    public class SignatureStyles : BaseParserCollection
    {
        protected override BaseParserObject CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "style":
                    return new SignatureStyle();
                default:
                    return null;
            }
        }

        public override void Parse(XmlNode node)
        {
            base.Parse(node);
        }

        public override void Generate(ISignatureGenerator generator)
        {
            base.Generate(generator);
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            base.Parse(provider);
        }

        public SignatureStyle GetStyle(string key)
        {
            return _items.Where(s => string.Compare((s as SignatureStyle).Name, key, true) == 0).FirstOrDefault() as SignatureStyle;
        }
    }
}