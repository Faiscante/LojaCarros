using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DexteraTech.CarStore.Application.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DexteraTech.CarStore.Web.Models;

public class VeiculoInputModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVeiculo { get; set; }

    [DisplayName("Modelo")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? IdModelo { get; set; }

    [DisplayName("Marca")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? IdMarca { get; set; }

    [DisplayName("Câmbio")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? IdCambio { get; set; }


    [DisplayName("Cor")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? IdCor { get; set; }


    [DisplayName("Ano de Fabricação")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? AnoFabricacao { get; set; } = DateTime.Now.Year;


    [DisplayName("Ano do Modelo")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? AnoModelo { get; set; } = DateTime.Now.Year;


    [DisplayName("Placa")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public string Placa { get; set; }


    [DisplayName("Licenciado")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public bool? Licenciado { get; set; }


    [DisplayName("IPVA")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public bool? Ipva { get; set; }

    [DisplayName("Versão")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public int? IdVersao { get; set; }

    [DisplayName("Valor")]
    [Required(ErrorMessage = "O campo é obrigatorio")]
    public float? VlrVeiculo { get; set; } = null;

    [DisplayName("Observacoes")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    [StringLength(600)]
    public string? Observacoes { get; set; }

    [DisplayName("Exibir na Vitrine?")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public bool? ExibirVitrine { get; set; }

    public virtual List<Foto>? Fotos { get; set; } = new();
    public virtual List<IFormFile>? Imagens { get; set; } = new();

    public ModelStateDictionary Validate()
    {
        var modelState = new ModelStateDictionary();

        if (AnoFabricacao > AnoModelo)
            modelState.AddModelError("AnoModelo", "O Ano Modelo não pode ser menor que o Ano Fabricação.");

        return modelState;
    }
}