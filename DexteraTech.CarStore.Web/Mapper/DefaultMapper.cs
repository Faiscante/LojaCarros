using AutoMapper;
using DexteraTech.CarStore.Application.Extensions;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Web.Models;
using DexteraTech.CarStore.Web.ViewModel;

namespace DexteraTech.CarStore.Web.Mapper;

public class DefaultMapper : Profile
{
    public DefaultMapper()
    {
        CreateMap<Cambio, CambioViewModel>().ReverseMap();
        CreateMap<Cambio, CambioInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Carroceria, CarroceriaViewModel>().ReverseMap();
        CreateMap<Carroceria, CarroceriaInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Cor, CorViewModel>().ReverseMap();
        CreateMap<Cor, CorInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Foto, FotoViewModel>().ReverseMap();

        CreateMap<Marca, MarcaViewModel>().ReverseMap();
        CreateMap<Marca, MarcaInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Modelo, ModeloViewModel>().ReverseMap();
        CreateMap<Modelo, ModeloInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Versao, VersaoViewModel>().ReverseMap();
        CreateMap<Versao, VersaoInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();

        CreateMap<Veiculo, VeiculoViewModel>().ReverseMap();
        CreateMap<Veiculo, VeiculoInputModel>()
            .IgnoreNonExistingMembers()
            .ReverseMap();
    }
}