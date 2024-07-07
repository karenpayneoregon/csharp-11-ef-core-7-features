using Microsoft.Extensions.Options;
using StringSyntaxWithEntityFrameworkCore.Models.Configuration;

namespace StringSyntaxWithEntityFrameworkCore.Classes.Configuration;
internal class SetupServices
{
    private readonly IOptions<ApplicationSetting> _formats;
    private readonly EntityConfiguration _settings;
    private readonly ConnectionStrings _options;

    public SetupServices(IOptions<ConnectionStrings> options, IOptions<EntityConfiguration> config, IOptions<ApplicationSetting> formats )
    {
        _formats = formats;
        _options = options.Value;
        _settings = config.Value;
    }

    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
    }
    public void GetEntitySettings()
    {
        EntitySettings.Instance.CreateNew = _settings.CreateNew;
    }
    public void GetFormats()
    {
        FormatSettings.Instance.Items = _formats.Value;
    }
}
