namespace ReadEntitySettings.Models;

public class ConfigurationRoot
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public EntityConfiguration EntityConfiguration { get; set; }
}