using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReservasDTOs.Dtos;
using ReservasRepository.Interfaces;
using System.Threading.Tasks;

namespace ReservasRepository.Implementaciones
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ReservashotelContext _db;
        private readonly IMapper _mapper;

        public UsuarioRepository(ReservashotelContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> ObtenerUsuarioPorId(int usuarioId)
        {
            return _mapper.Map<UsuarioDto>(await _db.Usuario.FirstOrDefaultAsync(x => x.Idusuario == usuarioId));
        }
    }
}
