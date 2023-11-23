using AutoMapper;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[AllowAnonymous]
public class VitrineController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var veiculos = _veiculoRepositorio.BuscarTodoComFotosParaVenda();

        var veiculoViewModel = _mapper.Map<List<VeiculoViewModel>>(veiculos);

        return View(veiculoViewModel);
    }

    [HttpGet]
    [Route("/Vitrine/Detalhes/{IdVeiculo?}")]
    public IActionResult Detalhes(int? idVeiculo)
    {
        VeiculoViewModel veiculoViewModel;

        var veiculo = _veiculoRepositorio.ListarPorId(idVeiculo.Value);
        veiculoViewModel = _mapper.Map<VeiculoViewModel>(veiculo);
        veiculoViewModel.Fotos = _fotoRepositorio.ListarPorVeiculo(idVeiculo.Value);

        return View(veiculoViewModel);
    }

    #region Injetor de Dependencia Repositorio e Mapper

    private readonly IVeiculoRepositorio _veiculoRepositorio;
    private readonly IFotoRepositorio _fotoRepositorio;
    private readonly IMapper _mapper;

    public VitrineController(IVeiculoRepositorio veiculoRepositorio,
        IFotoRepositorio fotoRepositorio,
        IMapper mapper)
    {
        _veiculoRepositorio = veiculoRepositorio;
        _fotoRepositorio = fotoRepositorio;
        _mapper = mapper;
    }

    #endregion
}