using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class CambioInputModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCambio { get; set; }

    [DisplayName("Cambio")]
    [Required(ErrorMessage = "O campo é obrigatorio.")]
    public string? NmCambio { get; set; }

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}