using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Models.SelectItems;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Extensions;
using DexteraTech.CarStore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class VeiculoController : Controller
{
    public IActionResult Index()
    {
        var veiculos = _veiculoRepositorio.BuscarTodos();
        var fotos = _fotoRepositorio.BuscarTodos();

        var veiculoViewModel = _mapper.Map<List<VeiculoViewModel>>(veiculos);

        return View(veiculoViewModel);
    }

    [HttpGet]
    [Route("/Veiculo/Editar/{idVeiculo?}")]
    public IActionResult Editar(int? idVeiculo)
    {
        CarregarViewBags();
        try
        {
            VeiculoInputModel veiculoViewModel;
            if (idVeiculo.HasValue && idVeiculo > 0)
            {
                var veiculo = _veiculoRepositorio.ListarPorId(idVeiculo.Value);
                veiculoViewModel = _mapper.Map<VeiculoInputModel>(veiculo);
                veiculoViewModel.Fotos = _fotoRepositorio.ListarPorVeiculo(idVeiculo.Value);
            }
            else
            {
                veiculoViewModel = new VeiculoInputModel();
            }

            return View(veiculoViewModel);
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Registro pesquisado não existe");
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Editar(VeiculoInputModel veiculoViewModel)
    {
        CarregarViewBags();
        try
        {
            ModelState.Merge(veiculoViewModel.Validate());

            if (ModelState.IsValid)
            {
                var veiculo = _mapper.Map<Veiculo>(veiculoViewModel);


                if (veiculo.IdVeiculo > 0)
                    veiculo = _veiculoRepositorio.Atualizar(veiculo);
                else
                    veiculo = _veiculoRepositorio.Adicionar(veiculo);

                this.AddMessage(Enums.State.Success, "Veículo salvo com sucesso");
                return RedirectToAction("Editar", new { veiculo.IdVeiculo });
            }

            this.AddMessage(Enums.State.Error, "Ocorreu um erro ao salvar o veículo");
            return View(veiculoViewModel);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(e.Message, e.Message);
            return View(veiculoViewModel);
        }

        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult UploadImages(List<IFormFile>? Imagens, int IdVeiculo)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Foto imagem;
                if (Imagens.Count > 0)
                {
                    foreach (var formFile in Imagens)
                    {
                        imagem = new Foto();
                        imagem.IdVeiculo = IdVeiculo;

                        if (formFile != null && formFile.Length > 0)
                        {
                            imagem.NmArquivo = formFile.FileName;

                            using (var stream = new MemoryStream())
                            {
                                formFile.CopyTo(stream);
                                imagem.Imagen = stream.ToArray();
                            }

                            _fotoRepositorio.Upload(imagem);
                        }
                    }

                    this.AddMessage(Enums.State.Success, "Fotos cadastradas com sucesso");
                }
            }
        }
        catch (Exception e)
        {
            this.AddMessage(Enums.State.Error, "Erro ao cadastrar foto");
        }

        return RedirectToAction("Editar", new { IdVeiculo });
    }

    [HttpDelete]
    public IActionResult ExcluirFoto(int idVeiculo, int idFoto)
    {
        try
        {
            if (idVeiculo > 0 && idFoto > 0)
            {
                var toDelete = _fotoRepositorio.ListarPorId(idFoto);
                if (toDelete.IdVeiculo != idVeiculo)
                    BadRequest("Foto não pertence ao veículo");

                _fotoRepositorio.Apagar(idFoto);

                return Ok("Foto excluida com sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return null;
    }

    [HttpDelete]
    public IActionResult ExcluirVeiculo(int idVeiculo)
    {
        try
        {
            if (idVeiculo > 0)
            {
                _veiculoRepositorio.Apagar(idVeiculo);
                return Ok("Foto excluida com sucesso");
            }
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao excluir o veículo.");
        }

        return null;
    }

    public JsonResult ListarMarcaModelo(int IdMarca)
    {
        var lista = _modeloRepositorio.ListarPorMarca(IdMarca);

        return Json(lista);
    }

    public JsonResult ListarModeloVersao(int IdModelo)
    {
        var lista = _versaoRepositorio.ListarPorModelo(IdModelo);

        return Json(lista);
    }

    private void CarregarViewBags()
    {
        ViewBag.IdModelo = _modeloRepositorio.BuscarTodos().ToSelectList("IdModelo", "NmModelo");
        ViewBag.IdMarca = _marcaRepositorio.BuscarTodos().ToSelectList("IdMarca", "NmMarca");
        ViewBag.IdVersao = _versaoRepositorio.BuscarTodos().ToSelectList("IdVersao", "NmVersao");
        ViewBag.IdCor = _corRepositorio.BuscarTodos().ToSelectList("IdCor", "NmCor");
        ViewBag.IdCambio = _cambioRepositorio.BuscarTodos().ToSelectList("IdCambio", "NmCambio");
        ViewBag.SimNao = SimNao.Options();
    }

    #region Injetor de Dependencia Repositorio e Mapper

    private readonly IVeiculoRepositorio _veiculoRepositorio;
    private readonly IVersaoRepositorio _versaoRepositorio;
    private readonly ICorRepositorio _corRepositorio;
    private readonly ICambioRepositorio _cambioRepositorio;
    private readonly IModeloRepositorio _modeloRepositorio;
    private readonly IMarcaRepositorio _marcaRepositorio;
    private readonly ICarroceriaRepositorio _carroceriaRepositorio;
    private readonly IFotoRepositorio _fotoRepositorio;
    private readonly IMapper _mapper;

    public VeiculoController(IVeiculoRepositorio veiculoRepositorio,
        IVersaoRepositorio versaoRepositorio,
        ICorRepositorio corRepositorio,
        ICambioRepositorio cambioRepositorio,
        IMarcaRepositorio marcaRepositorio,
        IModeloRepositorio modeloRepositorio,
        ICarroceriaRepositorio carroceriaRepositorio,
        IFotoRepositorio fotoRepositorio,
        IMapper mapper)
    {
        _veiculoRepositorio = veiculoRepositorio;
        _versaoRepositorio = versaoRepositorio;
        _corRepositorio = corRepositorio;
        _cambioRepositorio = cambioRepositorio;
        _marcaRepositorio = marcaRepositorio;
        _modeloRepositorio = modeloRepositorio;
        _carroceriaRepositorio = carroceriaRepositorio;
        _fotoRepositorio = fotoRepositorio;
        _mapper = mapper;
    }

    #endregion
}