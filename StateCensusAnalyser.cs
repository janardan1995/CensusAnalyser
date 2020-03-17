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
        /// <summary>
        /// This method for StateCensus
        /// </summary>
        /// <returns></returns>
        public static string StateCensusSortByState(int palceholder)
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV");
            var sorted= Utility.sortAlphabatic(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sorted);
            return str;
        }

        public static string StateCensusSortByIntegerValue(int palceholder)
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV");
            var sorted= Utility.SortingInt(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sorted);
            return str;
        }

        /// <summary>
        /// This method is for state code
        /// </summary>
        /// <returns></returns>
        public static string StateCodeSortByStateCode(int palceholder)
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCode.csv");
            var sortedData= Utility.sortAlphabatic(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sortedData);
            return str;
        }
    }
}

