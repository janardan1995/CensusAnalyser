// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAnalyseException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System;
   
    /// <summary>
    /// MyCustomException class for CensusAnalyser
    /// </summary>
    public class CensusAnalyseException :Exception
    {
        /// <summary>
        /// constructor create which has a parameter like its parent class Exception
        /// </summary>
        /// <param name="message"></param>
        public CensusAnalyseException(string message) : base(message)
        {
        }      
    }
}
