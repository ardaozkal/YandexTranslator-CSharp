using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace YandexTranslate
{
    public class YandexTranslator
    {
        WebClient downloader = new WebClient();
        private string download(string link)
        {
            downloader.Encoding = Encoding.UTF8;
            return downloader.DownloadString(link);
        }

        public string detect(string text, string apikey)
        {
            string xml = download(("https://translate.yandex.net/api/v1.5/tr/detect?key=" + apikey + "&text=" + text.Replace(" ", "+")));
            string returnvalue = "";
            string withoutlines = xml.Replace(Environment.NewLine, "");
            if (withoutlines.Length == 76)
            {
                int respondkey = int.Parse(withoutlines.Substring(59, 3));
                string respondlang = withoutlines.Substring(70, 2);
                if (respondkey == 200)
                {
                    returnvalue = respondlang;
                }
                else
                {
                    returnvalue = "Error! Code: " + respondkey;
                }
            }
            else
            {
                returnvalue = "Error! Nothing received! ";
            }
            return returnvalue;
        }

        public bool trydetect(string text, string apikey, out string output)
        {
            string xml = download(("https://translate.yandex.net/api/v1.5/tr/detect?key=" + apikey + "&text=" + text.Replace(" ", "+")));
            bool returnvalue = false;
            string withoutlines = xml.Replace(Environment.NewLine, "");
            if (withoutlines.Length == 76)
            {
                int respondkey = int.Parse(withoutlines.Substring(59, 3));
                string respondlang = withoutlines.Substring(70, 2);
                if (respondkey == 200)
                {
                    output = respondlang;
                    returnvalue = true;
                }
                else
                {
                    output = "";
                    returnvalue = false;
                }
            }
            else
            {
                output = "";
                returnvalue = false;
            }
            return returnvalue;
        }

        public bool trydetect(string text, string apikey, out string output, out int key)
        {
            string xml = download(("https://translate.yandex.net/api/v1.5/tr/detect?key=" + apikey + "&text=" + text.Replace(" ", "+")));
            bool returnvalue = false;
            string withoutlines = xml.Replace(Environment.NewLine, "");
            if (withoutlines.Length == 76)
            {
                int respondkey = int.Parse(withoutlines.Substring(59, 3));
                string respondlang = withoutlines.Substring(70, 2);
                if (respondkey == 200)
                {
                    output = respondlang;
                    returnvalue = true;
                }
                else
                {
                    output = "";
                    returnvalue = false;
                }
                key = respondkey;
            }
            else
            {
                output = "";
                returnvalue = false;
                key = 0;
            }
            return returnvalue;
        }

        public string translate(string text, string apikey, string beforelang, string afterlang)
        {
            string xml = download(("https://translate.yandex.net/api/v1.5/tr/translate?key=" + apikey + "&lang=" + beforelang + "-" + afterlang + "&text=" + text.Replace(" ", "+")));
            string returnvalue = "";
            int indexoftextend = xml.IndexOf("</text>");
            int indexoftext = (xml.IndexOf("<text>"));
            int indexoftextsnext = (indexoftext + 6);
            returnvalue = xml.Substring(indexoftextsnext, (indexoftextend - indexoftextsnext));
            return returnvalue;
        }

        public string translate(string text, string apikey, string afterlang)
        {
            string beforelang = detect(text, apikey);
            string xml = download(("https://translate.yandex.net/api/v1.5/tr/translate?key=" + apikey + "&lang=" + beforelang + "-" + afterlang + "&text=" + text.Replace(" ", "+")));
            string returnvalue = "";
            int indexoftextend = xml.IndexOf("</text>");
            int indexoftext = (xml.IndexOf("<text>"));
            int indexoftextsnext = (indexoftext + 6);
            if (indexoftext == -1 || indexoftextend == -1 || indexoftextsnext == -1)
            {
                returnvalue = "Error!";
            }
            else
            {
                returnvalue = xml.Substring(indexoftextsnext, (indexoftextend - indexoftextsnext));
            }
            return returnvalue;
        }
    }
}
