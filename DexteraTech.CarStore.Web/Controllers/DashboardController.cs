using AutoMapper;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IFotoRepositorio _fotoRepositorio;
        private readonly IMapper _mapper;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly ICambioRepositorio _cambioRepositorio;
        private readonly ICarroceriaRepositorio _carroceriaRepositorio;

        public DashboardController(IFotoRepositorio fotoRepositorio,
            IVeiculoRepositorio veiculoRepositorio,
            IMapper mapper, ICarroceriaRepositorio carroceriaRepositorio, ICambioRepositorio cambioRepositorio)
        {
            _fotoRepositorio = fotoRepositorio;
            _veiculoRepositorio = veiculoRepositorio;
            _mapper = mapper;
            _carroceriaRepositorio = carroceriaRepositorio;
            _cambioRepositorio = cambioRepositorio;
        }
        public IActionResult Index()
        {
            var dashboardViewModel = new DashboardViewModel
            {
                QtdCambios = _cambioRepositorio.BuscarTodos().Count,
                QtdCarrocerias = _carroceriaRepositorio.BuscarTodos().Count,
                QtdVeiculos = _veiculoRepositorio.BuscarTodos().Count,
                QtdVeiculosVendas = _veiculoRepositorio.BuscarTodos().Count(x => x.ExibirVitrine),
                VlrTotalVeiculos = (decimal)_veiculoRepositorio.BuscarTodos().Sum(x=> x.VlrVeiculo)
            };

            return View(dashboardViewModel);
        }
    }
}
