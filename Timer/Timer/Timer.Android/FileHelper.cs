using System;
using System.IO;
using Timer.Droid;
using Timer.Helper;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Timer.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}