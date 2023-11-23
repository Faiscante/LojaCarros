using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace DexteraTech.CarStore.Application.Repositorio;

public class FotoRepositorio : IFotoRepositorio
{
    private readonly ApplicationDbContext _context;

    public FotoRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    //Metodo de Adicionar Fotos
    public Foto Upload(Foto foto)
    {
        _context.Fotos.Add(foto);
        _context.SaveChanges();

        return foto;
    }

    public bool Apagar(int IdFoto)
    {
        var fotoDB = ListarPorId(IdFoto);

        if (fotoDB == null) throw new Exception("Houve um erro na exclusão");

        _context.Fotos.Remove(fotoDB);
        _context.SaveChanges();

        return true;
    }

    public Foto Atualizar(Foto foto)
    {
        _context.Fotos.Update(foto);
        _context.SaveChanges();

        return foto;
    }

    public List<Foto> BuscarTodos()
    {
        return _context.Fotos
            .Include(o => o.IdVeiculoNavigation)
            .ToList();
    }

    //Consulta o Id da foto no banco de dados
    public Foto ListarPorId(int Id)
    {
        return _context.Fotos.FirstOrDefault(x => x.IdFoto == Id);
    }

    //Lista Fotos por veiculo
    public List<Foto> ListarPorVeiculo(int Id)
    {
        return _context.Fotos.Where(x => x.IdVeiculo == Id).ToList();
    }
}