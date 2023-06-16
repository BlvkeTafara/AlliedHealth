using AlliedHealth.DataAccess.Context;
using AlliedHealth.Domain.DTOs;
using AlliedHealth.Domain.Entities;
using AlliedHealth.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlliedHealth.DataAccess.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly AlliedHealthDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(AlliedHealthDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(CityDto dto)
        {
            var entity = _mapper.Map<City>(dto);
            _context.Cities.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<CityDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<City>>(dto);
            _context.Cities.AddRange(entities);
        }

        public IEnumerable<CityDto> GetAll()
        {
            var entities = _context.Cities.ToList();
            var Dtos = _mapper.Map<IEnumerable<CityDto>>(entities);
            return Dtos;

        }

        public CityDto GetById(int id)
        {
            var entity = _context.Cities.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<CityDto>(entity);
            return dto;
        }
        public void Remove(int id)
        {
            var citydel = _context.Cities.Where(city => city.Id == id).FirstOrDefault();

            _context.Cities.Remove(citydel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<CityDto> entities)
        {
            var entitties = _context.Cities.ToList();
            var Dtos = _mapper.Map<IEnumerable<CityDto>>(entities);
        }

        public void Update(CityDto dto)
        {
            var cityupt = _context.Cities.Where(city => city.Id == dto.Id).FirstOrDefault();

            if (cityupt != null)
            {
                cityupt.Name = dto.Name;
                cityupt.Location = dto.Location;

            }


            _context.SaveChanges();
        }
    }
}
