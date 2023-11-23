using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface IVeiculoRepositorio
{
    Veiculo ListarPorId(int Id);

    List<Veiculo> BuscarTodos();

    List<Veiculo> BuscarTodoComFotos();
    List<Veiculo> BuscarTodoComFotosParaVenda();

    Veiculo Adicionar(Veiculo veiculo);

    Veiculo Atualizar(Veiculo veiculo);

    bool Apagar(int id);
}