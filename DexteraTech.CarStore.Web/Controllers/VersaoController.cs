using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class VersaoController : Controller
{
    public IActionResult Index()
    {
        var versaos = _versaoRespositorio.BuscarTodos();

        var versaoViewModel = _mapper.Map<List<VersaoViewModel>>(versaos);

        return View(versaoViewModel);
    }

    [HttpGet]
    [Route("/Versao/Editar/{idVersao?}")]
    public IActionResult Editar(int? idVersao)
    {
        CarregarViewBags();
        try
        {
            VersaoInputModel versaoViewModel;
            if (idVersao.HasValue && idVersao > 0)
            {
                var versao = _versaoRespositorio.ListarPorId(idVersao.Value);
                versaoViewModel = _mapper.Map<VersaoInputModel>(versao);
            }
            else
            {
                versaoViewModel = new VersaoInputModel();
            }

            return View(versaoViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(VersaoInputModel versaoViewModel)
    {
        CarregarViewBags();
        try
        {
            if (ModelState.IsValid)
            {
                var versao = _mapper.Map<Versao>(versaoViewModel);

                if (versao.IdVersao > 0)
                    versao = _versaoRespositorio.Atualizar(versao);
                else
                    versao = _versaoRespositorio.Adicionar(versao);

                this.AddMessage(Enums.State.Success, "Versao salvo com sucesso");
                return RedirectToAction("Editar", new { versao.IdVersao });
            }

            this.AddMessage(Enums.State.Error, "Ocorreu um erro ao salvar a versão");
            return View(versaoViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(versaoViewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult ExcluirVersao(int idVersao)
    {
        try
        {
            if (idVersao > 0)
            {
                _versaoRespositorio.Apagar(idVersao);
                return Ok("Versao excluida com sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir a versao");
        }

        return null;
    }

    private void CarregarViewBags()
    {
        ViewBag.IdModelo = _modeloRespositorio.BuscarTodos().ToSelectList("IdModelo", "NmModelo");
    }

    #region Injeção de Dependencia Repositorio e Mapper

    private readonly IVersaoRepositorio _versaoRespositorio;
    private readonly IModeloRepositorio _modeloRespositorio;
    private readonly IMarcaRepositorio _marcaRepositorio;
    private readonly ICarroceriaRepositorio _carroceriaRepositorio;
    private readonly IMapper _mapper;

    public VersaoController(IVersaoRepositorio versaoRespositorio,
        IModeloRepositorio modeloRepositorio,
        IMarcaRepositorio marcaRepositorio,
        ICarroceriaRepositorio carroceriaRepositorio,
        IMapper mapper)
    {
        _versaoRespositorio = versaoRespositorio;
        _modeloRespositorio = modeloRepositorio;
        _marcaRepositorio = marcaRepositorio;
        _carroceriaRepositorio = carroceriaRepositorio;
        _mapper = mapper;
    }

    #endregion
}