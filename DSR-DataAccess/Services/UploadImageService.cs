using DSR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSR_DataAccess.Services
{
    public class UploadImageService : IUploadImageService
    {
        public Response UploadImage([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"D:\MyImages", fileModel.FileName+".pdf");
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileModel.file.CopyTo(stream);
                }
                response.Statuscode = 200;
                response.ErrorMessage = "image created successfully";

            }
            catch (Exception ex)
            {
                response.Statuscode = 100;
                response.ErrorMessage = "some error occured" + ex.Message;
            }
            return response;
        }
    }
}
