using Knights.Feature.KeywordFieldHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController : Controller
    {
      
        public JsonResult GetKeywords()
        {
            var keywords = new KeywordSuggestions()
            {

                Keywords = new List<Keyword>()
                {
                    
                }
            };

            return new JsonResult() { Data = keywords, JsonRequestBehavior= JsonRequestBehavior.AllowGet };
        }
    }
}
