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
        /// <summary>
        /// test case 1.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        { 
            
            object Iteratoritems = CSVStates.CSVDataUsingIEnumerator(CorrectFilePath);
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
            var FilePath = @"Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
            string actual = (string)CSVStates.CSVDataUsingIEnumerator(FilePath);
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
            var FilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.CS";
            var actual = Assert.Throws<CensusAnalyseException>(()=>CSVStates.CSVDataUsingIEnumerator(FilePath));
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
            string actual = (string)CSVStates.CSVDataUsingIEnumerator(CorrectFilePath, '/');
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
            string actual = (string)CSVStates.CSVDataUsingIEnumerator(FilePath2);
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual, expected);
        }        
    }
}