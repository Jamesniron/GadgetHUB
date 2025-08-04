using CloudinaryDotNet.Actions;

namespace Backend.Helpers
{
  public interface IPhotoService
  {
    Task<List<ImageUploadResult>> AddPhotosAsync(IFormFile[] files);
  }
}
