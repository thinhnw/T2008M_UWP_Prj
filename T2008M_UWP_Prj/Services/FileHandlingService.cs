using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
namespace T2008M_UWP.Services
{
    class FileHandlingService
    {
        public static async void WriteFile(string fileName, string content)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var demoFile = await storage.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(demoFile, content);
        }

        public static async Task<string> ReadFile(string fileName)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var demoFile = await storage.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(demoFile);
        }
    }
}