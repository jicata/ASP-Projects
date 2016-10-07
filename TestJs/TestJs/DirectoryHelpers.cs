using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJs
{
    using System.IO;

    public static class DirectoryHelpers
    {
        public static string CreateTempDirectory()
        {
            while (true)
            {
                var randomDirectoryName = Path.GetRandomFileName();
                var path = Path.Combine(Path.GetTempPath(), randomDirectoryName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return path;
                }
            }
        }

        
    }
}
