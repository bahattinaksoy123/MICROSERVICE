using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/platformservice/v1/[controller]")]
    [ApiController]
    public class PlatformController(IPlatformRepo repo, IMapper mapper, ICommandDataClient commandDataClient) : ControllerBase
    {
        private readonly IPlatformRepo _repo = repo;
        private readonly IMapper _mapper = mapper;
        private readonly ICommandDataClient _commandDataClient = commandDataClient;

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
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO createDTO)
        {
            var platform = _mapper.Map<Platform>(createDTO);
            _repo.CreatePlatform(platform);

            var readDTO = _mapper.Map<PlatformReadDTO>(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(readDTO);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"---> Could not send platform to command synchronously {ex.Message}");
            }

            return CreatedAtAction(nameof(GetPlatformById), new {id = readDTO.Id}, readDTO);
        }
    }
}