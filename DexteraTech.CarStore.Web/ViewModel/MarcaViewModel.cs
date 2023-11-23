using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class MarcaViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdMarca { get; set; }

    public string? NmMarca { get; set; }

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}