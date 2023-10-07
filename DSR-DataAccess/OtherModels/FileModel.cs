using Microsoft.AspNetCore.Http;

namespace DSR.Models
{
    public class FileModel
    {
        public string? FileName { get; set; }
        public IFormFile? file { get; set; }
    }
}
