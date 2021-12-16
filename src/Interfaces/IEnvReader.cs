﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotEnv.Core
{
    /// <summary>
    /// Defines the methods used to read the value of an environment variable from the current process.
    /// </summary>
    public interface IEnvReader : IEnumerable<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Gets the value of an environment variable in <c>string</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <value>The value of the variable in <c>string</c> format.</value>
        /// <exception cref="EnvVariableNotFoundException"><c>variable</c> is not found in the current process.</exception>
        string this[string variable] { get; }
        /// <summary>
        /// Gets the value of an environment variable in <c>string</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>string</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException"><c>variable</c> is not found in the current process.</exception>
        string GetStringValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>bool</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>bool</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>bool</c> format.</exception>
        bool GetBoolValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>byte</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>byte</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>byte</c> format.</exception>
        byte GetByteValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>sbyte</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>sbyte</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>sbyte</c> format.</exception>
        sbyte GetSByteValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>char</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>char</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>char</c> format.</exception>
        char GetCharValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>int</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>int</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>int</c> format.</exception>
        int GetIntValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>uint</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>uint</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>uint</c> format.</exception>
        uint GetUIntValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>long</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>long</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>long</c> format.</exception>
        long GetLongValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>ulong</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>ulong</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ulong</c> format.</exception>
        ulong GetULongValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>short</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>short</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>short</c> format.</exception>
        short GetShortValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>ushort</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>ushort</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ushort</c> format.</exception>
        ushort GetUShortValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>decimal</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>decimal</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>decimal</c> format.</exception>
        decimal GetDecimalValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>double</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>double</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>double</c> format.</exception>
        double GetDoubleValue(string variable);
        /// <summary>
        /// Gets the value of an environment variable in <c>float</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to get.</param>
        /// <returns>A value of the variable in <c>float</c> format.</returns>
        /// <exception cref="EnvVariableNotFoundException">If the <c>variable</c> is not found in the current process.</exception>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>float</c> format.</exception>
        float GetFloatValue(string variable);

        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>string</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The string value retrieved or <c>null</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        bool TryGetStringValue(string variable, out string value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>bool</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The bool value retrieved or <c>false</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>bool</c> format.</exception>
        bool TryGetBoolValue(string variable, out bool value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>byte</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The byte value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>byte</c> format.</exception>
        bool TryGetByteValue(string variable, out byte value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>sbyte</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The sbyte value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>sbyte</c> format.</exception>
        bool TryGetSByteValue(string variable, out sbyte value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>char</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The char value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>char</c> format.</exception>
        bool TryGetCharValue(string variable, out char value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>int</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The int value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>int</c> format.</exception>
        bool TryGetIntValue(string variable, out int value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>uint</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The uint value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>uint</c> format.</exception>
        bool TryGetUIntValue(string variable, out uint value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>long</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The long value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>long</c> format.</exception>
        bool TryGetLongValue(string variable, out long value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>ulong</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The ulong value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ulong</c> format.</exception>
        bool TryGetULongValue(string variable, out ulong value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>short</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The short value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>short</c> format.</exception>
        bool TryGetShortValue(string variable, out short value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>ushort</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The ushort value retrieved or <c>0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ushort</c> format.</exception>
        bool TryGetUShortValue(string variable, out ushort value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>decimal</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The decimal value retrieved or <c>0.0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>decimal</c> format.</exception>
        bool TryGetDecimalValue(string variable, out decimal value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>double</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The double value retrieved or <c>0.0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>double</c> format.</exception>
        bool TryGetDoubleValue(string variable, out double value);
        /// <summary>
        /// Try to retrieve the value of an environment variable in <c>float</c> format.
        /// </summary>
        /// <param name="variable">The variable name of the value to try retrieve.</param>
        /// <param name="value">The float value retrieved or <c>0.0</c>.</param>
        /// <returns><c>true</c> if the environment variable exists in the current process, otherwise <c>false</c>.</returns>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>float</c> format.</exception>
        bool TryGetFloatValue(string variable, out float value);

        /// <summary>
        /// Gets the value of an environment variable in <c>string</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>string</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        string EnvString(string variable, string defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>bool</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>bool</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>bool</c> format.</exception>
        bool EnvBool(string variable, bool defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>byte</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>byte</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>byte</c> format.</exception>
        byte EnvByte(string variable, byte defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>sbyte</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>sbyte</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>sbyte</c> format.</exception>
        sbyte EnvSByte(string variable, sbyte defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>char</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>char</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>char</c> format.</exception>
        char EnvChar(string variable, char defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>int</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>int</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>int</c> format.</exception>
        int EnvInt(string variable, int defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>uint</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>uint</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>uint</c> format.</exception>
        uint EnvUInt(string variable, uint defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>long</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>long</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>long</c> format.</exception>
        long EnvLong(string variable, long defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>ulong</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>ulong</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ulong</c> format.</exception>
        ulong EnvULong(string variable, ulong defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>short</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>short</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>short</c> format.</exception>
        short EnvShort(string variable, short defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>ushort</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>ushort</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>ushort</c> format.</exception>
        ushort EnvUShort(string variable, ushort defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>decimal</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>decimal</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>decimal</c> format.</exception>
        decimal EnvDecimal(string variable, decimal defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>double</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>double</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>double</c> format.</exception>
        double EnvDouble(string variable, double defaultValue = default);
        /// <summary>
        /// Gets the value of an environment variable in <c>float</c> format.
        /// </summary>
        /// <param name="variable">	Environment variable name.</param>
        /// <param name="defaultValue">A default value in case the environment variable is not found in the current process.</param>
        /// <returns>A value of the environment variable in <c>float</c> format.</returns>
        /// <remarks>If the environment variable does not exist in the current process, the method will return the default value.</remarks>
        /// <exception cref="FormatException">If the <c>value</c> is not in <c>float</c> format.</exception>
        float EnvFloat(string variable, float defaultValue = default);
    }
}