using Outsurance.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Outsurance.FileHandler
{
    public class FileHandler : IFileHandler
    {
        public IEnumerable<Employee> ReadFile()
        {
            IEnumerable<Employee> records = null;
            CsvHelper.CsvReader csvReader = null;
            try
            {
                System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");

                if (reader != null)
                {
                    csvReader = new CsvHelper.CsvReader(reader);
                    records = csvReader.GetRecords<Employee>().ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return records;

        }

        public void ComputeRecord(IEnumerable<Employee> records)
        {
            try
            {


                foreach (var surnameList in records.GroupBy(record => record.LastName)
                   .Select(group => new
                   {
                       LastName = group.Key,
                       Count = group.Count()
                   }
                   )
                   .OrderBy(x => x.Count)
                   )
                {
                    WriteOutput(String.Format("{0} {1}", surnameList.LastName,surnameList.Count), @"C:\temp\Results\Names.txt");
                }



                foreach (var surnameList in records.GroupBy(record => record.FirstName +" "+record.LastName)
                   .Select(group => new
                   {
                       LastName = group.Key,
                       Count = group.Count()
                   }
                   )
                   .OrderBy(x => x.Count)
                   )
                {
                    WriteOutput(String.Format("{0}", surnameList.LastName), @"C:\temp\Results\Names.txt");
                }


                foreach (var nameList in records.GroupBy(record => record.FirstName)
                    .Select(group => new
                    {
                        Name = group.Key,
                        Count = group.Count()
                    })
                    .OrderBy(x => x.Count))
                {
                    WriteOutput(String.Format("{0}, {1}", nameList.Name, nameList.Count), @"C:\temp\Results\Names.txt");

                }


                foreach (var line in records.GroupBy(record => record.Address)
                .Select(group => new
                {
                    Address = group.Key
                })
                .OrderBy(x => x.Address))
                {
                    WriteOutput(String.Format("{0}", line.Address), @"C:\temp\Results\Addresses.txt");
                }
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public void WriteOutput(string data, string fileName)
        {
            try
            {
                
                if (!File.Exists(fileName))
                {
                    //File.Create(fileName);
                     var tw = new StreamWriter(fileName);
                      tw.WriteLine(data);
                      tw.Close();
                    

                }
                else 
                {
                    using (var tw = new StreamWriter(fileName, true))
                    {
                        tw.WriteLine(data);
                        tw.Close();
                    }
                }
                
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                

            }

        }
    }
}
