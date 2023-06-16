using AlliedHealth.Domain.DTOs;
using AlliedHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliedHealth.Domain
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CityDto, City>();
            CreateMap<City, CityDto>();

            CreateMap<DistrictDto, District>();
            CreateMap<District, DistrictDto>();

            CreateMap<ProvinceDto, Province>();
            CreateMap<Province, ProvinceDto>();
        }
    }
}
