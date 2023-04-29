using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperUsr
    {
        public static UsuarioDTO ToDTO(this Usuario model)
        {
            return new UsuarioDTO()
            {
                Id = model.Idusuario,
                Pass = model.Contraseña,
                Email = model.Email,
                Permisos = model.Permisos,
                Rol = model.Rol,
                Status = model.Status,
                TipoUser = model.Idtipousuario


            };
        }
    }

    public static partial class MapperUsr
    {
        public static Usuario ToDatabase(this UsuarioDTO dto)
        {
            return new Usuario()
            {
                Idusuario = dto.Id,
                Contraseña = dto.Pass,
                Email = dto.Email,
                Permisos = dto.Permisos,
                Rol = dto.Rol,
                Status = dto.Status,
                Idtipousuario = dto.TipoUser

            };
        }
    }

}
