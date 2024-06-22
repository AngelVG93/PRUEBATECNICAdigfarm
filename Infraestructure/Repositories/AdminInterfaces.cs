using Core.Interfaces.Repository;
using Persistence.Data;

namespace Infraestructure.Repositories
{
    public class AdminInterfaces : IAdminInterfaces
    {
        public pruebatecnicaDbContext _context;
        public AdminInterfaces(pruebatecnicaDbContext context)
        {
            _context = context;
        }
        private readonly IEmpleadoRepository? _empleadoRepository;
        private readonly IRegistroEntradaRepository? _registroEntradaRepository;
        private readonly ITipoEmpledoRepository? _tipoEmpledoRepository;
        private readonly ITipoNovedadRepository? _tipoNovedadRepository;
        public IEmpleadoRepository empleadoRepository => _empleadoRepository ?? new EmpleadoRepository(_context);

        public IRegistroEntradaRepository registroEntradaRepository => _registroEntradaRepository ?? new RegistroEntradaRepository(_context);

        public ITipoEmpledoRepository tipoEmpledoRepository => _tipoEmpledoRepository ?? new TipoEmpledoRepository(_context);

        public ITipoNovedadRepository tipoNovedadRepository => _tipoNovedadRepository ?? new TipoNovedadRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChange()
        {
            _context.SaveChanges();
        }

        public async Task saveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
