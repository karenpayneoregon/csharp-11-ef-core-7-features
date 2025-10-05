using KeyedServiceProject1.Interfaces;

namespace KeyedServiceProject1.Classes;

public enum ServiceKeys
{
    FirstDemo,
    SecondDemo
}
public class FirstNotification : INotificationService
{
    public async Task<string> NotifyAsync(string message) =>
        await Task.FromResult($"First Notification: {message}");

}

public class SecondNotification : INotificationService
{
    public async Task<string> NotifyAsync(string message) =>
        await Task.FromResult($"Second Notification: {message}");

}