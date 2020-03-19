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
        public int LoadIndiaCSVData(string FilePath, char delimiter = ',')
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            string type = fileInfo.Extension;
            if (type != ".CSV" && type != ".csv")
                throw new CensusAnalyseException("INCORRECT_TYPE");

            if (!File.Exists(FilePath))
                throw new CensusAnalyseException("ERROR_IN_FILE_READING");

            string[] lines = File.ReadAllLines(FilePath);

            if (lines.Contains("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                foreach (var line in lines)
                {
                    ////For delimeter
                    string[] LineCount = line.Split(delimiter);
                    if (LineCount.Length != 4 && LineCount.Length != 2)
                        throw new CensusAnalyseException("INVALID_DELIMITER");
                }

                Dictionary<int, StateCensusClass> keyValues = new Dictionary<int, StateCensusClass>();
                int k = 0;
                for (int i = 1; i < lines.Length; i++)
                {
                    StateCensusClass sc = new StateCensusClass
                    {
                        State = lines[i].Split(',')[0].ToString(),
                        Population = int.Parse(lines[i].Split(',')[1]),
                        AreaInSqKm = int.Parse(lines[i].Split(',')[2]),
                        DensityPerSqKm = int.Parse(lines[i].Split(',')[3])
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

