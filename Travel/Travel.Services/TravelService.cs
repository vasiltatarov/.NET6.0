namespace Travel.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Travel.Data;
    using Travel.Data.Models;
    using Travel.Services.Dtos;
    using Travel.Services.Interfaces;
    using AutoMapper;

    public class TravelService : ITravelService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public TravelService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Create(CreateTravelRequestModel request)
        {
            var entity = this.mapper.Map<TravelEntity>(request);

            await this.dbContext.Travels.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

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
