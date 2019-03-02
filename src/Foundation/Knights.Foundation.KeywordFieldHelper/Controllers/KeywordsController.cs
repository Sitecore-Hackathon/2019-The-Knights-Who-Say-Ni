using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Knights.Feature.KeywordFieldHelper.Models;
using Knights.Feature.KeywordFieldHelper.Services;
using Sitecore.Globalization;
using Sitecore.Mvc.Controllers;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController : SitecoreController
    {
        #region Ctors

        public KeywordsController(IKeywordHelperService keywordHelperService,
            IKeywordRankingProvider keywordRankingProvider)
        {
            _keywordHelperService = keywordHelperService;
            _keywordRankingProvider = keywordRankingProvider;
        }

        #endregion

        #region Private members

        private KeywordsResponseViewModel GetViewModel()
        {
            return new KeywordsResponseViewModel
            {
                VolumeLabel = Translate.Text("KeywordFieldHelper.Volume.Label"),
                CpcLabel = Translate.Text("KeywordFieldHelper.CPC.Label"),
                CompetitionLabel = Translate.Text("KeywordFieldHelper.Competition.Label")
            };
        }

        #endregion

        #region Fields

        private readonly IKeywordHelperService _keywordHelperService;
        private readonly IKeywordRankingProvider _keywordRankingProvider;

        #endregion

        #region Actions

        public ActionResult Get(string id)
        {
            var viewModel = GetViewModel();
            viewModel.Keywords = _keywordHelperService.GetRankedSuggestions(id).ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Rank(string id)
        {
            var viewModel = GetViewModel();
            viewModel.Keywords = new List<RankedKeyword>
            {
                _keywordRankingProvider.RankKeyword(id)
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLabels()
        {
            var viewModel = GetViewModel();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}