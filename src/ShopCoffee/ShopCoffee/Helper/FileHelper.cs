using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ShopCoffee.Helpers
{
    public static class FileHelper
    {
        public static async Task<string?> SaveImageAsync(IFormFile file, string subFolder)
        {
            if (file == null || file.Length == 0)
                return null;

            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", subFolder);

            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            // Tạo tên file duy nhất
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Gộp đường dẫn file vật lý
            var filePath = Path.Combine(uploadDir, fileName);

            // Lưu file xuống
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Trả về đường dẫn tương đối để lưu vào DB
            return $"/images/{subFolder}/{fileName}";
        }
        public static void DeleteImage(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
