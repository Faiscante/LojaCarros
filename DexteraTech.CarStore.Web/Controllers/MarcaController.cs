using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class MarcaController : Controller
{
    public IActionResult Index()
    {
        //Recebe a Lista de entidades marcas
        var marcas = _marcaRespositorio.BuscarTodos();

        // Usa o AutoMapper para mapear a lista de entidades para uma lista de ViewModels
        var marcaViewModel = _mapper.Map<List<MarcaViewModel>>(marcas);

        //Retorna a lista de marcas mapeadas
        return View(marcaViewModel);
    }

    [HttpGet]
    [Route("/Marca/Editar/{idMarca?}")]
    public IActionResult Editar(int? idMarca)
    {
        try
        {
            MarcaInputModel marcaViewModel;
            if (idMarca.HasValue && idMarca > 0)
            {
                var marca = _marcaRespositorio.ListarPorId(idMarca.Value);
                marcaViewModel = _mapper.Map<MarcaInputModel>(marca);
            }
            else
            {
                marcaViewModel = new MarcaInputModel();
            }

            return View(marcaViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(MarcaInputModel marcaViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var marca = _mapper.Map<Marca>(marcaViewModel);

                if (marca.IdMarca > 0)
                    marca = _marcaRespositorio.Atualizar(marca);
                else
                    marca = _marcaRespositorio.Adicionar(marca);

                this.AddMessage(Enums.State.Success, "Marca salva com sucesso");
                return RedirectToAction("Editar", new { marca.IdMarca });
            }

            this.AddMessage(Enums.State.Error, "Ocorrou um erro ao salvar a marca");
            return View(marcaViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(marcaViewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult ExcluirMarca(int idMarca)
    {
        try
        {
            if (idMarca > 0)
            {
                _marcaRespositorio.Apagar(idMarca);
                return Ok("Marca Excluida com Sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir a marca.");
        }

        return null;
    }

    #region Injeção de Dependencia Repositorio e Mapper

    //Realiza a injeção de dependecia do Repositorio e do Mapper
    private readonly IMarcaRepositorio _marcaRespositorio;
    private readonly IMapper _mapper;

    public MarcaController(IMarcaRepositorio marcaRepositorio,
        IMapper mapper)
    {
        _marcaRespositorio = marcaRepositorio;
        _mapper = mapper;
    }

    #endregion
}