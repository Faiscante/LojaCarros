namespace DexteraTech.CarStore.Application.Models;

public class AppMessageModel
{
    public AppMessageModel(Enums.State state, string message)
    {
        State = state;
        Message = message;
    }

    public Enums.State State { get; set; }
    public string Message { get; set; }
}