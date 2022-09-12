using Rem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Numerics.Digits;

/// <summary>
/// Helpers for finding the minimum required size of digits in a given base.
/// </summary>
internal static class BaseDigitSize
{
    private static readonly BigInteger MaxULongDigitBase = ulong.MaxValue + BigInteger.One;
    private const ulong MaxUIntDigitBase = uint.MaxValue + 1uL;
    private const uint MaxUShortDigitBase = ushort.MaxValue + 1u;
    private const ushort MaxByteDigitBase = 256;

    /// <inheritdoc cref="Min(ushort)"/>
    public static BigIntegerBaseDigitSize Min([GreaterThanOrEqualToInteger(2)] BigInteger Base)
        => Base.CompareTo(MaxULongDigitBase) switch
        {
            > 0 => BigIntegerBaseDigitSize.BigInteger,
            0 => BigIntegerBaseDigitSize.ULong,
            < 0 => (BigIntegerBaseDigitSize)MinInternal((ulong)Base),
        };

    /// <inheritdoc cref="Min(ushort)"/>
    public static ULongBaseDigitSize Min([GreaterThanOrEqualToInteger(2)] ulong Base) => MinInternal(Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ULongBaseDigitSize MinInternal([GreaterThanOrEqualToInteger(2)] ulong Base) => Base switch
    {
        > MaxUIntDigitBase => ULongBaseDigitSize.ULong,
        > MaxUShortDigitBase => ULongBaseDigitSize.UInt,
        > MaxByteDigitBase => ULongBaseDigitSize.UShort,
        _ => ULongBaseDigitSize.Byte,
    };

    /// <inheritdoc cref="Min(ushort)"/>
    public static UIntBaseDigitSize Min([GreaterThanOrEqualToInteger(2)] uint Base) => Base switch
    {
        > MaxUShortDigitBase => UIntBaseDigitSize.UInt,
        > MaxByteDigitBase => UIntBaseDigitSize.UShort,
        _ => UIntBaseDigitSize.Byte,
    };

    /// <summary>
    /// Gets a value representing the smallest possible integral representation of digits in the given base.
    /// </summary>
    /// <param name="Base"></param>
    /// <returns></returns>
    public static UShortBaseDigitSize Min([GreaterThanOrEqualToInteger(2)] ushort Base)
        => Base > MaxByteDigitBase ? UShortBaseDigitSize.UShort : UShortBaseDigitSize.Byte;
}

/// <summary>
/// Represents the minimum required size of a digit in a base represented by a <see cref="ushort"/>.
/// </summary>
internal enum UShortBaseDigitSize : byte
{
    Byte = BigIntegerBaseDigitSize.Byte,
    UShort = BigIntegerBaseDigitSize.UShort,
}

/// <summary>
/// Represents the minimum required size of a digit in a base represented by a <see cref="uint"/>.
/// </summary>
internal enum UIntBaseDigitSize : byte
{
    Byte = BigIntegerBaseDigitSize.Byte,
    UShort = BigIntegerBaseDigitSize.UShort,
    UInt = BigIntegerBaseDigitSize.UInt,
}

/// <summary>
/// Represents the minimum required size of a digit in a base represented by a <see cref="ulong"/>.
/// </summary>
internal enum ULongBaseDigitSize : byte
{
    Byte = BigIntegerBaseDigitSize.Byte,
    UShort = BigIntegerBaseDigitSize.UShort,
    UInt = BigIntegerBaseDigitSize.UInt,
    ULong = BigIntegerBaseDigitSize.ULong
}

/// <summary>
/// Represents the minimum required size of a digit in a base represented by a <see cref="System.Numerics.BigInteger"/>.
/// </summary>
internal enum BigIntegerBaseDigitSize : byte
{
    Byte = 1,
    UShort = 2,
    UInt = 4,
    ULong = 8,
    BigInteger = 255,
}
