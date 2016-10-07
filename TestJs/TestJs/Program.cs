using System.Diagnostics;
using System.IO;

namespace TestJs
{
    using System;
    using System.Collections.Generic;
    using System.IO.Compression;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
             //string jsFile = File.ReadAllText(@"C: \Users\Maika\Documents\Programming\untitled\kur1.js");
            // Process.Start()
            //"C:\Program Files\nodejs\node.exe"
            string nodeJs = @"C:\Program Files\nodejs\node.exe";
            string browserify = @"C:\Users\Maika\node_modules\browserify\index.js";
            string fileToBrowserify = @"C:\Users\Maika\Documents\Programming\uploads\app.js";
            string outputFile = @"D:\bundle.js";
            string outputArguments = $"-o {outputFile}";
            string path = @"C:\Users\Maika\Documents\Programming\uploads";

            var files = new List<string>(Directory.GetFiles(path, "app.js", SearchOption.AllDirectories));


            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
           // ProcessStartInfo startInfo = new ProcessStartInfo();
           // startInfo.UseShellExecute = false;
           // startInfo.FileName = nodeJs;
           //startInfo.Arguments = $"{browserify} {fileToBrowserify} {outputArguments}";
           // Console.WriteLine(startInfo.Arguments);
           // using (Process exeProcess = Process.Start(startInfo))
           // {
           //     exeProcess.WaitForExit();
           // }

            //string path = DirectoryHelpers.CreateTempDirectory();
            //Console.WriteLine(path);
            //string zipPath = @"C:\Users\Maika\Documents\Programming\ASP\JSFolder.zip";

            //ZipFile.CreateFromDirectory(startPath, zipPath);

            //ZipFile.ExtractToDirectory(zipPath, path);

        }

        public static byte[] Compress(string stringToCompress)
        {
            if (stringToCompress == null)
            {
                return null;
            }

            var bytes = Encoding.UTF8.GetBytes(stringToCompress);

            using (var memoryStreamInput = new MemoryStream(bytes))
            {
                using (var memoryStreamOutput = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(memoryStreamOutput, CompressionMode.Compress))
                    {
                        memoryStreamInput.CopyTo(deflateStream);
                    }

                    return memoryStreamOutput.ToArray();
                }
            }
        }

        public static string Decompress(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            using (var memoryStreamInput = new MemoryStream(bytes))
            {
                using (var memoryStreamOutput = new MemoryStream())
                {
                    using (var deflateStream = new DeflateStream(memoryStreamInput, CompressionMode.Decompress))
                    {
                        deflateStream.CopyTo(memoryStreamOutput);
                    }

                    return Encoding.UTF8.GetString(memoryStreamOutput.ToArray());
                }
            }
        }
    }
}
