// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateCensusAnalyserTest.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace NUnitTestProject1
{
    using System.IO;
    using NUnit.Framework;
    using Newtonsoft.Json;
    using CensusAnalyserLibrary;
    using Newtonsoft.Json.Linq;


    /// <summary>
    /// This is CensusAnalyser Test class
    /// </summary>
    public class CenserAnalyserTests
    {
        /// <summary>
        /// FOR USECASE 1
        /// </summary>
        string CorrectFilePath_Usecase1 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV";
        string FilePath_EmptyHeader_Usecase1 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusDataEmptyHeader.csv";
        string IncorrectFilePath_Usecase1 = @"Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
        string ErrorTypeFilePath_Usecase1 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.txt";

        /// <summary>
        /// FOR USECASE 2
        /// </summary>
        string CorrectFilePath_Usecase2 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCodecsv.csv";
        string FilePath_EmptyHeader_Usecase2 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCodeEmptyHeader.csv";
        string IncorrectFilePath_Usecase2 = @"Users\Bridge Labz\Desktop\censusdata\StateCode.csv";
        string ErrorTypeFilePath_Usecase2 = @"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCodecsv.txt";

        /// <summary>
        /// creating instance of factory class
        /// </summary>
        CSVFactory ff = new CSVFactory();

        /// <summary>
        /// creating instance of builder class
        /// </summary>
        CSVBuilder bb = new CSVBuilder();

        /// <summary>
        /// test case 1.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {
            StateCensusAnalyser obj = new StateCensusAnalyser();
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var obj1 = delegateCSV(ff.createInstance("CSVStatescensus"), CorrectFilePath_Usecase1);
            //object[] myitems = obj.StateCensusCSVData();
            //int item = (int)myitems.Length;

            string[] myitems = File.ReadAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.CSV");
            int item = (int)myitems.Length;
            Assert.AreEqual(item, obj1);
        }

        /// <summary>
        /// test case 1.2
        ///Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePath_Imroper_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(()=>delegateCSV(ff.createInstance("CSVStatescensus"), IncorrectFilePath_Usecase1));
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 1.3
        ///Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathCorrect_TypeIsIncorrect_whenAnalyse_ItThrowsException()
        {

            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStatescensus"), ErrorTypeFilePath_Usecase1));
            var expected = MyEnum.INCORRECT_TYPE.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 1.4
        ///Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathCorrect_DelimiterIsIncorrect_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStatescensus"), CorrectFilePath_Usecase1, '.'));
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 1.5   
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStatescensus"), FilePath_EmptyHeader_Usecase1));
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 2.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            object Iteratoritems = delegateCSV(ff.createInstance("CSVStates"), CorrectFilePath_Usecase2);
            string[] myitems = File.ReadAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCode.csv");
            int item = (int)myitems.Length;
            Assert.AreEqual(item, Iteratoritems);
        }

        /// <summary>
        /// test case 2.2
        ///Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePath_Imroper_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStates"), IncorrectFilePath_Usecase2));
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 2.3
        ///Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathCorrect_TypeIsIncorrect_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStates"), ErrorTypeFilePath_Usecase2));          
            var expected = MyEnum.INCORRECT_TYPE.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 2.4
        ///Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathCorrect_DelimiterIsIncorrect_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStates"), CorrectFilePath_Usecase2, '.'));            
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 2.5   
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            DelegateCSVDirector delegateCSV = bb.CSVDirector;
            var actual = Assert.Throws<CensusAnalyseException>(() => delegateCSV(ff.createInstance("CSVStates"), FilePath_EmptyHeader_Usecase2));           
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// UseCase 3
        /// TestCase 3.1
        /// Convert the csv file to json 
        /// here json file should matched the sorted order start state in csv file
        /// </summary>
        [Test]
        public void UseCase3_CheckStartState_InAJsonFile_WhenAnalyse_ItShouldReturnMatched()
        {
            var json=StateCensusAnalyser.StateCensus();
            JArray experiencesArrary = JArray.Parse(json);
            var actual=experiencesArrary[0]["State"].ToString();
            var Expected = "Andhra Pradesh";
            Assert.AreEqual(actual, Expected);
        }
    }
}