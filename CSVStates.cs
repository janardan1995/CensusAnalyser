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

            Dictionary<int, StateCodeClass> dict = new Dictionary<int, StateCodeClass>();

            int k = 1;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string s21 = sr.ReadLine();
                int del = s21.Split(delimiter).Length;
                if (s21 != "SrNo,StateName,TIN,StateCode")
                {
                    throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");
                }
                else if(del!=4){                   
                        throw new CensusAnalyseException("INVALID_DELIMITER");
                }

                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s != "State,Population,AreaInSqKm,DensityPerSqKm")
                    {
                        StateCodeClass sc = new StateCodeClass
                        {
                            SrNo = int.Parse(s.Split(',')[0]),
                            StateName = s.Split(',')[1].ToString(),
                            TIN = int.Parse(s.Split(',')[2]),
                            StateCode = s.Split(',')[3].ToString(),
                        };

                        dict.Add(k, sc);
                        k++;
                    }
                }
            }
            return dict.Count;
        }
    }
}



