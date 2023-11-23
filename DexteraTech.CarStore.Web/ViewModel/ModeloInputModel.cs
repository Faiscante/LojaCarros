using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexteraTech.CarStore.Web.ViewModel;

public class ModeloInputModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? IdModelo { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "O campo é obrigatorio")]
    public int? IdMarca { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "O campo é obrigatorio")]
    public int? IdCarroceria { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "O campo é obrigatorio")]
    public string? NmModelo { get; set; }
}