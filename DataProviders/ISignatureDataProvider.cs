namespace XmlParser.DataProviders
{
    public interface ISignatureDataProvider
    {
        object GetValue(string name, string fieldName);
        string GetLinkValue(string name, string attribute);
        string GetImageValue(string name, string attribute);
        string GetStylesValue(string selector);
    }
}
