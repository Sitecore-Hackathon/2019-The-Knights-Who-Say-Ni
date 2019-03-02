using System.Web.Mvc;
using Knights.Feature.KeywordFieldHelper.Services;
using Sitecore.Mvc.Controllers;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController: SitecoreController
    {
        #region Fields

        private readonly IKeywordHelperService _keywordHelperService;

        #endregion

        #region Ctors

        public KeywordsController(IKeywordHelperService keywordHelperService)
        {
            _keywordHelperService = keywordHelperService;
        }

        #endregion

        #region Actions

        public ActionResult Get(string id)
        {
            return Json(_keywordHelperService.GetRankedSuggestions(id), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}