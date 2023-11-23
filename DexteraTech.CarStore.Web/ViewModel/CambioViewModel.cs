using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class CambioViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCambio { get; set; }

    public string NmCambio { get; set; } = null!;

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}