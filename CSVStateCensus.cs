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
        public static object CSVDataUsingIEnumerator(string FilePath)
        {
            try
            {
                if(FilePath!= @"C:\Users\Bridge Labz\Desktop\censusdata\StateCensusData.csv")
                {
                    throw new CensusAnalyseException("ERROR_IN_FILE_READING");
                }
                List<string> myList = new List<string>();
           
                string[] Lines = File.ReadAllLines(FilePath);
           
                foreach (var line in Lines)
                {
                    myList.Add(line);
                }
                int count = 0;
                IEnumerable<string> iterator = myList;
                foreach(var item in iterator)
                {
                    count++;
                }

                return count;
            }
            catch (CensusAnalyseException ex)
            {
                return ex.Message;
            }
        }
    }
}

