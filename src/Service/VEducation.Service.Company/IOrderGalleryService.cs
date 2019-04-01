﻿using Abp.Application.Services;
using System.Collections.Generic;
using VEducation.Data.ViewModels;

namespace VEducation.Service.Company
{
    public interface IOrderGalleryService : IApplicationService
    {
        List<GalleryViewModel> GetAll();
    }
}