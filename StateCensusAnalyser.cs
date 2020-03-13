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
    /// <summary>
    /// this methods read the csv file and return as a array of strings
    /// </summary>

    public class StateCensusAnalyser
    {
        public static string StateCensus()
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV");
            Utility.Sorted(line);
            var str = Utility.ConvertCsvFileToJsonObject(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusDataSortedForm.csv");
            return str;
        }

        public static string StateCode()
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCode.csv");

            var sortedData=Utility.sort(line);
            var str = Utility.ConvertCsvFileToJsonObject(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCodeSortedForm.csv");
            return str;
        }
    }
}

