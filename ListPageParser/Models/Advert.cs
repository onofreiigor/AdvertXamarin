using System;
using System.Collections.Generic;
using System.Text;

namespace ListPageParser.Models
{
    public class Advert
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nDescription: {Description}\nImgPath: {ImgPath}\n";
        }
    }

    class AdvertDetail
    {

    }

    class AdvertImage
    {

    }
}
