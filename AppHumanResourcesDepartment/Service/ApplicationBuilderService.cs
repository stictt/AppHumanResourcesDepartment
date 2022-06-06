using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHumanResourcesDepartment.Model;

namespace AppHumanResourcesDepartment.Service
{
    static class ApplicationBuilderService
    {
        public static void Run()
        {
            var config = new ConfigurationBuilder();
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json");
            IConfigurationRoot root = config.Build();

            if(root["TestingDataBase"] == "true")
            {
                IBinaryCaching binaryCaching = new BinaryCaching();
                if (binaryCaching.TryLoad<AppSettings>(out var apps, out var _))
                {
                    var settings = apps.First();
                    if (settings.IsFirstRun == false)
                    {
                        TestDataGenerator.Run();
                        settings.IsFirstRun = true;
                        binaryCaching.TrySave<AppSettings>(new List<AppSettings>() { settings }, out var _);
                    }
                }
                else
                {
                    AppSettings settings = new AppSettings();
                    TestDataGenerator.Run();
                    settings.IsFirstRun = true;
                    binaryCaching.TrySave<AppSettings>(new List<AppSettings>() { settings }, out var _);
                }
            }
        }
    }
}
