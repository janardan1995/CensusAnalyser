// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// This is CSVStateCensus class
    /// </summary>
    public class CSVStatescensus : ICSVStatecensus
    {
        /// <summary>
        /// In this method i am using Ienumerable
        /// </summary>
        /// <returns>it returns the string value</returns>
        public int CSVDataUsingIEnumerator(string FilePath, char delimiter = ',')
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            string type = fileInfo.Extension;
            if (type != ".CSV" && type != ".csv")
                throw new CensusAnalyseException("INCORRECT_TYPE");
            
                if (!File.Exists(FilePath))
                    throw new CensusAnalyseException("ERROR_IN_FILE_READING");

                ////This line reads the CSV file and store it into the strings of array
                string[] Lines = File.ReadAllLines(FilePath);
                if (Lines[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                    throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");

                foreach (var line in File.ReadLines(FilePath))
                {
                    ////For delimeter
                    string[] LineCount = line.Split(delimiter);
                    if (LineCount.Length != 4 && LineCount.Length != 2)
                        throw new CensusAnalyseException("INVALID_DELIMITER");
                }

                ////store the list into iterator(IEnumerable)
                IEnumerable<string> iterator = Lines;
                int count = 0;
                foreach (var item in iterator)
                    count++;
                return count;
            
           
        }
    }
}

