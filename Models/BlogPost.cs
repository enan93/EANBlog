using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace BlogProject42020.Models

{
    public class BlogPost
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }

        public string Abstract { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public string MediaUrl { get; set; }

        public bool IsPublished { get; set; }

        public int ViewCount { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

        public BlogPost()
        {
            Comments = new HashSet<Comments>();
        }

        


    }

    public static class ImageUploadValidator
    {
        public static bool IsWebFriendlyImage(HttpPostedFileBase image)
        {
            if (image == null)
                return false;

            if (image.ContentLength > 2 * 1024 * 1024 || image.ContentLength < 1024)
                return false;

            try
            {
                using (var img = Image.FromStream(image.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(img.RawFormat) ||
                        ImageFormat.Png.Equals(img.RawFormat) ||
                        ImageFormat.Gif.Equals(img.RawFormat);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}