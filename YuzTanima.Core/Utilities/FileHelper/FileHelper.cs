using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YuzTanima.Core.Utilities.Results;

namespace YuzTanima.Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file,Guid ziyaretciId)
        {
            var result = newPath(file,ziyaretciId);

            try
            {
                var sourcepath = Path.GetTempFileName();

                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                File.Move(sourcepath, result.newPath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result.Path2;
        }

        public static (string newPath, string Path2) newPath(IFormFile file,Guid ziyaretciId)
        {
            FileInfo ff = new FileInfo(file.FileName);
           

            string fileExtension = ff.Extension;

            var creatingUniqueFilename = ziyaretciId.ToString() + fileExtension;

            string result = $@"/Users/cenkkaraboa/Desktop/son/YuzTanima/YuzTanima.WebService/wwwroot/Images/{creatingUniqueFilename}";
            return (result, $"\\Images\\{creatingUniqueFilename}");
        }


    }
}
