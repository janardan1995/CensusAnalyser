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
        /// sort by alphabate
        /// </summary>
        /// <returns></returns>
        public static string SortStateAlphabatic(int palceholder, string path)
        {
            string[] line = File.ReadAllLines(path);
            var sortedData = Utility.sortAlphabatic(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sortedData);
            return str;
        }

        /// <summary>
        /// sort bt integer
        /// </summary>
        /// <param name="palceholder"></param>
        /// <returns></returns>
        public static string StateCensusSortByIntegerValue(int palceholder)
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV");
            var sorted = Utility.SortingInt(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sorted);
            return str;
        }
    }
}

