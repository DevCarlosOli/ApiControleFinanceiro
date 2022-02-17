using ApiControleFinanceiro.DTO;
using ApiControleFinanceiro.Entities;
using AutoMapper;

namespace ApiControleFinanceiro.Mapping
{
    public class PerfilMapping : Profile
    {
        public PerfilMapping()
        {
            CreateMap<SubcategoriaEntity, SubcategoriaDTO>()
                .ForMember(destino => destino.IdCategoria, mapear => 
                mapear.MapFrom(buscar => buscar.IdCategoria))
                .ReverseMap();

            CreateMap<LancamentoEntity, LancamentoDTO>()
                .ForMember(destino => destino.IdSubcategoria, mapear =>
                mapear.MapFrom(buscar => buscar.IdSubcategoria))
                .ReverseMap();
        }
    }
}
