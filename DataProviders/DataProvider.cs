using XmlParser.Helpers;

namespace XmlParser.DataProviders
{
    public class DataProvider : ISignatureDataProvider
    {
        protected ImageService _imgService = new ImageService();
        protected string imgPathDir = @"C:\Users\antonio.skopin\source\repos\XmlParser\XmlParser\Assets\person.png";

        // Get value of datasource
        public object GetValue(string name, string fieldName)
        {
            switch (name.ToLower())
            {
                case "user":
                    return GetUser(fieldName);
                default:
                    return null;
            }
        }

        public string GetLinkValue(string name, string attribute)
        {
            switch (name.ToLower())
            {
                case "user":
                    return GetLink(attribute);
                default:
                    return null;
            }
        }

        public string GetImageValue(string name, string attribute)
        {
            switch (name.ToLower())
            {
                case "user":
                    return GetImage(attribute);
                default:
                    return null;
            }
        }

        public string GetStylesValue(string element)
        {
            return GetStyles(element);
        }

        // Fake user
        protected object GetUser(string fieldName)
        {
            switch (fieldName.ToLower())
            {
                case "name":
                    return "Antonio Skopin";
                case "role":
                    return "Software Engineer";
                case "phone":
                    return "+31 6 18317710";
                case "website":
                    return "skopin.nl";
                case "email":
                    return "antonio@eformity.nl";
                case "address":
                    return "Alblasserdam";
                case "btn-1":
                    return "Download on the App Store";
                case "btn-2":
                    return "Get it on Google Play";
                default:
                    return null;
            }
        }

        protected string GetLink(string attribute)
        {
            switch (attribute.ToLower())
            {
                case "href":
                    return "https://skopin.nl";
                default :
                    return null;
            }
        }

        protected string GetImage(string attribute)
        {
            switch (attribute.ToLower())
            {
                case "src":
                    //return "data:image/png;base64," + _imgService.ConvertImgToBase64(imgPathDir);
                    return "../Assets/person.png";
                default:
                    return null;
            }
        }

        protected string GetStyles(string element)
        {
            switch (element.ToLower())
            {
                case "image":
                    return "border-radius: 50%; width: 15rem;";
                case "column":
                    return "padding: 0 2.5rem;";
                case "row":
                    return "display: block; padding: 1.5rem 5rem";
                case "button":
                    return "padding: 1rem 2rem; border: none; background-color: black; color: white; border-radius: 2rem;";
                case "newline":
                    return "height: 0.25rem; visibility: hidden;";
                default:
                    return null;
            }
        }
    }
}