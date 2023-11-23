using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class CarroceriaController : Controller
{
    public IActionResult Index()
    {
        //Recebe a Lista de entidades carroceria 
        var carrocerias = _carroceriaRespositorio.BuscarTodos();

        //Usa o AutoMapper para mapear a lista de entidades para uma lista de view models
        var carroceriaViewModel = _mapper.Map<List<CarroceriaViewModel>>(carrocerias);

        //Retorna a lista de carrocerias mapeadas
        return View(carroceriaViewModel);
    }

    [HttpGet]
    [Route("/Carroceria/Editar/{idCarroceria?}")]
    public IActionResult Editar(int? idCarroceria)
    {
        try
        {
            CarroceriaInputModel carroceriaViewModel;
            if (idCarroceria.HasValue && idCarroceria > 0)
            {
                var carroceria = _carroceriaRespositorio.ListarPorId(idCarroceria.Value);
                carroceriaViewModel = _mapper.Map<CarroceriaInputModel>(carroceria);
            }
            else
            {
                carroceriaViewModel = new CarroceriaInputModel();
            }

            return View(carroceriaViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Editar(CarroceriaInputModel carroceriaViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var carroceria = _mapper.Map<Carroceria>(carroceriaViewModel);

                if (carroceria.IdCarroceria > 0)
                    carroceria = _carroceriaRespositorio.Atualizar(carroceria);
                else
                    carroceria = _carroceriaRespositorio.Adicionar(carroceria);

                this.AddMessage(Enums.State.Success, "Carroceria salva com sucesso");
                return RedirectToAction("Editar", new { carroceria.IdCarroceria });
            }

            this.AddMessage(Enums.State.Error, "Ocorrou um erro ao salvar a marca");
            return View(carroceriaViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(carroceriaViewModel);
        }

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult ExcluirCarroceria(int idCarroceria)
    {
        try
        {
            if (idCarroceria > 0)
            {
                _carroceriaRespositorio.Apagar(idCarroceria);
                return Ok("Carroceria Excluida com Sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir a carroceria");
        }

        return null;
    }

    #region Injeção de Dependencia Repositorio e Mapper

    //Realiza a injeção de dependencia do Repositorio e do Mapper
    private readonly ICarroceriaRepositorio _carroceriaRespositorio;
    private readonly IMapper _mapper;

    public CarroceriaController(ICarroceriaRepositorio carroceriaRepositorio,
        IMapper mapper)
    {
        _carroceriaRespositorio = carroceriaRepositorio;
        _mapper = mapper;
    }

    #endregion
}