using AlliedHealth.Domain.DTOs;
using AlliedHealth.Domain.Entities;
using AlliedHealth.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlliedHealth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DistrictController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]

        public ActionResult Get()
        {
            var districtFromRepo = _unitOfWork.District.GetAll();
            return Ok(districtFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Getbycode(int id)
        {
            var districtFromRepo = _unitOfWork.District.GetById(id);
            return Ok(districtFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(DistrictDto data)
        {
            _unitOfWork.District.Add(data);

            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(DistrictDto data)
        {
            _unitOfWork.District.Update(data);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.District.Remove(id);

            return Ok();
        }
    }
}
