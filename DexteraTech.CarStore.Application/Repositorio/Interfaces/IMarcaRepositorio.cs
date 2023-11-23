using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface IMarcaRepositorio
{
    //Metodos que poderão ser executados
    Marca ListarPorId(int Id);
    List<Marca> BuscarTodos();
    Marca Adicionar(Marca marca);
    Marca Atualizar(Marca marca);
    bool Apagar(int id);
}