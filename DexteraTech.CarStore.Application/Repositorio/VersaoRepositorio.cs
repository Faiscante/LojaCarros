using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Application.Repositorio;

public class VersaoRepositorio : IVersaoRepositorio
{
    private readonly ApplicationDbContext _context;

    public VersaoRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public Versao Adicionar(Versao versao)
    {
        _context.Versaos.Add(versao);
        _context.SaveChanges();

        return versao;
    }

    public bool Apagar(int IdVersao)
    {
        var versaoDB = ListarPorId(IdVersao);

        if (versaoDB == null) throw new Exception("Houve um erro na exclusão da Versão");

        _context.Versaos.Remove(versaoDB);
        _context.SaveChanges();
        return true;
    }

    public Versao Atualizar(Versao versao)
    {
        _context.Versaos.Update(versao);
        _context.SaveChanges();
        return versao;
    }

    public List<Versao> BuscarTodos()
    {
        return _context.Versaos
            .Include(o => o.IdModeloNavigation)
            .Include(o => o.IdModeloNavigation.IdCarroceriaNavigation)
            .Include(o => o.IdModeloNavigation.IdMarcaNavigation)
            .ToList();
    }

    public Versao ListarPorId(int Id)
    {
        return _context.Versaos.FirstOrDefault(x => x.IdVersao == Id);
    }

    public List<Versao> ListarPorModelo(int Id)
    {
        return _context.Versaos.Where(x => x.IdModelo == Id).ToList();
    }
}