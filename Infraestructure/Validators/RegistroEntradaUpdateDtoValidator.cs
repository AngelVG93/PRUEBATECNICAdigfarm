using Core.DTOs;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class RegistroEntradaUpdateDtoValidator : AbstractValidator<RegistroEntradaUpdateDto>
    {
        public RegistroEntradaUpdateDtoValidator()
        {
            RuleFor(attribute => attribute.idRegistroEntrada).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato idRegistroEntrada es obligatorio");
                }

            });
            RuleFor(attribute => attribute.idTipoNovedad).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato idTipoNovedad es obligatorio");
                }

            });
            RuleFor(attribute => attribute.descripcion).Custom((st, context) =>
            {
                if (st == null || st == String.Empty)
                {
                    context.AddFailure("EL dato descripcion es obligatorio");
                }

            });
        }
    }
}
