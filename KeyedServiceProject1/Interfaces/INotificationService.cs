namespace KeyedServiceProject1.Interfaces;

public interface INotificationService
{
    Task<string> NotifyAsync(string message);
}