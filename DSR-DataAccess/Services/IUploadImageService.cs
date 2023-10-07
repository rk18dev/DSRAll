using Azure;
using DSR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Response = DSR.Models.Response;
using Microsoft.AspNetCore.Http;

namespace DSR_DataAccess.Services
{
    public interface IUploadImageService
    {
        Response UploadImage([FromForm]FileModel fileModel);
        
    }
}
