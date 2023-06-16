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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly AlliedHealthDbContext _context;
        private readonly IMapper _mapper;

        public ProvinceRepository(AlliedHealthDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ProvinceDto dto)
        {
            var entity = _mapper.Map<Province>(dto);
            _context.Provinces.Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<ProvinceDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<Province>>(dto);
            _context.Provinces.AddRange(entities);
        }

        public IEnumerable<ProvinceDto> GetAll()
        {
            var entities = _context.Provinces.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProvinceDto>>(entities);
            return Dtos;
        }

        public ProvinceDto GetById(int id)
        {

            var entity = _context.Provinces.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ProvinceDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var provincedel = _context.Provinces.Where(province => province.Id == id).FirstOrDefault();

            _context.Provinces.Remove(provincedel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ProvinceDto> entities)
        {
            var entitties = _context.Provinces.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProvinceDto>>(entities);
        }

        public void Update(ProvinceDto dto)
        {
            var provinceupt = _context.Provinces.Where(province => province.Id == dto.Id).FirstOrDefault();

            if (provinceupt != null)
            {
                provinceupt.Name = dto.Name;
                provinceupt.Location = dto.Location;
              
            }
            _context.SaveChanges();
        }
    }
}
