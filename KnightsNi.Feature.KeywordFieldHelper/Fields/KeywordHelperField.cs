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
    }
}