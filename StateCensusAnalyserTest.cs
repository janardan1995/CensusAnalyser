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
    using CensusAnalyserLibrary;

    /// <summary>
    /// This is CensusAnalyser Test class
    /// </summary>
    public class CenserAnalyserTests
    {
        string CorrectFilePath_Usecase1 = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.CSV";
        string FilePath_EmptyHeader_Usecase1 = @"C:\Users\Bridge Labz\Desktop\censusdata\emptyHeader.csv";
        string IncorrectFilePath_Usecase1 = @"Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
        string ErrorTypeFilePath_Usecase1 = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.txt";

        string CorrectFilePath_Usecase2 = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCode.CSV";
        string FilePath_EmptyHeader_Usecase2 = @"C:\Users\Bridge Labz\Desktop\censusdata\emptyHeaderForStateCode.csv";
        string IncorrectFilePath_Usecase2 = @"Users\Bridge Labz\Desktop\censusdata\StateCode.csv";
        string ErrorTypeFilePath_Usecase2 = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCode.txt";

        /// <summary>
        /// test case 1.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStatescensus.CSVDataUsingIEnumerator);
            object Iteratoritems = loadData(CorrectFilePath_Usecase1);
            object[] myitems = StateCensusAnalyser.StateCensusCSVData();
            int item = (int)myitems.Length;
            Assert.AreEqual(item, Iteratoritems);
        }

        /// <summary>
        /// test case 1.2
        ///Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePath_Imroper_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStatescensus.CSVDataUsingIEnumerator);
            object actual = loadData(IncorrectFilePath_Usecase1);
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 1.3
        ///Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathCorrect_TypeIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStatescensus.CSVDataUsingIEnumerator);
            var actual = Assert.Throws<CensusAnalyseException>(() => loadData(ErrorTypeFilePath_Usecase1));
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
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStatescensus.CSVDataUsingIEnumerator);
            string actual = (string)loadData(CorrectFilePath_Usecase1, '.');
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 1.5   
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase1_GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStatescensus.CSVDataUsingIEnumerator);
            string actual = (string)loadData(FilePath_EmptyHeader_Usecase1);
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            object Iteratoritems = loadData(CorrectFilePath_Usecase2);
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
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            object actual = loadData(IncorrectFilePath_Usecase2);
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.3
        ///Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathCorrect_TypeIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            var actual = Assert.Throws<CensusAnalyseException>(() => loadData(ErrorTypeFilePath_Usecase2));
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
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            string actual = (string)loadData(CorrectFilePath_Usecase2, '.');
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 2.5   
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void UseCase2_GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            string actual = (string)loadData(FilePath_EmptyHeader_Usecase2);
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual, expected);
        }
    }
}