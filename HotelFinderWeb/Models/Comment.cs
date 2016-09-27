using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Comment
    {
        //CommentID. This is the Primary Key
        public int CommentID { get; set; }

        //PhotoID. This is the ID of the photo that this comment relates to
        public int HotelID { get; set; }

        //UserName. This is the name of the user who made this comment
        public string UserName { get; set; }

        //Subject.  
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        //Body
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}