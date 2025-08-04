using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
namespace Backend.Helpers
{
  public class cloudinaryService : IPhotoService
  {
    private readonly Cloudinary _cloudinary;
    public cloudinaryService(IOptions<CloudinarySettings> config)
    {
      var Acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
      _cloudinary = new Cloudinary(Acc);
    }

    public async Task<List<ImageUploadResult>> AddPhotosAsync(IFormFile[] files)
    {
      var uploadResults = new List<ImageUploadResult>();

      foreach (var file in files)
      {
        if (file.Length > 0)
        {
          using var stream = file.OpenReadStream();
          var uploadParams = new ImageUploadParams
          {
            File = new FileDescription(file.FileName, stream),
            Transformation = new Transformation()
                  .Height(400).Width(300).Crop("fill").Gravity("face"),
            Folder = "da-net8"
          };
          var uploadResult = await _cloudinary.UploadAsync(uploadParams);
          uploadResults.Add(uploadResult);
        }
      }

      return uploadResults;
    }
  }
}
