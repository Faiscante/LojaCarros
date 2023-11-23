using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Application.Repositorio.Interfaces;

public interface ICambioRepositorio
{
    Cambio ListarPorId(int Id);

    List<Cambio> BuscarTodos();
    Cambio Adicionar(Cambio cambio);

    Cambio Atualizar(Cambio cambio);

    bool Apagar(int id);
}