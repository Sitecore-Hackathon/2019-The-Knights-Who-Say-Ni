﻿using Knights.Feature.KeywordFieldHelper.Models;
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
                
            };
        }
    }
}
