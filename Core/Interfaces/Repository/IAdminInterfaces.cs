
namespace Core.Interfaces.Repository
{
    public interface IAdminInterfaces : IDisposable
    {
        IEmpleadoRepository empleadoRepository { get; }
        IRegistroEntradaRepository registroEntradaRepository { get; }
        ITipoEmpledoRepository tipoEmpledoRepository { get; }
        ITipoNovedadRepository tipoNovedadRepository { get; }

        void saveChange();
        Task saveChangeAsync();
    }
}
