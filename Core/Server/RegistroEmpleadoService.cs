using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Enumerations;
using Core.Exceptions;
using Core.Interfaces.Repository;
using Core.Interfaces.services;
using System.Net.WebSockets;

namespace Core.Server
{
    public class RegistroEmpleadoService : BaseService<RegistroEmpleado, RegistroEmpleadoDto>, IRegistroEmpleadoService
    {
        public RegistroEmpleadoService(IMapper mapper, IAdminInterfaces adminInterfaces) : base(mapper, adminInterfaces)
        {

        }

        public async Task<RegistroEmpleado> UpdateRegistroEntrada(RegistroEmpleado registroEntrada)
        {
            var buscarRegistroEntrada = await _adminInterfaces.registroEntradaRepository.GetById(registroEntrada.idRegistroEntrada);
            if (buscarRegistroEntrada == null)
            {
                LogException logException = new LogException();
                logException.Name = "RegistroEntradaService";
                logException.Message = "No se encontro el dato idRegistroEntrada";
                throw new NotFoundException(logException);
            }
            buscarRegistroEntrada.descripcion = registroEntrada.descripcion;
            buscarRegistroEntrada.idTipoNovedad = registroEntrada.idTipoNovedad;
            var result = await _adminInterfaces.registroEntradaRepository.UpdateAsync(buscarRegistroEntrada);
            await _adminInterfaces.saveChangeAsync();  
            return result;
        }

        public async Task<List<RegistroEmpleado>> ConsultarNovedades(decimal cedula)
        {
            return await _adminInterfaces.registroEntradaRepository.ConsultarNovedades(cedula);
        }

        public async Task<RegistroEmpleado> AddRegistroEntrada(RegistroEmpleado registroEntrada)
        {
            var empleado = await _adminInterfaces.empleadoRepository.GetById(registroEntrada.idEmpleado);
            if (empleado == null )
            {
                LogException logException = new LogException();
                logException.Name = "RegistroEntradaService";
                logException.Message = "No se encontró el dato idEmpleado";
                throw new NotFoundException(logException);
            }
            if (registroEntrada.idTipoNovedad != 0 && registroEntrada.idTipoNovedad != null)
            {
                if (await _adminInterfaces.tipoNovedadRepository.GetById((int)registroEntrada.idTipoNovedad) == null)
                {
                    LogException logException = new LogException();
                    logException.Name = "RegistroEntradaService";
                    logException.Message = "No se encontró el dato idTipoNovedad";
                    throw new NotFoundException(logException);
                }
            }

            if (registroEntrada.horaEntrada != null)
            {
                var fechaRestaEntrada = registroEntrada.horaEntrada.Value - empleado.horaEntrada;
                if (fechaRestaEntrada.Minutes > 0 )
                {
                    registroEntrada.idTipoNovedad = (int)TipoNovedadEnum.Ausencia;
                    registroEntrada.horas = CalcularHoras(fechaRestaEntrada.Minutes);
                }
            }

            if (registroEntrada.horaSalida != null)
            {
                var fechaRestaSalida = registroEntrada.horaSalida.Value - empleado.horaSalida;
                if (fechaRestaSalida.Minutes > 30)
                {
                    registroEntrada.horas = CalcularHoras(fechaRestaSalida.Minutes);
                    registroEntrada.idTipoNovedad = (int)TipoNovedadEnum.HorasExtras;
                }
            }

            if (registroEntrada.horaSalida == null && registroEntrada.horaEntrada.Value == null)
            {
                LogException logException = new LogException();
                logException.Name = "RegistroEntradaService";
                logException.Message = "Ingrese fecha y hora de entrada | salida";
                throw new BadRequestBusinessException(logException);
            }

            registroEntrada.fechaNovedad = DateTime.Now;
            var result = await _adminInterfaces.registroEntradaRepository.Add(registroEntrada);

            if (registroEntrada.idTipoNovedad != 0 && registroEntrada.idTipoNovedad != null) {
                await _adminInterfaces.saveChangeAsync();
            }
            else
            {
                LogException logException = new LogException();
                logException.Name = "RegistroEntradaService";
                logException.Message = "No se creó novedad ya que no se especificó tipo de novedad ";
                throw new BadRequestBusinessException(logException);
            }
            return result;
        }
        private decimal CalcularHoras(int minutos)
        {
             return (decimal)minutos / 60;
        }
    }
}
