

using Kochbuch.Android;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace  Kochbuch.Android
{
    class FileHelper : IFileHelper{
        public string GetLocalFilePath(string fileName){
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}