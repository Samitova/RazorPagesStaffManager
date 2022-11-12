using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RazorPagesStaffManager.Services.FileServices
{
    public static class ImageService
    {
        public static string ProcessUploadedPhoto(IFormFile Photo, string uploadsFolder)
        {
            string unicPhotoName = null;
            if (Photo != null)
            {
                unicPhotoName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, unicPhotoName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return unicPhotoName;
        }
    }
}
