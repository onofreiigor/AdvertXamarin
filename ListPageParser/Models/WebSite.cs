using System;
using System.Collections.Generic;
using System.Text;

namespace ListPageParser.Models
{
    public class WebSite
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string LangRo { get; set; }
        public string LangRu { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nUrl: {Url}\nLangRo: {LangRo}\nLangRu: {LangRu}\n";
        }
    }
}
