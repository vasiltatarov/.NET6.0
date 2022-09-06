﻿namespace Travel.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Travel.Data;
    using Travel.Services.Dtos;
    using Travel.Services.Interfaces;

    public class TravelService : ITravelService
    {
        private readonly ApplicationDbContext dbContext;

        public TravelService(ApplicationDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<IEnumerable<TravelDto>> GetTravelsAsync()
        {
            return await this.dbContext.Travels
                .Select(x => new TravelDto
                {
                    Id = x.Id,
                    Destination = x.Destination,
                    Participants = x.Participants,
                    Description = x.Description,
                    Accommodation = x.Accommodation,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    UserId = x.UserId
                })
                .ToListAsync();
        }
    }
}
