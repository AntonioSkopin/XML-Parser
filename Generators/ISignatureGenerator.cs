namespace XmlParser.Generators
{
    public interface ISignatureGenerator
    {
        void Prepare();
        void Finish();

        void StartElement(string tag, string styles = null);
        void EndElement();

        void InsertText(string text);
        void StartLink(string href);
        void EndLink();
        void StartImage(string src, string styles);

        string AsText { get; }
    }
}
