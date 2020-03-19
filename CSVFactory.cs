// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVFactory.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    /// <summary>
    /// This is factory class
    /// </summary>
    public class CSVFactory
    {
        /// <summary>
        /// reference of interface class
        /// </summary>
        IAdapter xx;

        /// <summary>
        /// this is a method
        /// </summary>
        /// <param name="className">concrete class</param>
        /// <returns>its return interface object</returns>
        public IAdapter createInstance(string className)
        {
            if (className == "AdapterClass")            
                xx = new AdapterClass();          
            return xx;
        }
    }
}
