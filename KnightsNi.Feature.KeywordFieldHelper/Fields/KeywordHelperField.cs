using System.Web.UI;
using Sitecore.Globalization;
using Sitecore.Shell.Applications.ContentEditor;

namespace Knights.Feature.KeywordFieldHelper.Fields
{
    public class KeywordHelperField : Text
    {
        #region Constants

        public const string CLASS_NAME = "keyword-helper-field";

        #endregion

        #region Ctors

        public KeywordHelperField()
        {
            Class += " " + CLASS_NAME;
        }

        #endregion

        protected override void DoRender(HtmlTextWriter output)
        {
            this.Attributes["placeholder"] = Translate.Text(this.Placeholder);

            string str = this.Password ? " type=\"password\"" : (this.Hidden ? " type=\"hidden\"" : "");
            var initKeywordsHelperFieldScript = "<script>initKeywordHelperField('#" + ID + "');</script>";
            this.SetWidthAndHeightStyle();
            output.Write("<input" + this.ControlAttributes + str + ">" + initKeywordsHelperFieldScript);
            this.RenderChildren(output);
        }
    }
}