using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class TipoEmpledoValidator : AbstractValidator<TipoEmpledo>
    {
        public TipoEmpledoValidator()
        {
            RuleFor(attribute => attribute.nombre).Custom((st, context) =>
            {
                if (st == String.Empty || st == null)
                {
                    context.AddFailure("EL dato idTipoNovedad es obligatorio");
                }

            });
        }
    }
}
