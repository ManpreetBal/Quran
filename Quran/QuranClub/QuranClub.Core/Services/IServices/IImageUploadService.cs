using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services.IServices
{
    public interface IImageUploadService
    {
        Task<string> imageupload(IFormFileCollection files);
    }
}
