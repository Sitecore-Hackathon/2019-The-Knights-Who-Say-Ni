using System.Web.UI;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.StringExtensions;

namespace Knights.Feature.KeywordFieldHelper.Processors
{
    public class InjectScripts
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";
        private const string StylesheetLinkTag = "<link href=\"{0}\" rel=\"stylesheet\" />";

        public void Process(PipelineArgs args)
        {
            AddControls(JavascriptTag, "CustomContentEditorJavascript");
            AddControls(StylesheetLinkTag, "CustomContentEditorStylesheets");
        }

        private void AddControls(string resourceTag, string configKey)
        {
            Assert.IsNotNullOrEmpty(configKey, "Content Editor resource config key cannot be null");

            var resources = Settings.GetSetting(configKey);

            if (string.IsNullOrEmpty(resources))
                return;

            foreach (var resource in resources.Split('|'))
                Context.Page.Page.Header.Controls.Add(new LiteralControl(resourceTag.FormatWith(resource)));
        }
    }
}