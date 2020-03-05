// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
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
            object Iteratoritems = CSVStateCensus.CSVDataUsingIEnumerator(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv");
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
            string actual = (string)CSVStateCensus.CSVDataUsingIEnumerator(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCnsusData.csv");
            Assert.AreEqual(actual, "ERROR_IN_FILE_READING");
        }   
    }
}