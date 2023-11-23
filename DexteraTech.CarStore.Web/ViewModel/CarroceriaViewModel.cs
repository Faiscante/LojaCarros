using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class CarroceriaViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCarroceria { get; set; }

    [DisplayName("Carroceria")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    public string? NmCarroceria { get; set; }

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}