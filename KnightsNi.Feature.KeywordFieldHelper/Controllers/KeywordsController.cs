using System.Linq;
using System.Web.Mvc;
using Knights.Feature.KeywordFieldHelper.Models;
using Knights.Feature.KeywordFieldHelper.Services;
using Sitecore.Mvc.Controllers;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController : SitecoreController
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
            var viewModel = GetViewModel();
            viewModel.Keywords = _keywordHelperService.GetRankedSuggestions(id).ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLabels()
        {
            var viewModel = GetViewModel();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Private members

        private KeywordsResponseViewModel GetViewModel()
        {
            return new KeywordsResponseViewModel()
            {
                VolumeLabel = Sitecore.Globalization.Translate.Text("KeywordFieldHelper.Volume.Label"),
                CpcLabel = Sitecore.Globalization.Translate.Text("KeywordFieldHelper.CPC.Label"),
                CompetitionLabel = Sitecore.Globalization.Translate.Text("KeywordFieldHelper.Competition.Label"),
            };
        }

        #endregion

    }
}