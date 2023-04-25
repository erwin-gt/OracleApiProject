using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
   
    
        public static partial class MapperSuc
        {
            public static SucursalDTO ToDTO(this Sucursal model) //Convierte de ModelContext a DTO 
            {
                return new SucursalDTO()
                {
                    Id = model.Idsucursal,
                    Nombre = model.Nombre,
                    Direccion = model.Direccion,
                    Numero = model.Numero,
                    Email = model.Email,
                    IdTerritorio = model.Idterritorio

                };
            }
        }

        public static partial class MapperSuc
        {
            public static Sucursal ToDatabase(this SucursalDTO dto) // Converte de DTO a ModelContext
            {
                return new Sucursal()
                {
                    Idsucursal = dto.Id,
                    Nombre = dto.Nombre,
                    Direccion = dto.Direccion,
                    Numero = dto.Numero,
                    Email=dto.Email,
                    Idterritorio = dto.IdTerritorio
                };
            }
        }
    }

