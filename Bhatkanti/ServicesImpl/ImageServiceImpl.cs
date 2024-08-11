using Bhatkanti.Models;
using Bhatkanti.Services;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames.Image;

namespace Bhatkanti.ServicesImpl
{
    public class ImageServiceImpl : IImageService
    {
        private readonly ApplicationDbContext _context;

        public ImageServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Images>> GetAllImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Images> GetImageByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<Images> CreateImageAsync(Images image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Images> UpdateImageAsync(Images image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task DeleteImageAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }
    }
}
