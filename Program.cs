using XmlParser.DataProviders;
using XmlParser.Generators;
using XmlParser.Parsers;

namespace XmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputDirPath = @"C:\Users\antonio.skopin\source\repos\XmlParser\XmlParser\OutputData";
            var file = Path.Combine(@"C:\Users\antonio.skopin\source\repos\XmlParser\XmlParser\InputData\layouts", "layout_6.xml");
            var xml = File.ReadAllText(file);

            var parser = new SignatureParser(new DataProvider());
            parser.LoadXml(xml);
            parser.Parse();

            // Generate html file
            var html = parser.Generate("html");
            FileGenerator.GenerateHtmlFile(outputDirPath, html);
        }
    }
}
