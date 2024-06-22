using Core.Entities;
using FluentValidation;

namespace Infraestructure.Validators
{
    public class EmpleadoValidator : AbstractValidator<Empleado>
    {
        public EmpleadoValidator()
        {
            RuleFor(attribute => attribute.nombre).Custom((st, context) =>
            {
                if (st == "")
                {
                    context.AddFailure("EL dato nombre es obligatorio");
                }

            });
            RuleFor(attribute => attribute.cedula).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato cedula es obligatorio");
                }

            });
            RuleFor(attribute => attribute.estado).Custom((st, context) =>
            {
                if (st == null)
                {
                    context.AddFailure("EL dato estado es obligatorio");
                }

            });
            RuleFor(attribute => attribute.horaEntrada).Custom((st, context) =>
            {
                if (st == null)
                {
                    context.AddFailure("EL dato horaEntrada es obligatorio");
                }

            });
            RuleFor(attribute => attribute.horaSalida).Custom((st, context) =>
            {
                if (st == null)
                {
                    context.AddFailure("EL dato horaSalida es obligatorio");
                }

            });
            RuleFor(attribute => attribute.idTipoEmpleado).Custom((st, context) =>
            {
                if (st == 0)
                {
                    context.AddFailure("EL dato idTipoEmpleado es obligatorio");
                }

            });
        }
    }
}
