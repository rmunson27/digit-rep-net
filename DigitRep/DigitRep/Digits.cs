using Rem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

/// <summary>
/// Static functionality relating to digits as supported by this library.
/// </summary>
public static class Digits
{
    /// <summary>
    /// An empty digit list.
    /// </summary>
    public static readonly DigitList EmptyList = new ByteDigitList(ImmutableArray<byte>.Empty);

    /// <summary>
    /// Gets a list of digits representing the given <see cref="BigInteger"/> value in the given base.
    /// </summary>
    /// <param name="value">The value to represent.</param>
    /// <param name="base">The base of the representation to create.</param>
    /// <param name="includeZeroIfZero">
    /// Whether or not to return a digit list containing a single zero digit if <paramref name="value"/> is zero.
    /// <para/>
    /// If this parameter is <see langword="false"/>, the resulting digit list will be empty if
    /// <paramref name="value"/> is zero.
    /// </param>
    /// <remarks>
    /// The digit list returned when <paramref name="value"/> is zero will be empty.
    /// </remarks>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="value"/> was negative
    /// <para/>
    /// OR
    /// <para/>
    /// <paramref name="base"/> was less than or equal to 1.
    /// </exception>
    public static DigitList GetList([NonNegative] BigInteger value, BigInteger @base, bool includeZeroIfZero = true)
    {
        // Validate
        Throw.IfArgNegative(value, nameof(value));
        ValidateBaseArg(@base, nameof(@base));

        // Build digit list
        var builder = SmallestRange(@base).CreateListBuilder();
        while (!value.IsZero)
        {
            value = BigInteger.DivRem(value, @base, out var remainder);
            builder.Add(remainder);
        }
        if (includeZeroIfZero && builder.Count == 0) builder.Add(0);
        return builder.ToList();
    }

    /// <summary>
    /// Creates a new <see cref="DigitList.Builder"/> capable of constructing a list of digits in the current range.
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumArgumentException">The current range was an unnamed enum value.</exception>
    public static DigitList.Builder CreateListBuilder(this Range range)
        => Throw.IfEnumArgUnnamed(range, nameof(range)) switch
        {
            Range.Byte => new ByteDigitList.Builder(),
            Range.UShort => new UShortDigitList.Builder(),
            Range.UInt => new UIntDigitList.Builder(),
            Range.ULong => new ULongDigitList.Builder(),
            _ => new BigIntegerDigitList.Builder(),
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static BigInteger ValidateBaseArg(BigInteger @base, string argName)
        => Throw.IfArgLessThanOrEqualTo(1, @base, argName);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static BigInteger InitializeBase(
        ref BigInteger field, BigInteger @base, [CallerMemberName] string? propertyName = null)
        => field = Throw.IfPropSetLessThanOrEqualTo(1, @base, propertyName);

    /// <summary>
    /// Gets the smallest range capable of representing digits in the given base.
    /// </summary>
    /// <param name="Base"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="Base"/> was less than or equal to 1.</exception>
    [return: NameableEnum]
    public static Range SmallestRange(BigInteger Base)
    {
        Throw.IfArgLessThanOrEqualTo(1, Base, nameof(Base));

        if (Base <= byte.MaxValue) return Range.Byte;
        if (Base <= ushort.MaxValue) return Range.UShort;
        if (Base <= uint.MaxValue) return Range.UInt;
        if (Base <= ulong.MaxValue) return Range.ULong;
        return Range.BigInteger;
    }

    /// <summary>
    /// Represents the ranges of digits supported by this library.
    /// </summary>
    public enum Range : byte
    {
        /// <summary>
        /// Represents a digit that fits into a <see cref="byte"/>.
        /// </summary>
        Byte,

        /// <summary>
        /// Represents a digit that fits into a <see cref="ushort"/>.
        /// </summary>
        UShort,

        /// <summary>
        /// Represents a digit that fits into a <see cref="uint"/>.
        /// </summary>
        UInt,

        /// <summary>
        /// Represents a digit that fits into a <see cref="ulong"/>.
        /// </summary>
        ULong,

        /// <summary>
        /// Represents a digit that fits into a (non-negative) <see cref="System.Numerics.BigInteger"/>.
        /// </summary>
        BigInteger,
    }
}

