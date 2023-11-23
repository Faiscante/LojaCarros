using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexteraTech.CarStore.Application.Models;

public class Modelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdModelo { get; set; }

    public int IdMarca { get; set; }

    public int IdCarroceria { get; set; }

    public string NmModelo { get; set; } = null!;

    public virtual Carroceria IdCarroceriaNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<Versao> Versaos { get; set; } = new List<Versao>();
}