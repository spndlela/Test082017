using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Outsurance.FileHandler;
using System.IO;

namespace Outsurance.FileHandler.Test
{
    [TestClass]
    public class FileHandlerTest
    {


        [TestMethod]
        public void FileReader_Is_Not_Null()
        {
            // arrange  
            CsvHelper.CsvReader csvReader = null;
            IEnumerable<Employee> records = null;

            // act  
            System.IO.TextReader expected = File.OpenText(@"C:\Temp\data.csv");
            csvReader = new CsvHelper.CsvReader(expected);
            records = csvReader.GetRecords<Employee>();

            // assert  
            System.IO.TextReader actual = expected;
            Assert.AreEqual(expected, actual, "FileReader not empty");

        }

        [TestMethod]
        public void FileReader_Is_Null()
        {
            // arrange  
            CsvHelper.CsvReader csvReader = null;
            IEnumerable<Employee> records = null;

            // act  
            System.IO.TextReader expected = File.OpenText(@"C:\Temp\data.csv");
            csvReader = new CsvHelper.CsvReader(expected);
            records = csvReader.GetRecords<Employee>();

            // assert  
            System.IO.TextReader actual = null;
            Assert.AreNotEqual(expected, actual, "FileReader is not empty");

        }

        [TestMethod]
        public void CSVReader_Is_Not_Null()
        {
            // arrange  
            CsvHelper.CsvReader expected = null;
            IEnumerable<Employee> records = null;

            // act  
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            expected = new CsvHelper.CsvReader(reader);
            records = expected.GetRecords<Employee>();

            // assert  
            CsvHelper.CsvReader actual = expected;
            Assert.AreEqual(expected, actual, "CSVReader is not null");

        }

        [TestMethod]
        public void CSVReader_Is_Null()
        {
            // arrange  
            CsvHelper.CsvReader expected = null;
            IEnumerable<Employee> records = null;

            // act  
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            expected = new CsvHelper.CsvReader(reader);
            records = expected.GetRecords<Employee>();

            // assert  
            CsvHelper.CsvReader actual = null;
            Assert.AreNotEqual(expected, actual, "CSVReader is  null");

        }

        [TestMethod]
        public void Return_Valid_Record()
        {
            // arrange  
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(reader);
            IEnumerable<Employee> expected = null;

            // act  
            expected = csvReader.GetRecords<Employee>();

            // assert  
            IEnumerable<Employee> actual = expected;
            Assert.AreEqual(expected, actual, "Record(s) Found");

        }

        [TestMethod]
        public void Return_No_Record()
        {
            // arrange  
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            CsvHelper.CsvReader csvReader = new CsvHelper.CsvReader(reader);
            IEnumerable<Employee> expected = null;

            // act  
            expected = csvReader.GetRecords<Employee>();

            // assert  
            IEnumerable<Employee> actual = null;
            Assert.AreNotEqual(expected, actual, "No Record Found");

        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Compute_Records_Successfully()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();
            CsvHelper.CsvReader csvReader = null;
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            csvReader = new CsvHelper.CsvReader(reader);
            
            
            // act  
             IEnumerable<Employee> expected = csvReader.GetRecords<Employee>(); 
            fileHandler.ComputeRecord(expected);
            // assert  

            IEnumerable<Employee> actual = expected;
            Assert.AreEqual(expected, actual, "Record Computed");

        }

       [TestMethod]
       [ExpectedException(typeof(Exception))]
       public void No_Record_To_Compute()
        {
            // arrange

            FileHandler fileHandler = new FileHandler();
            CsvHelper.CsvReader csvReader = null;
            System.IO.TextReader reader = File.OpenText(@"C:\Temp\data.csv");
            csvReader = new CsvHelper.CsvReader(reader);
            IEnumerable<Employee> expected = csvReader.GetRecords<Employee>();

            // act  
            fileHandler.ComputeRecord(expected);
            // assert  

            IEnumerable<Employee> actual = null;
            Assert.AreNotEqual(expected, actual, "No Record Computed");

        }
        [TestMethod]
        public void Write_Output_File_Successfully()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();

            string data = "Sphe,1";
            string expected = @"C:\Temp\Test\Test_Output.txt";

            // act  
            fileHandler.WriteOutput(data,expected);

            // assert  

            string actual = expected;
            Assert.AreEqual(expected, actual, "Output written to a file: "+expected);

        }

        [TestMethod]
        public void Writing_Output_File_Not_Successful()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();

            string data = "Sphe,1";
            string expected = @"C:\Temp\Test\Test_Write_Output_Failed.txt";

            // act  
            fileHandler.WriteOutput(data, expected);
            // assert  

            string actual = null;
            Assert.AreNotEqual(expected, actual,String.Format("No data written to a file :{0} ",expected));

        }

        [TestMethod]
        public void Output_File_Does_Not_Exist()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();
            string data = "Sphe,1";
            string fileName = @"C:\Temp\Test\File_Doesnt_Exist.txt";
            TextWriter expected = null;
            // act  
            // fileHandler.WriteOutput(data, fileName);
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
                expected = new StreamWriter(fileName);
                expected.WriteLine(data);
            }
            else 
            {
                expected = new StreamWriter(fileName);
                expected.WriteLine(data);
            }
       


            // assert  
            TextWriter actual = expected;
            Assert.AreEqual(expected, actual, "File Stream open for data to be written");
            expected.Close();

        }
        [TestMethod]
        public void Output_File_Exist()
        {
            // arran
            FileHandler fileHandler = new FileHandler();
            string data = "Sphe,1";
            string fileName = @"C:\Temp\Test\FileExist.txt";

            // act  
            // fileHandler.WriteOutput(data, fileName);
            TextWriter expected = new StreamWriter(fileName);
            expected.WriteLine(data);



            // assert  
            TextWriter actual = expected;
            Assert.AreEqual(expected, actual, "File Stream open for data to be written");
            expected.Close();

        }
              

        [TestMethod]
        public void Data_To_Write_To_Output_File()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();

            string expected = "Sphe,1";
            string filename = @"C:\Temp\Test\Write_Data_To_File_Success.txt";

            // act  
            fileHandler.WriteOutput(expected, filename);
            // assert  

            string actual = expected;
            Assert.AreEqual(expected, actual, String.Format("Record: {0} written to a file",expected));

        }

        [TestMethod]
        public void No_Data_To_Write_To_Output_File()
        {
            // arrange
            FileHandler fileHandler = new FileHandler();
            string expected = "Sphe,1";
            string filename = @"C:\Temp\Test\Write_Output_Data_Failed.txt";

            // act  
            fileHandler.WriteOutput(expected, filename);

            // assert  
            string actual = null;
            Assert.AreNotEqual(expected, actual, "No Record written to a file");

        }

    }
}
