using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectDemo
{
    /// <summary>
    /// Class Greeting
    /// </summary>
    public class Greeting
    {
        #region Fields

        #endregion

        #region Properties

        public string Message { get; set; }

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        /// Tra ve messge hello
        /// </summary>
        /// <returns>Message Hello</returns>
        public string GetMessage()
        {
            Message = "Hello";
            //Logic Code phuc tap 
            return Message;
        }

        #endregion

    }
}
