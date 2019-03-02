using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    public class Keyword
    {
        public string Word { get; set; }
        public int Rank { get; set; }
        public double CPC { get; set; }

        public double Competion { get; set; }
    }
}