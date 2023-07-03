#pragma warning disable CS8618
namespace SecretManager1.Models;

public class MailSettings
{
    public string FromAddress { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public int TimeOut { get; set; }
    public string PickupFolder { get; set; } = "MailDrop";
    public override string ToString() => $"From: {FromAddress} Host: {Host} Port: {Port}";
}