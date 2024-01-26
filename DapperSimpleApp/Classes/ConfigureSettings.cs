using System;
using System.IO;
using DapperSimpleApp.Models;
using Newtonsoft.Json;

namespace DapperSimpleApp.Classes
{
    public class ConfigureSettings
    {
        public static ApplicationSettings Get() 
            => JsonConvert.DeserializeObject<ApplicationSettings>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"appsettings.json")));
    }
}