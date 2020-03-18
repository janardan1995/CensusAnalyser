// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVBuilder.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System;

    /// <summary>
    /// create a delegate for builder class
    /// </summary>
    /// <param name="statecensus">its a interface</param>
    /// <param name="FileName">our original file</param>
    /// <param name="delimiter">optional</param>
    /// <returns>its return object</returns>
    public delegate int DelegateCSVDirector(ICSVStatecensus statecensus, String FileName, char delimiter = ',');

    public class CSVBuilder
    {
        /// <summary>
        /// this is Director class in builder
        /// </summary>
        /// <param name="statecensus">interface</param>
        /// <param name="FileName">file path</param>
        /// <param name="delimiter">optional</param>
        /// <returns>returns object</returns>
        public int CSVDirector(ICSVStatecensus statecensus, String FileName, char delimiter = ',')
        {
            try
            {
                int csv = statecensus.LoadIndiaCSVData(FileName, delimiter);
                return csv;
            }
            catch (CensusAnalyseException e)
            {
                if (e.Message == "INCORRECT_TYPE")
                    throw new CensusAnalyseException(MyEnum.INCORRECT_TYPE.ToString());
                if (e.Message == "ERROR_IN_FILE_READING")
                    throw new CensusAnalyseException(MyEnum.ERROR_IN_FILE_READING.ToString());
                if (e.Message == "HEADER_IS_NOT_FOUND")
                    throw new CensusAnalyseException(MyEnum.HEADER_IS_NOT_FOUND.ToString());
                if (e.Message == "INVALID_DELIMITER")
                    throw new CensusAnalyseException(MyEnum.INVALID_DELIMITER.ToString());
                return 0;
            }
        }
    }
}


