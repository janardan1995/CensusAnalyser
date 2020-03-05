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
    using System.IO;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// This is CensusAnalyser Test class
    /// </summary>
    public class CenserAnalyserTests
    {
        /// <summary>
        /// test case 1.1
        ///Given the States Census CSV file, Check to ensure the Number of Record matches
        /// </summary>
        [Test]
        public void GivenCSVFilePathProper_whenAnalyse_ItMatchesTheRecord()
        {
            var FilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
            object Iteratoritems = CSVStateCensus.CSVDataUsingIEnumerator(FilePath);
            object[] myitems = StateCensusAnalyser.StateCensusCSVData();
            int item = (int)myitems.Length;
            Assert.AreEqual(item,Iteratoritems) ;
        }

        /// <summary>
        /// test case 1.2
        ///Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePath_Imroper_whenAnalyse_ItThrowsException()
        {
            var FilePath = @"Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
            string actual = (string)CSVStateCensus.CSVDataUsingIEnumerator(FilePath);
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
            var FilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.txt";
            string actual = (string)CSVStateCensus.CSVDataUsingIEnumerator(FilePath);
            var expected = MyEnum.ERROR_IN_FILE_READING.ToString();
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// test case 1.4
        ///Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePathCorrect_DelimiterIsIncorrect_whenAnalyse_ItThrowsException()
        {
            var FilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv";
            string actual = (string)CSVStateCensus.CSVDataUsingIEnumerator(FilePath, '.');
            var expected = MyEnum.INVALID_DELIMITER.ToString();
            Assert.AreEqual(actual,expected);
        }

        /// <summary>
        /// test case 1.5
        ///Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenCSVFilePathCorrect_CSVHeaderIsIncorrect_whenAnalyse_ItThrowsException()
        {
            var FilePath = @"C:\Users\Bridge Labz\Desktop\censusdata\emptyHeader.csv";
            string actual = (string)CSVStateCensus.CSVDataUsingIEnumerator(FilePath);
            var expected = MyEnum.HEADER_IS_NOT_FOUND.ToString();
            Assert.AreEqual(actual, expected);
        }   
    }
}