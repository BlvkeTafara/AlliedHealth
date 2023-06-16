using AlliedHealth.Domain.DTOs;
using AlliedHealth.Domain.Entities;
using AlliedHealth.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlliedHealth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var provinceFromRepo = _unitOfWork.Province.GetAll();
            return Ok(provinceFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var provinceFromRepo = _unitOfWork.Province.GetById(id);
            return Ok(provinceFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ProvinceDto data)
        {
            _unitOfWork.Province.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ProvinceDto data)
        {
            _unitOfWork.Province.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.Province.Remove(id);

            return Ok();
        }
    }
}