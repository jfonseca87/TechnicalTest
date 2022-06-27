using ReservasDTOs.Dtos;
using System.Threading.Tasks;

namespace ReservasRepository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDto> ObtenerUsuarioPorId(int usuarioId);
    }
}
