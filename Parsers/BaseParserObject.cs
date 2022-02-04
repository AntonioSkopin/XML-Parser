using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;

namespace XmlParser.Parsers
{
    public abstract class BaseParserObject
    {
        protected string GetAttribute(XmlNode node, string name)
        {
            var attr = node.Attributes[name];
            return attr == null ? string.Empty : attr.Value;
        }

        public abstract void Parse(XmlNode node);

        public abstract void Parse(ISignatureDataProvider provider);
        public abstract void Generate(ISignatureGenerator generator);
    }
}
