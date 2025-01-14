﻿using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.DTOs.BedroomDto;
using AutoMapper;
using Easy.Hosts.Core.Repositories.Interface;
using System.Linq;

namespace Easy.Hosts.Core.Repositories.Entities
{
    public class BedroomRepository : IBedroomRepository
    {
        private readonly EasyHostsDbContext _context;
        private readonly IMapper _mapper;

        public BedroomRepository(EasyHostsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BedroomReadDto> InsertAsync(BedroomCreateDto bedroom)
        {
            Bedroom bedromNew = new()
            {
                Id = Guid.NewGuid(),
                Name = bedroom.Name,
                Number = bedroom.Number,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Set<Bedroom>().AddAsync(bedromNew);
            await _context.SaveChangesAsync();

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(bedromNew);
            return bedroomReadDto;
        }

        public async Task<IEnumerable<BedroomReadDto>> FindAllAsync()
        {
            IEnumerable<Bedroom> result = await _context.Set<Bedroom>().ToListAsync();

            IEnumerable<BedroomReadDto> bedroomReadDtos = _mapper.Map<IEnumerable<BedroomReadDto>>(result);
            return bedroomReadDtos;
        }

        public async Task<BedroomReadDto> GetByIdAsync(Guid? id)
        {
            Bedroom result = await _context.Set<Bedroom>().FirstOrDefaultAsync(f => f.Id == id);

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(result);
            return bedroomReadDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Bedroom result = await _context.Set<Bedroom>().FirstOrDefaultAsync(f => f.Id == id);

            _context.Remove(result);
            _context.SaveChanges();
            return true;
        }

        public async Task<BedroomReadDto> UpdateAsync(Guid id, BedroomUpdateDto bedroomUpdateDto)
        {
            Bedroom result = await _context.Set<Bedroom>()
                .Where(x => x.Id ==  id)
                .FirstOrDefaultAsync();

            result.UpdatedAt = DateTime.Now;
            result.Name = bedroomUpdateDto.Name;
            result.Number = bedroomUpdateDto.Number;

            await _context.SaveChangesAsync();

            BedroomReadDto bedroomReadDto = _mapper.Map<BedroomReadDto>(result);
            return bedroomReadDto;
        }
    }
}
