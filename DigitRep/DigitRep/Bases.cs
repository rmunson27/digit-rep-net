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
/// Helper methods relating to integral bases.
/// </summary>
public static class Bases
{
    private static readonly BigInteger MaxULongDigitBase = ulong.MaxValue + BigInteger.One;
    private const ulong MaxUIntDigitBase = uint.MaxValue + 1uL;
    private const uint MaxUShortDigitBase = ushort.MaxValue + 1u;
    private const ushort MaxByteDigitBase = 256;

    /// <inheritdoc cref="ShortestDigitType(ushort)"/>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="Base"/> was negative.</exception>
    public static DigitType ShortestDigitType([GreaterThanOrEqualToInteger(2)] BigInteger Base)
        => Throw.IfArgLessThan(2, Base, nameof(Base)).CompareTo(MaxULongDigitBase) switch
        {
            > 0 => DigitType.BigInteger,
            0 => DigitType.ULong,
            < 0 => ShortestDigitTypeInternal((ulong)Base),
        };

    /// <inheritdoc cref="ShortestDigitType(ushort)"/>
    public static DigitType ShortestDigitType([GreaterThanOrEqualToInteger(2)] ulong Base)
        => ShortestDigitTypeInternal(Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static DigitType ShortestDigitTypeInternal([GreaterThanOrEqualToInteger(2)] ulong Base) => Base switch
    {
        > MaxUIntDigitBase => DigitType.ULong,
        > MaxUShortDigitBase => DigitType.UInt,
        > MaxByteDigitBase => DigitType.UShort,
        _ => DigitType.Byte,
    };

    /// <inheritdoc cref="ShortestDigitType(ushort)"/>
    public static DigitType ShortestDigitType([GreaterThanOrEqualToInteger(2)] uint Base) => Base switch
    {
        > MaxUShortDigitBase => DigitType.UInt,
        > MaxByteDigitBase => DigitType.UShort,
        _ => DigitType.Byte,
    };

    /// <summary>
    /// Gets a value representing the shortest possible integral representation of digits in the given base.
    /// </summary>
    /// <param name="Base"></param>
    /// <returns></returns>
    public static DigitType ShortestDigitType([GreaterThanOrEqualToInteger(2)] ushort Base)
        => Base > MaxByteDigitBase ? DigitType.UShort : DigitType.Byte;
}
