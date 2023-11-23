using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface ICorRepositorio
{
    Cor ListarPorId(int Id);

    List<Cor> BuscarTodos();
    Cor Adicionar(Cor cor);

    Cor Atualizar(Cor cor);

    bool Apagar(int id);
}