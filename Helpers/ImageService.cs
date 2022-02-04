using System.Drawing;

namespace XmlParser.Helpers
{
    public class ImageService
    {
        public string ConvertImgToBase64(string imgPath)
        {
            byte[] imageArray = File.ReadAllBytes(imgPath);
            return Convert.ToBase64String(imageArray);
        }

        public dynamic ConvertBase64ToImg(string base64)
        {
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }
    }
}