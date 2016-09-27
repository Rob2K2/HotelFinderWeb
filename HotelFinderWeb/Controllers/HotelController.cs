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
            Hotel hotel = context.FindPhotoById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View("Display", hotel);
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
        public ActionResult Create(Hotel hotel, HttpPostedFileBase image)
        {
            hotel.CreatedDate = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View("Create", hotel);
            }
            else
            {
                if (image != null)
                {
                    hotel.ImageMimeType = image.ContentType;
                    hotel.HotelPicture = new byte[image.ContentLength];
                    image.InputStream.Read(hotel.HotelPicture, 0, image.ContentLength);
                }
                context.Add<Hotel>(hotel);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Hotel hotel = context.FindPhotoById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View("Delete", hotel);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = context.FindPhotoById(id);
            context.Delete<Hotel>(hotel);
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
