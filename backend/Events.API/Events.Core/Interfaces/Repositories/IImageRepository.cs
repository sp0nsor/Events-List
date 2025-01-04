﻿using Events.Core.Models;

namespace Events.DataAccess.Repositories
{
    public interface IImageRepository
    {
        Task Create(Image image);
        Task<List<Image>> Get();
    }
}