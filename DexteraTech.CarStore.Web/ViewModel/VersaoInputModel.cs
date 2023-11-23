using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class VersaoInputModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVersao { get; set; }

    [DisplayName("Versao")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public string? NmVersao { get; set; }

    [DisplayName("Modelo")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int IdModelo { get; set; }

    public virtual Modelo? IdModeloNavigation { get; set; }

    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}