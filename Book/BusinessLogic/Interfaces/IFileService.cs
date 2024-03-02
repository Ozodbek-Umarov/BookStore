namespace Book.BusinessLogic.Interfaces;

public interface IFileService
{
    string UploadImage(IFormFile file);
    void DeleteImage(string fileName);
}
