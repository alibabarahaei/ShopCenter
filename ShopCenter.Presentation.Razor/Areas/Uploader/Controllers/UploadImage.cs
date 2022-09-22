using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopCenter.Application.Extensions;
using ShopCenter.Application.Utilities;

namespace ShopCenter.Presentation.Razor.Areas.Uploader.Controllers
{
    public class UploadImage : Controller
    {



        public IActionResult Index()
        {
            return View();
        }










        [HttpPost]
        public IActionResult Index(IFormFile upload, string CKEditorFuncName, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;
            if (!upload.IsImage())
            {
                var notImageMessage = "لطفا یک تصویر انتخاب کنید";
                var notImage = JsonConvert.DeserializeObject("{'uploaded':0, 'error': {'message': \" " + notImageMessage + " \"}}");
                return Json(notImage);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            upload.AddImageToServer(fileName, SD.UploadImageServer, null, null);
            return Json(new
            {
                uploaded = true,
                url = $"{SD.UploadImage}{fileName}"
            });
        }
    }
}
