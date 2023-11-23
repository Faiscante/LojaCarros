using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;

namespace DexteraTech.CarStore.Application.Repositorio;

public class CorRepositorio : ICorRepositorio
{
    public Cor Adicionar(Cor cor)
    {
        _context.Cores.Add(cor);
        _context.SaveChanges();

        return cor;
    }

    public bool Apagar(int IdCor)
    {
        var corDB = ListarPorId(IdCor);

        if (corDB == null) throw new Exception("Houve um erro na exclusão da Cor");

        _context.Cores.Remove(corDB);
        _context.SaveChanges();

        return true;
    }

    public Cor Atualizar(Cor cor)
    {
        _context.Cores.Update(cor);
        _context.SaveChanges();
        return cor;
    }

    public List<Cor> BuscarTodos()
    {
        return _context.Cores.ToList();
    }

    public Cor ListarPorId(int Id)
    {
        return _context.Cores.FirstOrDefault(x => x.IdCor == Id);
    }

    #region Conexao com Banco de dados

    private readonly ApplicationDbContext _context;

    public CorRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    #endregion
}