using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Webnovel.Services
{
    public static class CloudinaryUpload
    {
        public static string apiKey = "849621861927721";
        public static string apiSecret = "0ofuuFUGk_6zt4lmaXTsXayy07k";
        public static string cloud = "votel";
        public static string uploadedPath;
        private static Account account = new Account()
        {
            ApiKey = apiKey,
            ApiSecret = apiSecret,
            Cloud = cloud
        };
        public static async Task<bool> UploadToCloud(string base64String, string folder = "webnovel")
        {

            Cloudinary cloud = new Cloudinary(account);

            var uploadParam = new ImageUploadParams()
            {
                File = new FileDescription(base64String),
                Folder = folder
            };
            try
            {
                var uploadResult = cloud.Upload(uploadParam);
                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    uploadedPath = uploadResult.SecureUri.ToString();
                    
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
           
            return false;
        }
    }
}
