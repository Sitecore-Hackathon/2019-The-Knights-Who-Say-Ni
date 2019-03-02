using System.Web.Http;
using Knights.Feature.KeywordFieldHelper.Services;

namespace Knights.Feature.KeywordFieldHelper.Controllers
{
    public class KeywordsController : Controller
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

        //public IHttpActionResult Get(string keyword)
        //{
        //    return Json(null, JsonRequestBehavior.AllowGet)
        //}

        #endregion
    }
}