using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Application.Repositorio;

public class ModeloRepositorio : IModeloRepositorio
{
    private readonly ApplicationDbContext _context;

    public ModeloRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public Modelo Adicionar(Modelo modelo)
    {
        _context.Modelos.Add(modelo);
        _context.SaveChanges();

        return modelo;
    }

    public bool Apagar(int IdModelo)
    {
        var modeloDB = ListarPorId(IdModelo);

        if (modeloDB == null) throw new Exception("Houve um erro na exclusão do Modelo");

        _context.Modelos.Remove(modeloDB);
        _context.SaveChanges();

        return true;
    }

    public Modelo Atualizar(Modelo modelo)
    {
        _context.Modelos.Update(modelo);
        _context.SaveChanges();
        return modelo;
    }

    public List<Modelo> BuscarTodos()
    {
        return _context.Modelos
            .Include(o => o.IdMarcaNavigation)
            .Include(o => o.IdCarroceriaNavigation)
            .ToList();
    }

    public Modelo ListarPorId(int Id)
    {
        return _context.Modelos.FirstOrDefault(x => x.IdModelo == Id);
    }

    public List<Modelo> ListarPorMarca(int Id)
    {
        return _context.Modelos.Where(x => x.IdMarca == Id).ToList();
    }
}