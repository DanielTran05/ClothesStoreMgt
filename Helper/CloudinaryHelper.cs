using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class CloudinaryHelper
    {
        private static readonly Cloudinary _cloudinary;

        static CloudinaryHelper()
        {
            Account account = new Account(
                "djhiau9nq",
                "213478935551515",
                "mLUq43xmb-kFsQarGlKUyMi3rVI"
            );
            _cloudinary = new Cloudinary(account);
        }

        //return ve string url (duong link cua hinh) roi hien thi len thoi nha
        public static string UploadImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return null;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath),
                Folder = "ClothesStore_Products",
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}
