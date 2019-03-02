using Knights.Feature.KeywordFieldHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController : ApiController
    {
        public KeywordSuggestions Get()
        {
            return new KeywordSuggestions()
            {
                Keywords = new List<Keyword>()
                {
                    new Keyword{ Word = "Ni0", Competion= 1, CPC = 100.00, Rank = 100 },
                    new Keyword{ Word = "Ni1", Competion= 1, CPC = 100.00, Rank = 100 },
                    new Keyword{ Word = "Ni2", Competion= 1, CPC = 100.00, Rank = 100 }
                }
            };
        }
    }
}
