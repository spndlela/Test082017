using Outsurance.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Outsurance.FileHandler
{
    interface IFileHandler
    { 
        IEnumerable<Employee> ReadFile();
        void ComputeRecord(IEnumerable<Employee> records);
        void WriteOutput(string data, string fileName);

    }
}
