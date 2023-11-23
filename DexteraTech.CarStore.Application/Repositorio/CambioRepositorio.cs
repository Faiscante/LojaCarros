using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;

namespace DexteraTech.CarStore.Application.Repositorio;

public class CambioRepositorio : ICambioRepositorio
{
    private readonly ApplicationDbContext _context;

    public CambioRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public Cambio Adicionar(Cambio cambio)
    {
        var cambioDB = ListarPorId(cambio.IdCambio);

        _context.Cambios.Add(cambio);
        _context.SaveChanges();

        return cambio;
    }

    public bool Apagar(int IdCambio)
    {
        var cambioDB = ListarPorId(IdCambio);

        if (cambioDB == null) throw new Exception("Houve um erro na exclusão do Cambio");

        _context.Cambios.Remove(cambioDB);
        _context.SaveChanges();

        return true;
    }

    public Cambio Atualizar(Cambio cambio)
    {
        _context.Cambios.Update(cambio);
        _context.SaveChanges();
        return cambio;
    }

    public List<Cambio> BuscarTodos()
    {
        return _context.Cambios.ToList();
    }

    public Cambio ListarPorId(int Id)
    {
        return _context.Cambios.FirstOrDefault(x => x.IdCambio == Id);
    }
}