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
    public class RegistroEntradaController : BaseController<RegistroEmpleado,RegistroEmpleadoUpdateDto>
    {
        public readonly IMapper _mapper;
        public readonly IRegistroEmpleadoService _registroEntradaService;

        public RegistroEntradaController(IRegistroEmpleadoService registroEntradaService, IMapper mapper, IValidator<RegistroEmpleado> validator, IValidator<RegistroEmpleadoUpdateDto> validatorDto) : base(validator, validatorDto)
        {
            _registroEntradaService = registroEntradaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarNovedades([FromQuery] decimal cedula)
        {
            var data = _mapper.Map<List<RegistroEmpleadoDto>>(await _registroEntradaService.ConsultarNovedades(cedula));
             return Ok(data);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] RegistroEmpleadoUpdateDto registroEntradaUpdateDto)
        {
            BadRequestObjectResult actionResult = await ValidateAsyncDto(registroEntradaUpdateDto);
            if (actionResult != null)
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
             return Ok(_mapper.Map<RegistroEmpleadoDto>(await _registroEntradaService.UpdateRegistroEntrada(_mapper.Map<RegistroEmpleado>(registroEntradaUpdateDto))));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistroEmpleadoDto registroEntradaDto)
        {
            BadRequestObjectResult actionResult = await ValidateAsync(_mapper.Map<RegistroEmpleado>(registroEntradaDto));
            if (actionResult != null)
                if (actionResult.StatusCode == 400)
                {
                    return Ok(actionResult.Value);
                }
            return Ok(_mapper.Map<RegistroEmpleadoDto>(await _registroEntradaService.AddRegistroEntrada(_mapper.Map<RegistroEmpleado>(registroEntradaDto))));
        }

    }
}
