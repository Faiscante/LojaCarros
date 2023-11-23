using DexteraTech.CarStore.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DexteraTech.CarStore.Web.Extensions;

public static class ControllerExtensions
{
    public static void AddMessage(this Controller controller, Enums.State state, string message)
    {
        controller.TempData.Put("AppMessage", new AppMessageModel(state, message));
    }
}