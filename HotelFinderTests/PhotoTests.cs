using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using PhotoSharingApplication.Controllers;
using PhotoSharingApplication.Models;
using System.Collections.Generic;
using System.Linq;
using PhotoSharingTests.Doubles;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            //This test checks that the PhotoController Index action returns the Index View
            var context = new FakePhotoSharingContext();
            var controller = new HotelController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Test_PhotoGallery_Model_Type()
        {
            //This test checks that the PhotoController _PhotoGallery action passes a list of Photos to the view
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel(),
                new Hotel(),
                new Hotel(),
                new Hotel()
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller._PhotoGallery() as PartialViewResult;
            Assert.AreEqual(typeof(List<Hotel>), result.Model.GetType());
        }

        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            //This test checks that the PhotoController GetImage action returns a FileResult
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel{ HotelID = 1, HotelPicture = new byte[1], ImageMimeType = "image/jpeg" },
                new Hotel{ HotelID = 2, HotelPicture = new byte[1], ImageMimeType = "image/jpeg" },
                new Hotel{ HotelID = 3, HotelPicture = new byte[1], ImageMimeType = "image/jpeg" },
                new Hotel{ HotelID = 4, HotelPicture = new byte[1], ImageMimeType = "image/jpeg" }
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller.GetImage(1) as ActionResult;
            Assert.AreEqual(typeof(FileContentResult), result.GetType());
        }

        [TestMethod]
        public void Test_DisplayByTitle_Return_Photo()
        {
            //This test checks that the PhotoController DisplayByTitle action returns the right photo
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel{ HotelID = 1, Name="Photo1" },
                new Hotel{ HotelID = 2, Name="Photo2" },
                new Hotel{ HotelID = 3, Name="Photo3" },
                new Hotel{ HotelID = 4, Name="Photo4" }
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller.DisplayByTitle("Photo2") as ViewResult;
            var resultPhoto = (Hotel)result.Model;
            Assert.AreEqual(2, resultPhoto.HotelID);
        }

        [TestMethod]
        public void Test_DisplayByTitle_Return_Null()
        {
            //This test checks that the PhotoController DisplayByTitle action returns
            //HttpNotFound when you request a title that doesn't exist
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel{ HotelID = 1, Name="Photo1" },
                new Hotel{ HotelID = 2, Name="Photo2" },
                new Hotel{ HotelID = 3, Name="Photo3" },
                new Hotel{ HotelID = 4, Name="Photo4" }
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller.DisplayByTitle("NonExistentTitle");
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }

        [TestMethod]
        public void Test_PhotoGallery_No_Parameter()
        {
            //This test checks that, when you call the _PhotoGallery action with no
            //parameter, all the photos in the context are returned
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel(),
                new Hotel(),
                new Hotel(),
                new Hotel()
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller._PhotoGallery() as PartialViewResult;
            var modelPhotos = (IEnumerable<Hotel>)result.Model;
            Assert.AreEqual(4, modelPhotos.Count());
        }

        [TestMethod]
        public void Test_PhotoGallery_Int_Parameter()
        {
            //This test checks that, when you call the _PhotoGallery action with no
            //parameter, all the photos in the context are returned
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
                new Hotel(),
                new Hotel(),
                new Hotel(),
                new Hotel()
            }.AsQueryable();

            var controller = new HotelController(context);
            var result = controller._PhotoGallery(3) as PartialViewResult;
            var modelPhotos = (IEnumerable<Hotel>)result.Model;
            Assert.AreEqual(3, modelPhotos.Count());
        }
    }
}
