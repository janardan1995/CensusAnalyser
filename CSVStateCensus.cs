// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------


namespace CensusAnalyserLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    /// <summary>
    /// This is CSVStateCensus class
    /// </summary>
    public class CSVStateCensus
    {
        /// <summary>
        /// In this method i am using Ienumerable
        /// </summary>
        /// <returns>it returns the string value</returns>
        public static IEnumerable<string> CSVDataUsingIEnumerator()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv");
            foreach(var line in lines)
            {
                yield return line;
            }
        }

    }
}
