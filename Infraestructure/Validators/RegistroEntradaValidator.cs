using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Validators
{
    public class RegistroEntradaValidator : AbstractValidator<RegistroEntrada>
    {
        public RegistroEntradaValidator()
        {
            RuleFor(attribute => attribute.idEmpleado).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato idEmpleado es obligatorio");
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
