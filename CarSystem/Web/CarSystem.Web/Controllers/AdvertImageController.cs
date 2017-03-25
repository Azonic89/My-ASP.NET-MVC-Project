using System.Web.Mvc;

using Bytes2you.Validation;

using CarSystem.Data.Services.Contracts;

namespace CarSystem.Web.Controllers
{
    public class AdvertImageController : Controller
    {
        private readonly IAdvertImageService advertImageService;

        public AdvertImageController(IAdvertImageService advertImageService)
        {
            Guard.WhenArgument(advertImageService, nameof(advertImageService)).IsNull().Throw();

            this.advertImageService = advertImageService;
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
            var fileToRetrieve = this.advertImageService.GetById(id);

            if (fileToRetrieve == null)
            {
                return Content(null);
            }

            return File(fileToRetrieve.ImageData, fileToRetrieve.ImageName);
        }
    }
}