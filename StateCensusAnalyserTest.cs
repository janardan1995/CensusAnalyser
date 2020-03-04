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
            IEnumerable<string> Iteratoritems = CSVStateCensus.CSVDataUsingIEnumerator();
            string[] myitems = StateCensusAnalyser.StateCensusCSVData();          
            Assert.AreEqual(myitems,Iteratoritems) ;
        }
    }
}