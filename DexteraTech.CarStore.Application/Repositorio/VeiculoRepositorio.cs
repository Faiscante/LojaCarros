using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Application.Repositorio;

public class VeiculoRepositorio : IVeiculoRepositorio
{
    private readonly ApplicationDbContext _context;

    public VeiculoRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public List<Veiculo> BuscarTodoComFotosParaVenda()
    {
        return _context.Veiculos
            .Include(o => o.IdCambioNavigation)
            .Include(o => o.IdCorNavigation)
            .Include(o => o.IdVersaoNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdMarcaNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdCarroceriaNavigation)
            .Include(o => o.Fotos)
            .Where(x=> x.ExibirVitrine)
            .ToList();
    }

    public Veiculo Adicionar(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();

        return veiculo;
    }

    public bool Apagar(int IdVeiculo)
    {
        var veiculoDB = ListarPorId(IdVeiculo);

        if (veiculoDB == null) throw new Exception("Houve um erro na exclusão do Veiculo");

        _context.Veiculos.Remove(veiculoDB);
        _context.SaveChanges();
        return true;
    }

    public Veiculo Atualizar(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        _context.SaveChanges();
        return veiculo;
    }

    public List<Veiculo> BuscarTodoComFotos()
    {
        return _context.Veiculos
            .Include(o => o.IdCambioNavigation)
            .Include(o => o.IdCorNavigation)
            .Include(o => o.IdVersaoNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdMarcaNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdCarroceriaNavigation)
            .Include(o => o.Fotos)
            .ToList();
    }

    public List<Veiculo> BuscarTodos()
    {
        return _context.Veiculos
            .Include(o => o.IdCambioNavigation)
            .Include(o => o.IdCorNavigation)
            .Include(o => o.IdVersaoNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdMarcaNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdCarroceriaNavigation)
            .ToList();
    }


    public Veiculo ListarPorId(int Id)
    {
        return _context.Veiculos
            .Include(o => o.IdCambioNavigation)
            .Include(o => o.IdCorNavigation)
            .Include(o => o.IdVersaoNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdMarcaNavigation)
            .Include(o => o.IdVersaoNavigation.IdModeloNavigation.IdCarroceriaNavigation)
            .Include(o => o.Fotos)
            .FirstOrDefault(x => x.IdVeiculo == Id);
    }
}