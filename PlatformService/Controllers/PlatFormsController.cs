using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]  // [controller] lay ten cua class thay the cho [controller] tao ra 1 dinh tuyen hoan chinh
    [ApiController]
    public class PlatFormsController : ControllerBase
    {
        private readonly IPlatFormRepo _repository;
        private IMapper _mapper;

        public PlatFormsController(IPlatFormRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatFormReadDto>> GetPlatForms()
        {
            Console.WriteLine("---> Get data ....");
            var platForm = _repository.GetAllFlatForm();
            return Ok(_mapper.Map<IEnumerable<PlatFormReadDto>>(platForm));
        } 
    }
}