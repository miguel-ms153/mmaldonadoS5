using System;
using System.Collections.Generic;
using System.Text;

namespace mmaldonadoS5.Utils
{
    public class FileAccesHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
    
}
