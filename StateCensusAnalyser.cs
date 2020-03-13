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

            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(line[i]);
            }
            Utility.Sorted(line);
            var str = Utility.ConvertCsvFileToJsonObject(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusDataSortedForm.csv");
            return str;
            
            
            //File.WriteAllText(@"C:\Users\Bridge Labz\Desktop\censusdata\xx.json", str);
        }

    }

}

