﻿using AutoMapper;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Shared.DTO;

namespace INNOBRA_ASP.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<CrearObraDTO, Obra>();

            //CreateMap<EditarObraDTO, Obra>();

            CreateMap <CrearItemRenglonTipoDTO, ItemTipoRenglon>();
            CreateMap<CrearItemTipoDTO, ItemTipo>();
            CreateMap<CrearUnidadDTO, Unidad>();
        }
    }
}
