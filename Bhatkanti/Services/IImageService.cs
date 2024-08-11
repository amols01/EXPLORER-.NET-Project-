using Bhatkanti.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.Mime.MediaTypeNames.Image;
namespace Bhatkanti.Services
{
    public interface IImageService 
    {
        Task<IEnumerable<Images>> GetAllImagesAsync();
        Task<Images> GetImageByIdAsync(int id);
        Task<Images> CreateImageAsync(Images image);
        Task<Images> UpdateImageAsync(Images image);
        Task DeleteImageAsync(int id);
    }
}
