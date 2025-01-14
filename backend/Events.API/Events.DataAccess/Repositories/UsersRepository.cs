﻿using AutoMapper;
using Events.Core.Enums;
using Events.Core.Models;
using Events.DataAccess.Entities;
using Events.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Events.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EventsDbContext context;
        private readonly IMapper mapper;

        public UsersRepository(
            EventsDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Add(User user)
        {
            var roleEntity = await context.Roles
                .SingleOrDefaultAsync(r => r.Id == (int)Role.Admin)
                ?? throw new InvalidOperationException();

            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                Roles = [roleEntity]
            };

            await context.AddAsync(userEntity);
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            return mapper.Map<User>(userEntity);
        }

        public async Task<HashSet<Permission>> GetUserPermissions(Guid userId)
        {
            var roles = await context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions)
                .Where(u => u.Id == userId)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r)
                .SelectMany(r => r.Permissions)
                .Select(p => (Permission)p.Id)
                .ToHashSet();
        }
    }
}
