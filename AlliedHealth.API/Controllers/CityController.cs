using AlliedHealth.Domain.DTOs;
using AlliedHealth.Domain.Entities;
using AlliedHealth.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlliedHealth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var cityFromRepo = _unitOfWork.City.GetAll();
            return Ok(cityFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var cityFromRepo = _unitOfWork.City.GetById(id);
            return Ok(cityFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(CityDto data)
        {
            _unitOfWork.City.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(CityDto data)
        {
            _unitOfWork.City.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.City.Remove(id);

            return Ok();
        }
    }
}
