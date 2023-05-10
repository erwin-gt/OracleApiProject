using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperPues
    {
        public static PuestoDTO ToDTO(this Puesto model) //Convierte de ModelContext a DTO 
        {
            return new PuestoDTO()
            {
                Idpuesto = model.Idpuesto,
                Nombrepuesto = model.Nombrepuesto,
                Departamento = model.Departamento,
                Niveljuridico = model.Niveljuridico,
                Salario = model.Salario,
            };
        }
    }

    public static partial class MapperPues
    {
        public static Puesto ToDatabase(this PuestoDTO dto) // Converte de DTO a ModelContext
        {
            return new Puesto()
            {
                Idpuesto = dto.Idpuesto,
                Nombrepuesto = dto.Nombrepuesto,
                Departamento = dto.Departamento,
                Niveljuridico  = dto.Niveljuridico,
                Salario = dto.Salario,
            };
        }
    }
}
