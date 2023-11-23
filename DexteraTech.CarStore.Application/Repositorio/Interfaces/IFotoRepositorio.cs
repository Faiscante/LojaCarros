using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface IFotoRepositorio
{
    Foto ListarPorId(int Id);

    List<Foto> BuscarTodos();
    Foto Upload(Foto foto);

    Foto Atualizar(Foto foto);

    bool Apagar(int id);

    List<Foto> ListarPorVeiculo(int idVeiculo);
}