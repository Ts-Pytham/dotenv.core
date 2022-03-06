﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotEnv.Core
{
    /// <summary>
    /// Represents the environment variables provider.
    /// </summary>
    public interface IEnvironmentVariablesProvider : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Gets or sets the value of the variable.
        /// </summary>
        /// <param name="variable">The variable to get or set.</param>
        string this[string variable] { get; set; }
    }
}