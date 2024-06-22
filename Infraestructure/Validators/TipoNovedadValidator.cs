using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class TipoNovedadValidator : AbstractValidator<TipoNovedad>
    {
        public TipoNovedadValidator()
        {
            RuleFor(attribute => attribute.nombre).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato nombre es obligatorio");
                }

            });
        }
    }
}
