using AlliedHealth.DataAccess.Context;
using AlliedHealth.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliedHealth.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlliedHealthDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(AlliedHealthDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            City = new CityRepository(_context, _mapper);
            District = new DistrictRepository(_context, _mapper);
            Province = new ProvinceRepository(_context, _mapper);
        }
        public ICityRepository City { get; private set; }
        public IDistrictRepository District { get; private set; }
        public IProvinceRepository Province { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
