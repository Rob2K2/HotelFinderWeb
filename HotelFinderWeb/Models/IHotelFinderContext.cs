using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharingApplication.Models
{
    public interface IHotelFinderContext
    {
        IQueryable<Hotel> Photos { get; }
        IQueryable<Comment> Comments { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Hotel FindPhotoById(int ID);
        Hotel FindPhotoByTitle(string Title);
        Comment FindCommentById(int ID);
        T Delete<T>(T entity) where T : class;
    }
}
