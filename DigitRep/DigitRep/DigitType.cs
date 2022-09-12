using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Numerics.Digits;

/// <summary>
/// Represents the storage type of a digit.
/// </summary>
public enum DigitType : byte
{
    /// <summary>
    /// Represents an 8-bit <see cref="byte"/> digit.
    /// </summary>
    Byte = 1,

    /// <summary>
    /// Represents a 16-bit <see cref="ushort"/> digit.
    /// </summary>
    UShort = 2,

    /// <summary>
    /// Represents a 32-bit <see cref="uint"/> digit.
    /// </summary>
    UInt = 4,

    /// <summary>
    /// Represents a 64-bit <see cref="ulong"/> digit.
    /// </summary>
    ULong = 8,

    /// <summary>
    /// Represents an arbitrary precision <see cref="System.Numerics.BigInteger"/> digit.
    /// </summary>
    BigInteger = 255,
}

