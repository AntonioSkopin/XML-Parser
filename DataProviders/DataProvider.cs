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

        public string GetStylesValue(string selector)
        {
            return GetStyles(selector) ;
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
                    return "../Assets/person.jpg";
                default:
                    return null;
            }
        }

        protected string GetStyles(string selector)
        {
            switch (selector.ToLower())
            {
                case "rounded-image":
                    return "border-radius: 50%; height: max-content;";
                case "image-w100%":
                    return "width: 100%";
                case "hidden-newline":
                    return "height: 0.25rem; visibility: hidden;";
                case "w-20":
                    return "background-color: orange; width: 20%; position: relative;";
                case "w-30":
                    return "background-color: orange; width: 30%; position: relative;";
                case "w-40":
                    return "background-color: gray; width: 40%; position: relative";
                case "w-50":
                    return "background-color: blue; width: 50%; position: relative";
                case "w-60":
                    return "background-color: green; width: 60%; position: relative";
                case "w-80":
                    return "background-color: green; width: 80%; position: relative";
                case "h-10":
                    return "background-color: pink; height: 10%; width: 100%; position: relative";
                case "h-20":
                    return "background-color: pink; height: 20%; width: 100%; position: relative";
                case "h-30":
                    return "background-color: black; height: 30%; width: 100%; position: relative";
                case "h-40":
                    return "background-color: black; height: 40%; width: 100%; position: relative";
                case "h-50":
                    return "background-color: red; height: 50%; border-top: 1px solid white; width: 100%; position: relative";
                case "h-60":
                    return "background-color: purple; height: 60%; width: 100%; position: relative";
                case "h-70":
                    return "background-color: yellow; height: 70%; width: 100%; position: relative";
                case "h-80":
                    return "background-color: gold; height: 80%; position: relative;";
                default:
                    return null;
            }
        }
    }
}