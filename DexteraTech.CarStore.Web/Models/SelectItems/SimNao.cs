using Microsoft.AspNetCore.Mvc.Rendering;

namespace DexteraTech.CarStore.Application.Models.SelectItems;

public static class SimNao
{
    public static List<SelectListItem> Options()
    {
        return new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Selecione uma opção", Selected = true, Disabled = true },
            new SelectListItem { Value = "true", Text = "Sim" },
            new SelectListItem { Value = "false", Text = "Não" }
        };
    }
}