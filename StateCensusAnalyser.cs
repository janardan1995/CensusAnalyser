// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System;
    using System.IO;

    /// <summary>
    /// This is state census Analyser class
    /// </summary>
    public class StateCensusAnalyser
    {
        /// <summary>
        /// this methods read the csv file and return as a array of strings
        /// </summary>
        /// <returns>This class returns string value</returns>
        public string[] StateCensusCSVData()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv");
            return lines;
        }
    }
}
