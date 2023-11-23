using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;

namespace DexteraTech.CarStore.Application.Repositorio;

public class MarcaRepositorio : IMarcaRepositorio
{
    public Marca Adicionar(Marca marca)
    {
        // Adiciona a marca ao contexto se ela não existe
        _context.Marcas.Add(marca);

        // Salva as alterações no banco de dados
        _context.SaveChanges();

        return marca;
    }

    public bool Apagar(int IdMarca)
    {
        // Verifica se a marca existe no banco de dados pelo ID
        var marcaDB = ListarPorId(IdMarca);

        // Lança uma exceção se a marca não for encontrada
        if (marcaDB == null) throw new Exception("Houve um erro na exclusão da Marca");

        // Remove a marca do contexto
        _context.Marcas.Remove(marcaDB);
        // Salva as alterações no banco de dados
        _context.SaveChanges();

        return true;
    }

    public Marca Atualizar(Marca marca)
    {
        _context.Marcas.Update(marca);
        _context.SaveChanges();
        return marca;
    }

    public List<Marca> BuscarTodos()
    {
        //Consulta todas as marcas no banco de dados e retorna como lista
        return _context.Marcas.ToList();
    }

    public Marca ListarPorId(int Id)
    {
        //Consulta a marca atravez do Id passado e encontra a primeira
        return _context.Marcas.FirstOrDefault(x => x.IdMarca == Id);
    }

    #region Conexao com Banco de dados

    //conexão entre o repositório MarcaRepositorio e o contexto do banco de dados ApplicationDbContext
    private readonly ApplicationDbContext _context;

    //Metodo Construtor
    public MarcaRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    #endregion
}