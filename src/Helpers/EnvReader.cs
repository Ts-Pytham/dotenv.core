﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static DotEnv.Core.ExceptionMessages;
using static System.Environment;

namespace DotEnv.Core
{
    /// <inheritdoc cref="IEnvReader" />
    public partial class EnvReader : IEnvReader
    {
        private static EnvReader s_instance = new EnvReader();

        /// <summary>
        /// Gets an instance of type <see cref="EnvReader" />.
        /// </summary>
        /// <remarks>This method is thread-safe.</remarks>
        public static EnvReader Instance => s_instance;

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (DictionaryEntry de in GetEnvironmentVariables())
                yield return new KeyValuePair<string, string>((string)de.Key, (string)de.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        /// <inheritdoc />
        public virtual string this[string variable] => GetStringValue(variable);

        /// <inheritdoc />
        public virtual string GetStringValue(string variable)
        {
            if (TryGetStringValue(variable, out string value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual bool GetBoolValue(string variable)
        {
            if (TryGetBoolValue(variable, out bool value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual byte GetByteValue(string variable)
        {
            if (TryGetByteValue(variable, out byte value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual sbyte GetSByteValue(string variable)
        {
            if (TryGetSByteValue(variable, out sbyte value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual char GetCharValue(string variable)
        {
            if (TryGetCharValue(variable, out char value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual int GetIntValue(string variable)
        {
            if (TryGetIntValue(variable, out int value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual uint GetUIntValue(string variable)
        {
            if (TryGetUIntValue(variable, out uint value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual long GetLongValue(string variable)
        {
            if (TryGetLongValue(variable, out long value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual ulong GetULongValue(string variable)
        {
            if (TryGetULongValue(variable, out ulong value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual short GetShortValue(string variable)
        {
            if (TryGetShortValue(variable, out short value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual ushort GetUShortValue(string variable)
        {
            if (TryGetUShortValue(variable, out ushort value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual decimal GetDecimalValue(string variable)
        {
            if (TryGetDecimalValue(variable, out decimal value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual double GetDoubleValue(string variable)
        {
            if (TryGetDoubleValue(variable, out double value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }

        /// <inheritdoc />
        public virtual float GetFloatValue(string variable)
        {
            if (TryGetFloatValue(variable, out float value))
                return value;

            throw new EnvVariableNotFoundException(VariableNotFoundMessage, variable);
        }
    }
}