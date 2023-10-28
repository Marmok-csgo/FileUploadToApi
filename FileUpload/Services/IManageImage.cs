namespace FileUpload.Services;

public interface IManageImage
{
    Task<string> UploadFile(IFormFile iFormFile);

    Task<(byte[], string, string)> DownloadFile(string fileName);
}