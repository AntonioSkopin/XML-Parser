using System.Text;
using System.Web.UI;
using XmlParser.Helpers;

namespace XmlParser.Generators
{
    public class SignatureHTMLGenerator : ISignatureGenerator
    {
        protected StringWriter _stringWriter;
        protected HtmlTextWriter _htmlWriter;

        protected void SetAttribute(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _htmlWriter.AddAttribute(name, value);
            }
        }

        public string AsText => _stringWriter.ToString();

        public ISignatureStyles Styles { get; set; }

        public void StartElement(string tag, string styles)
        {
            SetAttribute("style", styles);
            _htmlWriter.RenderBeginTag(tag);
        }

        public void EndElement()
        {
            _htmlWriter.RenderEndTag();
        }

        public void StartLink(string href, string styles)
        {
            SetAttribute("href", href);
            SetAttribute("styles", styles);
            _htmlWriter.RenderBeginTag("a");
        }

        public void EndLink()
        {
            _htmlWriter.RenderEndTag();
        }

        public void Finish()
        {
            _htmlWriter.RenderEndTag(); // table
            _htmlWriter.RenderEndTag(); // body
            _htmlWriter.RenderEndTag(); // html
        }

        public void InsertText(string text)
        {
            _htmlWriter.Write(text);
        }

        public void Prepare()
        {
            _stringWriter = new StringWriterWithEncoding(Encoding.UTF8);
            _htmlWriter = new HtmlTextWriter(_stringWriter);

            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Html);
            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Head);
            _htmlWriter.AddAttribute("charset", "UTF-8");
            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Meta);
            _htmlWriter.RenderEndTag();
            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Title);
            _htmlWriter.Write("XML Parser");
            _htmlWriter.RenderEndTag();
            _htmlWriter.RenderEndTag();
            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Body);
            SetAttribute("style", "height: 50%; width: 100%");
            _htmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);
        }

        public void StartImage(string src, string styles)
        {
            SetAttribute("src", src);
            SetAttribute("style", styles);
            _htmlWriter.RenderBeginTag("img");
        }
    }
}
