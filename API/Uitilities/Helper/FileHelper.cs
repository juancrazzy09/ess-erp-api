using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace API.Uitilities.Helper
{
    public class FileHelper
    {
        public async Task<string> SaveAndCompressFileAsync(IFormFile file, string folderName, long userId)
        {
            if (file == null || file.Length == 0) return null;

            var uploadsPath = Path.Combine("uploads", folderName);
            Directory.CreateDirectory(uploadsPath);

            var ext = Path.GetExtension(file.FileName);
            var uniqueFileName = $"{userId}_{Guid.NewGuid()}{ext}";
            var filePath = Path.Combine(uploadsPath, uniqueFileName);

            if (ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                ext.Equals(".png", StringComparison.OrdinalIgnoreCase))
            {
                using var image = await Image.LoadAsync(file.OpenReadStream());
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Max,
                    Size = new Size(800, 800)
                }));
                await image.SaveAsync(filePath);
            }
            else
            {
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            // Return relative path with forward slashes for URLs
            var relativePath = Path.Combine("uploads", folderName, uniqueFileName)
                                   .Replace("\\", "/");

            return relativePath;
        }

    }
}
