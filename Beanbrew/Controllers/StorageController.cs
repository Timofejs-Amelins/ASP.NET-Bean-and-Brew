using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Beanbrew.Controllers
{
    public class StorageController : Controller
    {
        // GET: StorageController - get and return webform sending files
        public IActionResult Index()
        {
            return View();
        }

        // identify that this method is the POST implementation of webform
        [HttpPost]
        // this method uploads a file to the server with error handling
        public IActionResult Index(IFormFile userfile) {
            // try get the file by the file name and copying it to folder
            try
            {
                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                string uploadfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\FileStorage", filename);
                var stream = new FileStream(uploadfile, FileMode.Create);
                userfile.CopyToAsync(stream);
                ViewBag.message = "File uploaded successfully";
            }

            // if there is an exception handle and print the exception msg
            catch (Exception ex)
            {
                ViewBag.message = "Error: " + ex.Message.ToString();
            }

            // return the same page no matter what because msgs on same page
            return View();
        }
    }
}
