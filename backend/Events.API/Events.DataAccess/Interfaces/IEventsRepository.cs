﻿using Events.Core.Models;

namespace Events.DataAccess.Interfaces
{
    public interface IEventsRepository
    {
        Task Create(Event Event);
        Task Delete(Guid id);
        Task<List<Event>> Get(string? searchName, string? searchPlace,
            string? searchCategory, string? sortItem, string? sortOrder);
        Task<Event> GetById(Guid id);
        Task Update(Guid id, string name, string description, string place,
            string category, int maxParticipantCount, DateTime time);
        Task<List<Participant>> GetParticipants(Guid eventId);
    }
}