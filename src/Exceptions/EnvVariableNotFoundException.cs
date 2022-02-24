﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotEnv.Core
{
    /// <summary>
    /// The exception that is thrown when the environment variable is not found in the current process.
    /// </summary>
    public class EnvVariableNotFoundException : Exception
    {
        private readonly string _variableName;

        /// <summary>
        /// Allows access to the name of the variable that causes the exception.
        /// </summary>
        public string VariableName => _variableName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvVariableNotFoundException" /> class with the a specified error message and variable name.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="variableName">The variable name that caused the exception.</param>
        public EnvVariableNotFoundException(
            string message, 
            string variableName = null) : base(message)
        {
            _variableName = variableName;
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message => FormatErrorMessage(base.Message, _variableName);

        /// <summary>
        /// Formats an error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="variableName">The variable name that caused the error.</param>
        /// <returns>A formatted error message.</returns>
        internal static string FormatErrorMessage(string message, string variableName)
            => variableName != null ? $"{message} (Variable Name: {variableName})" : message;
    }
}
