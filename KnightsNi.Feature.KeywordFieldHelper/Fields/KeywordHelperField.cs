using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knights.Feature.KeywordFieldHelper.Fields
{
    public class KeywordHelperField : Sitecore.Shell.Applications.ContentEditor.Text
    {

        public KeywordHelperField()
        {
            Class = "scContentControl keyword-helper";
        }

    }
}