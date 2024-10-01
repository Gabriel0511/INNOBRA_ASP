using AutoMapper;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Shared.DTO;

namespace INNOBRA_ASP.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //PABLO
            CreateMap <CrearItemRenglonTipoDTO, ItemTipoRenglon>();
            CreateMap<CrearItemTipoDTO, ItemTipo>();
            CreateMap<CrearUnidadDTO, Unidad>();

            //STEFANO
            CreateMap<CrearAvanceDTO, Avance>();
            CreateMap<CrearRecursoDTO, Recurso>();

            //GABRIEL
            CreateMap<CrearObraDTO, Obra>();
            CreateMap<CrearPresupuestoDTO, Presupuesto>();
        }
    }
}
