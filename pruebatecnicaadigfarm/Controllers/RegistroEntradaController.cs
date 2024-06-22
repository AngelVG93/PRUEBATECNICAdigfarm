using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces.services;
using Core.Server;
using FluentValidation;
using FluentValidation.Results;
using Infraestructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace pruebatecnicaadigfarm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroEntradaController : BaseController<RegistroEntrada,RegistroEntradaUpdateDto>
    {
        public readonly IMapper _mapper;
        public readonly IRegistroEntradaService _registroEntradaService;

        public RegistroEntradaController(IRegistroEntradaService registroEntradaService, IMapper mapper, IValidator<RegistroEntrada> validator, IValidator<RegistroEntradaUpdateDto> validatorDto) : base(validator, validatorDto)
        {
            _registroEntradaService = registroEntradaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarNovedades([FromQuery] decimal cedula)
        {
            var data = _mapper.Map<List<RegistroEntradaDto>>(await _registroEntradaService.ConsultarNovedades(cedula));
             return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] RegistroEntradaUpdateDto registroEntradaUpdateDto)
        {
            BadRequestObjectResult actionResult = await ValidateAsyncDto(registroEntradaUpdateDto);
            if (actionResult != null)
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
             return Ok(_mapper.Map<RegistroEntradaDto>(await _registroEntradaService.UpdateRegistroEntrada(_mapper.Map<RegistroEntrada>(registroEntradaUpdateDto))));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistroEntradaDto registroEntradaDto)
        {
            BadRequestObjectResult actionResult = await ValidateAsync(_mapper.Map<RegistroEntrada>(registroEntradaDto));
            if (actionResult != null)
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
            return Ok(_mapper.Map<RegistroEntradaDto>(await _registroEntradaService.AddRegistroEntrada(_mapper.Map<RegistroEntrada>(registroEntradaDto))));
        }

    }
}
