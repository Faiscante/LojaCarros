using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface IModeloRepositorio
{
    Modelo ListarPorId(int Id);
    List<Modelo> ListarPorMarca(int Id);

    List<Modelo> BuscarTodos();
    Modelo Adicionar(Modelo modelo);

    Modelo Atualizar(Modelo modelo);

    bool Apagar(int id);
}