using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class ModeloController : Controller
{
    public IActionResult Index()
    {
        //Recebe a lista da entidade modelo
        var modelos = _modeloRespositorio.BuscarTodos();

        //Usa o AutoMapper para mapear a lista de entidades para uma lista de ViewModels
        var modeloViewModel = _mapper.Map<List<ModeloViewModel>>(modelos);

        //Retorna os modelos mapeados
        return View(modeloViewModel);
    }

    [HttpGet]
    [Route("/Modelo/Editar/{idModelo?}")]
    public IActionResult Editar(int? idModelo)
    {
        CarregarViewBags();
        try
        {
            ModeloInputModel modeloViewModel;
            if (idModelo.HasValue && idModelo > 0)
            {
                var modelo = _modeloRespositorio.ListarPorId(idModelo.Value);
                modeloViewModel = _mapper.Map<ModeloInputModel>(modelo);
            }
            else
            {
                modeloViewModel = new ModeloInputModel();
            }

            return View(modeloViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(ModeloInputModel modeloViewModel)
    {
        CarregarViewBags();
        try
        {
            if (ModelState.IsValid)
            {
                var modelo = _mapper.Map<Modelo>(modeloViewModel);


                if (modelo.IdModelo > 0)
                    modelo = _modeloRespositorio.Atualizar(modelo);
                else
                    modelo = _modeloRespositorio.Adicionar(modelo);

                this.AddMessage(Enums.State.Success, "Modelo salvo com sucesso");
                return RedirectToAction("Editar", new { modelo.IdModelo });
            }

            this.AddMessage(Enums.State.Error, "Ocorreu um erro ao salvar o veículo");
            return View(modeloViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(modeloViewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult ExcluirModelo(int idModelo)
    {
        try
        {
            if (idModelo > 0)
            {
                _modeloRespositorio.Apagar(idModelo);
                return Ok("Foto excluida com sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir o veículo.");
        }

        return null;
    }

    private void CarregarViewBags()
    {
        ViewBag.IdMarca = _marcaRepositorio.BuscarTodos().ToSelectList("IdMarca", "NmMarca");
        ViewBag.IdCarroceria = _carroceriaRepositorio.BuscarTodos().ToSelectList("IdCarroceria", "NmCarroceria");
    }

    #region Injeção de Dependencia Repositorio e Mapper

    private readonly IModeloRepositorio _modeloRespositorio;
    private readonly IMarcaRepositorio _marcaRepositorio;
    private readonly ICarroceriaRepositorio _carroceriaRepositorio;
    private readonly IMapper _mapper;

    public ModeloController(IModeloRepositorio modeloRepositorio,
        IMarcaRepositorio marcaRepositorio,
        ICarroceriaRepositorio carroceriaRepositorio,
        IMapper mapper)
    {
        _modeloRespositorio = modeloRepositorio;
        _marcaRepositorio = marcaRepositorio;
        _carroceriaRepositorio = carroceriaRepositorio;
        _mapper = mapper;
    }

    #endregion
}