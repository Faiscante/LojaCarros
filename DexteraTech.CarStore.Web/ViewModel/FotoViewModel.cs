using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;

namespace DexteraTech.CarStore.Web.ViewModel;

public class FotoViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdFoto { get; set; }

    public int IdVeiculo { get; set; }

    [Required] public byte[] Imagen { get; set; }

    [Required] public string NmArquivo { get; set; } = null!;

    public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;
}