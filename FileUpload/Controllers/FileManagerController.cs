using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IManageImage _iManageImage;

        public FileManagerController(IManageImage iManageImage)
        {
            _iManageImage = iManageImage;
        }

        [HttpPost]
        [Route("UploadFile")]

        public async Task<IActionResult> UploadFile(IFormFile iFormFile)
        {
            var result = await _iManageImage.UploadFile(iFormFile);

            return Ok(result);
        }

        [HttpGet]
        [Route("DownloadFile")]

        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var result = await _iManageImage.DownloadFile(fileName);

            return File(result.Item1, result.Item2, result.Item2);
            
        }
    }
}
