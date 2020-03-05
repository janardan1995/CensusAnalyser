// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateCensusAnalyserTest.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace NUnitTestProject1
{
    using NUnit.Framework;
    using CensusAnalyserLibrary;

    /// <summary>
    /// This is CensusAnalyser Test class
    /// </summary>
    public class CenserAnalyserTests
    {
        string CorrectFilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.CSV";
        string FilePath2 = @"C:\Users\Bridge Labz\Desktop\censusdata\emptyHeader.csv";
        string IncorrectFilePath = @"Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
        string ErrorTypeFilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.txt";
        /// <summary>
        /// test case 1.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {

            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            object Iteratoritems = loadData(CorrectFilePath);
            object[] myitems = StateCensusAnalyser.StateCensusCSVData();
            int item = (int)myitems.Length;
            Assert.AreEqual(item, Iteratoritems);
        }

        /// <summary>
        /// test case 1.2
        ///Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePath_Imroper_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            object actual = loadData(IncorrectFilePath);
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 1.3
        ///Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePathCorrect_TypeIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            var actual = Assert.Throws<CensusAnalyseException>(() => loadData(ErrorTypeFilePath));
            var expected = MyEnum.INCORRECT_TYPE.ToString();
            Assert.AreEqual(actual.Message, expected);
        }

        /// <summary>
        /// test case 1.4
        ///Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePathCorrect_DelimiterIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            string actual = (string)loadData(CorrectFilePath, '/');
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 1.5   
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            LoadDataDelegate loadData = new LoadDataDelegate(CSVStates.CSVDataUsingIEnumerator);
            string actual = (string)loadData(FilePath2);
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual, expected);
        }
    }
}