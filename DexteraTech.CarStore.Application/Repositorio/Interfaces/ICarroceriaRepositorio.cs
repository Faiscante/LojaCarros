using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface ICarroceriaRepositorio
{
    Carroceria ListarPorId(int Id);

    List<Carroceria> BuscarTodos();
    Carroceria Adicionar(Carroceria carroceria);

    Carroceria Atualizar(Carroceria carroceria);

    bool Apagar(int id);
}