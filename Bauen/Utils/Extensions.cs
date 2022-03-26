using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Utils
{
    public static class Extensions
    {
        public static bool IsImage(this IFormFile img)
        {
            return img.ContentType.Contains("image/");
        }

        public static bool IsValidImage(this IFormFile img, int kb)
        {
            return img.Length / 1024 > kb;
        }

        public static async Task<string> UpLoad(this IFormFile img, string root,string folder)
        {
           string fileName = Guid.NewGuid().ToString()+"-"+ img.FileName;
           string path = Path.Combine(root,folder,fileName);
           FileStream stream = new FileStream(path,FileMode.Create);

            await img.CopyToAsync(stream);
            return (fileName);
        }


    }
}
