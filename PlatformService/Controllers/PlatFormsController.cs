using System.IO;
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
namespace PlatformService.Controllers
{
    [Route("api/[controller]")] // [controller] lay ten cua class thay the cho [controller] tao ra 1 dinh tuyen hoan chinh
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

        [HttpGet("{id}", Name = "GetPlatFormsById")]
        public ActionResult<PlatFormReadDto> GetPlatFormsById(int id)
        {
            Console.WriteLine("---> Get data ....");
            var platForm = _repository.GetPlatformById(id);
            if (platForm != null)
            {
                return Ok(_mapper.Map<PlatFormReadDto>(platForm));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatFormReadDto> Post(PlatFormCreateDto platForm)
        {
            var platFormModel = _mapper.Map<Platform>(platForm);
            _repository.CreatePlatForm(platFormModel);
            _repository.SaveChanges();

            var platFormReadDto = _mapper.Map<PlatFormReadDto>(platFormModel);
            
            return CreatedAtRoute(nameof(GetPlatFormsById), new { Id = platFormReadDto.Id }, platFormReadDto);
        }
    }
}
