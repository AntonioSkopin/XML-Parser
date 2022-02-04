namespace XmlParser.Generators
{
    public static class FileGenerator
    {
        public static void GenerateHtmlFile(string outputDirPath, string html)
        {
            GenerateOutputDirectory();
            File.WriteAllText(Path.Combine(outputDirPath, "index.html"), html);
        }

        public static void GenerateOutputDirectory()
        {
            // If directory doesn't exist create it
            string outputDirPath = @"C:\Users\antonio.skopin\source\repos\XmlParser\XmlParser\OutputData";
            if (!Directory.Exists(outputDirPath))
                Directory.CreateDirectory(outputDirPath);
        }
    }
}