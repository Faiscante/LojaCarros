using AutoMapper;
using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Controllers;

[Authorize]
public class FotoController : Controller
{
    private readonly IFotoRepositorio _fotoRepositorio;
    private readonly IMapper _mapper;
    private readonly IVeiculoRepositorio _veiculoRepositorio;

    public FotoController(IFotoRepositorio fotoRepositorio,
        IVeiculoRepositorio veiculoRepositorio,
        IMapper mapper)
    {
        _fotoRepositorio = fotoRepositorio;
        _veiculoRepositorio = veiculoRepositorio;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Criar(List<IFormFile> fotos)
    {
        if (fotos != null && fotos.Count > 0)
        {
            foreach (var foto in fotos)
                if (foto.Length > 0)
                    using (var memoryStream = new MemoryStream())
                    {
                        // Copiar o conteúdo da foto para a MemoryStream
                        foto.CopyTo(memoryStream);

                        // Salvar a foto como dados de byte no banco de dados
                        var novaFoto = new Foto
                        {
                            Imagen = memoryStream.ToArray(),
                            NmArquivo = foto.FileName
                        };

                        // Adicionar a nova foto ao banco de dados
                        _fotoRepositorio.Upload(novaFoto);
                        // Lógica adicional, se necessário
                    }

            return Ok(new { Message = "Fotos enviadas com sucesso!" });
        }

        return BadRequest(new { Message = "Nenhuma foto foi recebida." });
    }
}