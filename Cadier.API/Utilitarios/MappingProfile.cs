using AutoMapper;
using Cadier.API.ViewModels.PessoaFisicaViewModels;
using Cadier.Model.Models;

namespace Cadier.API.Utilitarios
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<GetFiliadosToGridViewModel, PFisica>()
                .ForMember(dst => dst.IdPFisica, map => map.MapFrom(src => src.NumeroRol))
                .ForMember(dst => dst.DocumentoIdentificacaoSocial, map => map.MapFrom(src => src.Documento))
                .ForMember(dst => dst.PessoaJuridica, map => map.MapFrom(src => new PJuridica() { IdPJuridica = src.NumeroRolIgreja.HasValue ? src.NumeroRolIgreja.Value : 0, Nome = src.NomeIgreja }))
                .ForMember(dst => dst.Endereco, map => map.MapFrom(src => new Endereco() { Cidade = src.Cidade, Estado = src.Estado, Pais = src.Pais }))
                .ForMember(dst => dst.SituacaoCadastral, map => map.MapFrom(src => new SituacaoCadastral() { Condicao = src.Condicao.HasValue ? src.Condicao.Value : null, EFiliado = src.Filiado }));
        }
    }
}