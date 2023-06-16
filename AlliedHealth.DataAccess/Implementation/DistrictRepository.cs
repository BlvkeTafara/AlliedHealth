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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly AlliedHealthDbContext _context;
        private readonly IMapper _mapper;

        public DistrictRepository(AlliedHealthDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(DistrictDto dto)
        {
            var entity = _mapper.Map<District>(dto);
            _context.Districts.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<DistrictDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<District>>(dto);
            _context.Districts.AddRange(entities);
        }
        public IEnumerable<DistrictDto> GetAll()
        {
            var entities = _context.Districts.ToList();
            var Dtos = _mapper.Map<IEnumerable<DistrictDto>>(entities);
            return Dtos;

        }

        public DistrictDto GetById(int id)
        {
            var entity = _context.Districts.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<DistrictDto>(entity);
            return dto;
        }
        public void Remove(int id)
        {
            var districtdel = _context.Districts.Where(district => district.Id == id).FirstOrDefault();

            _context.Districts.Remove(districtdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<DistrictDto> entities)
        {
            var entitties = _context.Cities.ToList();
            var Dtos = _mapper.Map<IEnumerable<DistrictDto>>(entities);
        }

        public void Update(DistrictDto dto)
        {
            var districtupt = _context.Districts.Where(district => district.Id == dto.Id).FirstOrDefault();

            if (districtupt != null)
            {
                districtupt.Name = dto.Name;
                districtupt.Location = dto.Location;

            }


            _context.SaveChanges();
        }
    }
}