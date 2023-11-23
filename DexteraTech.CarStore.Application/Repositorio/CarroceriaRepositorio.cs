using DexteraTech.CarStore.Application.Models;
using DexteraTech.CarStore.Application.Repositorio.Interfaces;
using DexteraTech.CarStore.Web.Data;

namespace DexteraTech.CarStore.Application.Repositorio;

public class CarroceriaRepositorio : ICarroceriaRepositorio
{
    public Carroceria Adicionar(Carroceria carroceria)
    {
        //Adicionar a Carroceria e salva no banco de dados
        _context.Carroceria.Add(carroceria);
        _context.SaveChanges();

        return carroceria;
    }

    public bool Apagar(int IdCarroceria)
    {
        //verifica se a carroceria existe no banco de dados passando o ID
        var carroceriaDB = ListarPorId(IdCarroceria);

        //Lança uma exceção 
        if (carroceriaDB == null) throw new Exception("Houve um erro na exclusão da Carroceria");

        //Chama o metodo de remover a carroceria e salva a alteração
        _context.Carroceria.Remove(carroceriaDB);
        _context.SaveChanges();

        return true;
    }

    public Carroceria Atualizar(Carroceria carroceria)
    {
        _context.Carroceria.Update(carroceria);
        _context.SaveChanges();
        return carroceria;
    }

    public List<Carroceria> BuscarTodos()
    {
        //Consulta todas as carrocerias no banco de dados e retorna como lista
        return _context.Carroceria.ToList();
    }

    public Carroceria ListarPorId(int Id)
    {
        //Consulta a carroceria atravez do Id passado e encontra o primeiro
        return _context.Carroceria.FirstOrDefault(x => x.IdCarroceria == Id);
    }

    #region Conexao com Banco de dados

    //conexão entre o repositório CarroceriaRepositorio e o contexto do banco de dados ApplicationDbContext
    private readonly ApplicationDbContext _context;

    //Metodo Construtor
    public CarroceriaRepositorio(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    #endregion
}