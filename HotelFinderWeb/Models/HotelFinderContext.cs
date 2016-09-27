using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class HotelFinderContext : DbContext, IHotelFinderContext
    {
        public HotelFinderContext()
            : base("AzureAppServices")
        {

        }
        public DbSet<Hotel> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        IQueryable<Hotel> IHotelFinderContext.Photos
        {
            get { return Photos; }
        }

        IQueryable<Comment> IHotelFinderContext.Comments
        {
            get { return Comments; }
        }

        int IHotelFinderContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IHotelFinderContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Hotel IHotelFinderContext.FindPhotoById(int ID)
        {
            return Set<Hotel>().Find(ID);
        }

        Hotel IHotelFinderContext.FindPhotoByTitle(string Title)
        {
            Hotel photo = (from p in Set<Hotel>()
                           where p.Name == Title
                           select p).FirstOrDefault();
            return photo;
        }

        Comment IHotelFinderContext.FindCommentById(int ID)
        {
            return Set<Comment>().Find(ID);
        }


        T IHotelFinderContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}