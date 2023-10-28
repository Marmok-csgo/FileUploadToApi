using FileUpload.Helper;
using Microsoft.AspNetCore.StaticFiles;

namespace FileUpload.Services;

public class ManageImage : IManageImage
{
    public async Task<string> UploadFile(IFormFile iFormFile)
    {
        string fileName = "";

        try
        {
            var fileInfo = new FileInfo(iFormFile.FileName);

            fileName = iFormFile.FileName + "_" + DateTime.Now.Ticks.ToString() + fileInfo.Extension;
            var getFilePath = Common.GetFilePath(fileName);

            using (var fileStream = new FileStream(getFilePath, FileMode.Create))
            {
                await iFormFile.CopyToAsync(fileStream);
            }

            return fileName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        throw new NotImplementedException();
    }

    public async Task<(byte[], string, string)> DownloadFile(string fileName)
    {
        try
        {
            var getFilePath = Common.GetFilePath(fileName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(getFilePath, out var _ContentType))
            {
                _ContentType = "application/octet-stream";
            }
            var _ReadAllBytesAsync = await File.ReadAllBytesAsync(getFilePath);
            return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(getFilePath));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}