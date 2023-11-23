using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class MarcaInputModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMarca { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "O campo é obrigatório.")]
    public string? NmMarca { get; set; }

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}