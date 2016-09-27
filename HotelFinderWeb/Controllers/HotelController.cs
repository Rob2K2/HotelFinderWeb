using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Globalization;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Controllers
{
    [HandleError(View = "Error")]
    [ValueReporter]
    public class HotelController : Controller
    {
        private IHotelFinderContext context;

        //Constructors
        public HotelController()
        {
            context = new HotelFinderContext();
        }

        public HotelController(IHotelFinderContext Context)
        {
            context = Context;
        }

        //
        // GET: /Photo/
        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Hotel> hotels;

            if (number == 0)
            {
                hotels = context.Photos.ToList();
            }
            else
            {
                hotels = (from p in context.Photos
                          orderby p.CreatedDate descending
                          select p).Take(number).ToList();
            }

            return PartialView("_PhotoGallery", hotels);
        }

        public ActionResult Display(int id)
        {
            Hotel photo = context.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Display", photo);
        }

        public ActionResult DisplayByTitle(string title)
        {
            Hotel photo = context.FindPhotoByTitle(title);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Display", photo);
        }

        [Authorize]
        public ActionResult Create()
        {
            Hotel newPhoto = new Hotel();
            newPhoto.CreatedDate = DateTime.Today;
            return View("Create", newPhoto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Hotel photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.HotelPicture = new byte[image.ContentLength];
                    image.InputStream.Read(photo.HotelPicture, 0, image.ContentLength);
                }
                context.Add<Hotel>(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Hotel photo = context.FindPhotoById(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View("Delete", photo);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel photo = context.FindPhotoById(id);
            context.Delete<Hotel>(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int id)
        {
            Hotel photo = context.FindPhotoById(id);
            if (photo != null)
            {
                return File(photo.HotelPicture, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult SlideShow()
        {
            return View("SlideShow", context.Photos.ToList());
        }
    }
}
