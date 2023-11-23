using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface IVersaoRepositorio
{
    Versao ListarPorId(int Id);

    List<Versao> ListarPorModelo(int Id);

    List<Versao> BuscarTodos();
    Versao Adicionar(Versao versao);

    Versao Atualizar(Versao versao);

    bool Apagar(int id);
}