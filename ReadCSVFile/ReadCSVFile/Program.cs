using Outsurance.FileHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsurance.FileHandler
{
    class Program
    {
        static void Main(string[] args)
        {

        #region Clear Files- For Testing Purpose
            DirectoryInfo testFolder = new DirectoryInfo(@"C:\Temp\Test");
            DirectoryInfo contentFolder = new DirectoryInfo(@"C:\Temp\Results");
        
        foreach (FileInfo file in testFolder.GetFiles())
        {
            file.Delete(); 
        }

            foreach (FileInfo file in contentFolder.GetFiles())
        {
            file.Delete(); 
        }
        #endregion


            IFileHandler fileHandlier = new FileHandler();
             var rec = fileHandlier.ReadFile();
             fileHandlier.ComputeRecord(rec);
             Console.WriteLine("Please Check files in C Drive under Temp Folder ");
             Console.ReadLine();

        }
    }
}
