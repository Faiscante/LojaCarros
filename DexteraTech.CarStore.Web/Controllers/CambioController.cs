using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class CambioController : Controller
{
    public IActionResult Index()
    {
        var cambios = _cambioRepositorio.BuscarTodos();
        var cambioViewModel = _mapper.Map<List<CambioViewModel>>(cambios);

        return View(cambioViewModel);
    }

    [HttpGet]
    [Route("/Cambio/Editar/{idCambio?}")]
    public IActionResult Editar(int? idCambio)
    {
        try
        {
            CambioInputModel cambioViewModel;
            if (idCambio.HasValue && idCambio > 0)
            {
                var cambio = _cambioRepositorio.ListarPorId(idCambio.Value);
                cambioViewModel = _mapper.Map<CambioInputModel>(cambio);
            }
            else
            {
                cambioViewModel = new CambioInputModel();
            }

            return View(cambioViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(CambioInputModel cambioViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var cambio = _mapper.Map<Cambio>(cambioViewModel);

                if (cambio.IdCambio > 0)
                    cambio = _cambioRepositorio.Atualizar(cambio);
                else
                    cambio = _cambioRepositorio.Adicionar(cambio);

                this.AddMessage(Enums.State.Success, "Cambio salvo com sucesso");
                return RedirectToAction("Editar", new { cambio.IdCambio });
            }

            this.AddMessage(Enums.State.Error, "Ocorreu um erro ao salvar o cambio");
            return View(cambioViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(cambioViewModel);
        }
    }

    [HttpDelete]
    public IActionResult ExcluirCambio(int idCambio)
    {
        try
        {
            if (idCambio > 0)
            {
                _cambioRepositorio.Apagar(idCambio);
                return Ok("Cambio Excluido com Sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir o cambio");
        }

        return null;
    }

    #region Injeção de Dependencia Repositorio e Mapper

    private readonly ICambioRepositorio _cambioRepositorio;
    private readonly IMapper _mapper;

    public CambioController(ICambioRepositorio cambioRepositorio,
        IMapper mapper)
    {
        _cambioRepositorio = cambioRepositorio;
        _mapper = mapper;
    }

    #endregion
}