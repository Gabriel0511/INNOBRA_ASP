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

            CreateMap<EditarUnidadDTO, Unidad>();
            CreateMap<EditarItemRenglonTipoDTO, ItemTipoRenglon>();
            CreateMap<EditarItemTipoDTO, ItemTipo>();

            //STEFANO
            CreateMap<CrearAvanceDTO, Avance>();
            CreateMap<CrearRecursoDTO, Recurso>();

            CreateMap<EditarAvanceDTO, Avance>();
            CreateMap<EditarRecursoDTO, Recurso>();

            //GABRIEL
            CreateMap<CrearObraDTO, Obra>();
            CreateMap<CrearPresupuestoDTO, Presupuesto>();

            CreateMap<EditarObraDTO, Obra>();
            CreateMap<EditarPresupuestoDTO, Presupuesto>();

            //LUCIA
            CreateMap<CrearItemDTO, Item>();
            CreateMap<CrearItemRenglonDTO, ItemRenglon>();

            CreateMap<EditarItemDTO, Item>();
            CreateMap<EditarItemRenglonDTO, ItemRenglon>();
        }
    }
}
