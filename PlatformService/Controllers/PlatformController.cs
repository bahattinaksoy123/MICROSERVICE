using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class PlatformController(IPlatformRepo repo, IMapper mapper) : ControllerBase
    {
        private readonly IPlatformRepo _repo = repo;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("----> Getting Platforms");

            var platforms = _repo.GetAllPlatforms();
            var dtos = _mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platform = _repo.GetPlatformById(id);
            var dto = _mapper.Map<PlatformReadDTO>(platform);
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO createDTO)
        {
            var platform = _mapper.Map<Platform>(createDTO);
            _repo.CreatePlatform(platform);

            var readDTO = _mapper.Map<PlatformReadDTO>(platform);
            return CreatedAtAction(nameof(GetPlatformById), new {id = readDTO.Id}, readDTO);
        }
    }
}