using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexteraTech.CarStore.Application.Models;

public class Veiculo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVeiculo { get; set; }

    public int IdModelo { get; set; }

    public int IdMarca { get; set; }

    public int IdCambio { get; set; }

    public int IdCor { get; set; }

    public int AnoFabricacao { get; set; }

    public int AnoModelo { get; set; }

    public string? Placa { get; set; }

    public bool Licenciado { get; set; }

    public bool Ipva { get; set; }

    public int IdVersao { get; set; }

    public float VlrVeiculo { get; set; }

    public bool ExibirVitrine { get; set; } = false;

    [StringLength(600)]
    public string? Observacoes {  get; set; }

    public virtual ICollection<Foto> Fotos { get; set; }

    public virtual Cambio IdCambioNavigation { get; set; } = null!;

    public virtual Cor IdCorNavigation { get; set; } = null!;

    public virtual Versao IdVersaoNavigation { get; set; } = null!;
}