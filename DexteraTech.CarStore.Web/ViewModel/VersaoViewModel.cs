using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class VersaoViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVersao { get; set; }

    public string NmVersao { get; set; } = null!;

    public int IdModelo { get; set; }

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}