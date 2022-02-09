using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;

namespace XmlParser.Parsers
{
    public abstract class BaseParserCollection : BaseParserObject
    {
        protected List<BaseParserObject> _items = new List<BaseParserObject>();

        public int Count => _items.Count;

        public BaseParserObject this[int index] => _items[index];

        protected abstract BaseParserObject CreateObject(string name);

        public override void Parse(XmlNode node)
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                var obj = CreateObject(n.LocalName);
                if (obj == null)
                {
                    throw new KeyNotFoundException(n.LocalName);
                }
                obj.Parse(n);
                Add(obj);
            }
        }

        public BaseParserObject Add(BaseParserObject obj)
        {
            _items.Add(obj);
            return obj;
        }

        public override void Generate(ISignatureGenerator generator)
        {
            foreach (BaseParserObject o in _items)
            {
                o.Generate(generator);
            }
        }

        public override void Parse(ISignatureDataProvider provider)
        {
            foreach (BaseParserObject o in _items)
            {
                o.Parse(provider);
            }
        }
    }
}
