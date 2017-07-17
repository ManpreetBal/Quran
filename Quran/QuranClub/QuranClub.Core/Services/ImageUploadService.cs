using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using QuranClub.Repository;
using Microsoft.AspNetCore.Mvc;
using QuranClub.Core.Services.IServices;
using QuranClub.Domain.Entities;
using System.Net;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace QuranClub.Core.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private IHostingEnvironment _env;
        private DBEntities _context;
        public ImageUploadService(DBEntities context, IHostingEnvironment env)
        {
            this._context = context;
            this._env = env;
        }
        public async Task<string> imageupload(IFormFileCollection files)
        {
            var filename = "";
            string guid = Guid.NewGuid().ToString().Substring(0, 4);

            long size = 0;
            foreach (var file in files)
            {
                filename = guid + ContentDispositionHeaderValue
                               .Parse(file.ContentDisposition)
                               .FileName
                               .Trim('"');
                var webRoot = _env.WebRootPath;
                var path = System.IO.Path.Combine(webRoot, "uploads/" + filename);
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(fs);
                    fs.Flush();
                }
            }
            return filename;
        }
    }
}

