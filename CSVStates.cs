// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVState.cs" company="Bridgelabz">
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
    public class CSVStates : ICSVStatecensus
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

            string[] lines = File.ReadAllLines(FilePath);

            if (lines.Contains("SrNo,StateName,TIN,StateCode"))
            {
                foreach (var line in lines)
                {
                    ////For delimeter
                    string[] LineCount = line.Split(delimiter);
                    if (LineCount.Length != 4 )
                        throw new CensusAnalyseException("INVALID_DELIMITER");
                }
                Dictionary<int, StateCodeClass> keyValues = new Dictionary<int, StateCodeClass>();
                int k = 0;
                for (int i = 1; i < lines.Length; i++)
                {
                    StateCodeClass sc = new StateCodeClass
                    {
                        SrNo = int.Parse(lines[i].Split(',')[0]),
                        StateName = lines[i].Split(',')[1].ToString(),
                        TIN = int.Parse(lines[i].Split(',')[2]),
                        StateCode = lines[i].Split(',')[3].ToString(),
                    };
                    keyValues.Add(k, sc);
                    k++;
                }
                return lines.Length;               
            }            
           throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");
        }
    }
}

