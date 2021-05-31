using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YuzTanima.Core.Utilities.FileHelper
{
    public static class ChangeName
    {
        public static void Change(Guid kameraId)
        {
            
            DirectoryInfo d = new DirectoryInfo($@"/Users/cenkkaraboa/Desktop/son/YuzTanima/YuzTanima.WebService/wwwroot/KameraId/");
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                string fileName = f.FullName;
                File.Copy(f.FullName, f.FullName.Replace(f.Name.ToString(), kameraId.ToString()+".txt"),true);
                File.Delete(f.FullName);
            }
        }
    }
}
