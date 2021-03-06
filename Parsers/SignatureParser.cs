using System.Xml;
using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Signatures;

namespace XmlParser.Parsers
{
    public class SignatureParser : BaseParserCollection, ISignatureStyles
    {
        private static Dictionary<string, Type> _generators = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        protected ISignatureDataProvider DataProvider { get; set; }

        static SignatureParser()
        {
            Register("html", typeof(SignatureHTMLGenerator));
        }

        public SignatureParser(): this(null)
        { }

        public SignatureParser(ISignatureDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }

        static public void Register(string name, Type generator)
        {
            _generators[name] = generator;
        }

        static public ISignatureGenerator? CreateGenerator(string name, ISignatureStyles styles)
        {
            Type type = _generators[name];
            if (type == null) return null;

            var result = Activator.CreateInstance(type) as ISignatureGenerator;
            if (result != null) result.Styles = styles;
            return result;
        }

        protected override BaseParserCollection? CreateObject(string name)
        {
            switch (name.ToLower())
            {
                case "row":
                    return new SignatureRow();
                case "styles":
                    return new SignatureStyles();
                default:
                    return null;
            }
        }
        public void LoadXml(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var signatureNode = doc.SelectSingleNode("signature");
            Parse(signatureNode);
        }

        public void Parse()
        {
            Parse(this.DataProvider);
        }

        public string Generate(string name)
        {
            var generator = CreateGenerator(name, this);
            if (generator == null)
            {
                throw new KeyNotFoundException(name);
            }
            generator.Prepare();
            Generate(generator);
            generator.Finish();
            return generator.AsText;
        }

        public SignatureStyle GetStyle(string key)
        {
            var styles = _items.Where(i => i is SignatureStyles).FirstOrDefault() as SignatureStyles;
            if (styles == null)
                return null;
            return styles.GetStyle(key);
        }
    }
}