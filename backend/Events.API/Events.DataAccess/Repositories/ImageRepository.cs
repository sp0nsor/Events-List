using AutoMapper;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;

        public ImageRepository(EventsDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Create(Image image)
        {
            var imageEntity = new ImageEntity()
            {
                Id = image.Id,
                EventId = image.EventId,
                FileName = image.FileName,
            };

            await context.Images.AddAsync(imageEntity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Image>> Get()
        {
            var imageEntity = await context.Images
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<List<Image>>(imageEntity);
        }
    }
}
