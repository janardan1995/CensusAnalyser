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
    /// This is CSVStateANDCode class where
    /// both two class csv statedata and statecode merge
    /// </summary>   
    public class CSVStateANDCode : ICSVStatecensus
    {
        /// <summary>
        /// In this method load csv data for india
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

            int k = 1;
            using (StreamReader sr = new StreamReader(FilePath))
            {
                string s21 = sr.ReadLine();
                int del = s21.Split(delimiter).Length;
                if (s21 != "SrNo,StateName,TIN,StateCode" && s21 != "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");
                }
                else if (del != 4)
                {
                    throw new CensusAnalyseException("INVALID_DELIMITER");
                }
                else if (s21 == "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    Dictionary<int, StateCensusClass> dict = new Dictionary<int, StateCensusClass>();
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s != "State,Population,AreaInSqKm,DensityPerSqKm")
                        {
                            StateCensusClass sc = new StateCensusClass
                            {
                                State = s.Split(',')[0].ToString(),
                                Population = int.Parse(s.Split(',')[1]),
                                AreaInSqKm = int.Parse(s.Split(',')[2]),
                                DensityPerSqKm = int.Parse(s.Split(',')[3])
                            };

                            dict.Add(k, sc);
                            k++;
                        }
                    }
                    return dict.Count;
                }
                
                else if (s21 == "SrNo,StateName,TIN,StateCode")
                {
                    Dictionary<int, StateCodeClass> dict = new Dictionary<int, StateCodeClass>();
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
                    return dict.Count;
                }
                return 0;
            }           
        }
    }
}




