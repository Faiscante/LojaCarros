using Microsoft.AspNetCore.Mvc.Rendering;

namespace DexteraTech.CarStore.Web.Extensions;

public static class ListExtensions
{
    public static List<SelectListItem> ToSelectList<T>(this List<T> list, string idPropertyName,
        string namePropertyName = "Name")
        where T : class, new()
    {
        var selectListItems = new List<SelectListItem>();

        selectListItems.Add(new SelectListItem("Selecione uma opção", "", true, true));
        list.ForEach(item =>
        {
            selectListItems.Add(new SelectListItem
            {
                Text = item.GetType().GetProperty(namePropertyName).GetValue(item).ToString(),
                Value = item.GetType().GetProperty(idPropertyName).GetValue(item).ToString()
            });
        });

        return selectListItems;
    }
}