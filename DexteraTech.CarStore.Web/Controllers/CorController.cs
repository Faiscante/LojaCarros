using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.ViewModel;
using DexteraTech.CarStore.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class CorController : Controller
{
    public IActionResult Index()
    {
        var cores = _corRepositorio.BuscarTodos();

        var corViewModel = _mapper.Map<List<CorViewModel>>(cores);

        return View(corViewModel);
    }

    [HttpGet]
    [Route("/Cor/Editar/{idCor?}")]
    public IActionResult Editar(int? idCor)
    {
        try
        {
            CorInputModel corViewModel;
            if (idCor.HasValue && idCor > 0)
            {
                var cor = _corRepositorio.ListarPorId(idCor.Value);
                corViewModel = _mapper.Map<CorInputModel>(cor);
            }
            else
            {
                corViewModel = new CorInputModel();
            }

            return View(corViewModel);
        }
        catch (Exception ex)
        {
            this.AddMessage(Enums.State.Error, "Registro Pesquisado não existe");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(CorInputModel corViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var cor = _mapper.Map<Cor>(corViewModel);

                if (cor.IdCor > 0)
                    cor = _corRepositorio.Atualizar(cor);
                else
                    cor = _corRepositorio.Adicionar(cor);

                this.AddMessage(Enums.State.Success, "Cor salva com sucesso");
                return RedirectToAction("Editar", new { cor.IdCor });
            }

            this.AddMessage(Enums.State.Error, "Ocorrou um erro ao salvar a marca");
            return View(corViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(corViewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult ExcluirCor(int idCor)
    {
        try
        {
            if (idCor > 0)
            {
                _corRepositorio.Apagar(idCor);
                return Ok("Cor Excluida com Sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir a cor");
        }

        return null;
    }

    #region Injeção de Dependencia Repositorio e Mapper

    private readonly ICorRepositorio _corRepositorio;
    private readonly IMapper _mapper;

    public CorController(ICorRepositorio corRepositorio,
        IMapper mapper)
    {
        _corRepositorio = corRepositorio;
        _mapper = mapper;
    }

    #endregion
}