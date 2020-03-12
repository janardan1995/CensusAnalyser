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
    using System.Linq;
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

            ////initialize a list
            List<string> Lines = File.ReadAllLines(FilePath).ToList();
            if (Lines.Contains("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                foreach (var line in Lines)
                {
                    ////For delimeter
                    string[] LineCount = line.Split(delimiter);
                    if (LineCount.Length != 4 && LineCount.Length != 2)
                        throw new CensusAnalyseException("INVALID_DELIMITER");
                }
                return Lines.Count;
            }
            else
                throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");
        }
    }
}

