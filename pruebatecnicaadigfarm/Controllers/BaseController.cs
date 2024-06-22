using AutoMapper;
using Core.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace pruebatecnicaadigfarm.Controllers
{
    public class BaseController<TEntity, TEntityDto> : ControllerBase
    {
        public readonly IValidator<TEntity> _validator;
        public readonly IValidator<TEntityDto> _validatorDto;
        public BaseController(IValidator<TEntity> validator, IValidator<TEntityDto> validatorDto)
        {
            _validator = validator;
            _validatorDto = validatorDto;   
        }

        protected async Task<BadRequestObjectResult> ValidateAsync(TEntity entity)
        {
            var validation = await _validator.ValidateAsync(entity);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Errors = validation.Errors
                }));
            }

            return null;
        }
        protected async Task<BadRequestObjectResult> ValidateAsyncDto(TEntityDto entityDto)
        {
            var validation = await _validatorDto.ValidateAsync(entityDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors?.Select(e => new ValidationResult()
                {
                    Errors = validation.Errors
                }));
            }

            return null;
        }

    }
}
