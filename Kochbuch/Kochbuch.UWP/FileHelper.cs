
using Kochbuch.UWP;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace  Kochbuch.UWP
{
    public class FileHelper : IFileHelper{
        public string GetLocalFilePath(string fileName){
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        }
    }
}