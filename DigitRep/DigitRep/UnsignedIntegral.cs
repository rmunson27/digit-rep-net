using Rem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

#region Concrete
/// <summary>
/// A representation of an unsigned integral value in a given <see cref="byte"/> base.
/// </summary>
/// <param name="Base">The base of the representation.</param>
/// <param name="Digits">The digits of the representation.</param>
/// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="Base"/> was less than 2
/// <para/>
/// OR
/// <para/>
/// <paramref name="Digits"/> contained a digit that was greater than or equal to <paramref name="Base"/>.
/// </exception>
public sealed record class ByteDigitRepresentation([GreaterThanOrEqualToInteger(2)] byte Base, ByteDigitList Digits)
    : UnsignedIntegralDigitRepresentation<byte>(Base)
{
    [GreaterThanOrEqualToInteger(2)] private protected override BigInteger BaseInternal => Base;

    private protected override DigitList<byte> GenericDigitsInternal => Digits;

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new ByteDigitList Digits { get; } = CheckBaseAndDigits(Digits, Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ByteDigitList CheckBaseAndDigits(ByteDigitList Digits, byte Base)
        => CheckDigits(Digits, Throw.IfArgLessThan<byte>(2, Base, nameof(Base)));
}

/// <summary>
/// A representation of an unsigned integral value in a given <see cref="ushort"/> base.
/// </summary>
/// <param name="Base">The base of the representation.</param>
/// <param name="Digits">The digits of the representation.</param>
/// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="Base"/> was less than 2
/// <para/>
/// OR
/// <para/>
/// <paramref name="Digits"/> contained a digit that was greater than or equal to <paramref name="Base"/>.
/// </exception>
public sealed record class UShortDigitRepresentation([GreaterThanOrEqualToInteger(2)] ushort Base, UShortDigitList Digits)
    : UnsignedIntegralDigitRepresentation<ushort>(Base)
{
    [GreaterThanOrEqualToInteger(2)] private protected override BigInteger BaseInternal => Base;

    private protected override DigitList<ushort> GenericDigitsInternal => Digits;

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new UShortDigitList Digits { get; } = CheckBaseAndDigits(Digits, Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static UShortDigitList CheckBaseAndDigits(UShortDigitList Digits, ushort Base)
        => CheckDigits(Digits, Throw.IfArgLessThan<ushort>(2, Base, nameof(Base)));
}

/// <summary>
/// A representation of an unsigned integral value in a given <see cref="uint"/> base.
/// </summary>
/// <param name="Base">The base of the representation.</param>
/// <param name="Digits">The digits of the representation.</param>
/// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="Base"/> was less than 2
/// <para/>
/// OR
/// <para/>
/// <paramref name="Digits"/> contained a digit that was greater than or equal to <paramref name="Base"/>.
/// </exception>
public sealed record class UIntDigitRepresentation([GreaterThanOrEqualToInteger(2)] uint Base, UIntDigitList Digits)
    : UnsignedIntegralDigitRepresentation<uint>(Base)
{
    [GreaterThanOrEqualToInteger(2)] private protected override BigInteger BaseInternal => Base;

    private protected override DigitList<uint> GenericDigitsInternal => Digits;

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new UIntDigitList Digits { get; } = CheckBaseAndDigits(Digits, Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static UIntDigitList CheckBaseAndDigits(UIntDigitList Digits, uint Base)
        => CheckDigits(Digits, Throw.IfArgLessThan(2u, Base, nameof(Base)));
}

/// <summary>
/// A representation of an unsigned integral value in a given <see cref="ulong"/> base.
/// </summary>
/// <param name="Base">The base of the representation.</param>
/// <param name="Digits">The digits of the representation.</param>
/// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="Base"/> was less than 2
/// <para/>
/// OR
/// <para/>
/// <paramref name="Digits"/> contained a digit that was greater than or equal to <paramref name="Base"/>.
/// </exception>
public sealed record class ULongDigitRepresentation([GreaterThanOrEqualToInteger(2)] ulong Base, ULongDigitList Digits)
    : UnsignedIntegralDigitRepresentation<ulong>(Base)
{
    [GreaterThanOrEqualToInteger(2)] private protected override BigInteger BaseInternal => Base;

    private protected override DigitList<ulong> GenericDigitsInternal => Digits;

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new ULongDigitList Digits { get; } = CheckBaseAndDigits(Digits, Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ULongDigitList CheckBaseAndDigits(ULongDigitList Digits, ulong Base)
        => CheckDigits(Digits, Throw.IfArgLessThan(2ul, Base, nameof(Base)));
}

/// <summary>
/// A representation of an unsigned integral value in a given <see cref="BigInteger"/> base.
/// </summary>
/// <param name="Base">The base of the representation.</param>
/// <param name="Digits">The digits of the representation.</param>
/// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="Base"/> was less than 2
/// <para/>
/// OR
/// <para/>
/// <paramref name="Digits"/> contained a digit that was greater than or equal to <paramref name="Base"/>.
/// </exception>
public sealed record class UnsignedBigIntegerDigitRepresentation(
    [GreaterThanOrEqualToInteger(2)] BigInteger Base, BigIntegerDigitList Digits)
    : UnsignedIntegralDigitRepresentation<BigInteger>(Base)
{
    [GreaterThanOrEqualToInteger(2)] private protected override BigInteger BaseInternal { get; } = Base;

    private protected override DigitList<BigInteger> GenericDigitsInternal => Digits;

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new BigIntegerDigitList Digits { get; } = CheckBaseAndDigits(Digits, Base);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static BigIntegerDigitList CheckBaseAndDigits(BigIntegerDigitList Digits, BigInteger Base)
        => CheckDigits(Digits, Throw.IfArgLessThan(2, Base, nameof(Base)));
}
#endregion

#region Abstract
/// <summary>
/// A representation of an unsigned integral value in a given generic base.
/// </summary>
public abstract record class UnsignedIntegralDigitRepresentation<TDigit> : UnsignedIntegralDigitRepresentation
{
    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Base"/>
    [GreaterThanOrEqualToInteger(2)] public new TDigit Base { get; }

    /// <inheritdoc cref="UnsignedIntegralDigitRepresentation.Digits"/>
    public new DigitList<TDigit> Digits => GenericDigitsInternal;

    private protected sealed override DigitList DigitsInternal => GenericDigitsInternal;

    /// <summary>
    /// Allows subclasses to override <see cref="Digits"/> with subclasses of <see cref="DigitList{TDigit}"/>, while
    /// also ensuring this class cannot be extended outside of this assembly.
    /// </summary>
    private protected abstract DigitList<TDigit> GenericDigitsInternal { get; }

    /// <summary>
    /// Initializes the base of the representation.
    /// </summary>
    /// <param name="Base"></param>
    private protected UnsignedIntegralDigitRepresentation(TDigit Base)
    {
        this.Base = Base;
    }

    /// <summary>
    /// Deconstructs the current instance.
    /// </summary>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    public void Deconstruct([GreaterThanOrEqualToInteger(2)] out TDigit Base, out DigitList<TDigit> Digits)
    {
        Base = this.Base;
        Digits = this.Digits;
    }
}

/// <summary>
/// A representation of an unsigned integral value in a given base.
/// </summary>
public abstract record class UnsignedIntegralDigitRepresentation
{
    /// <summary>
    /// Gets the base of the representation.
    /// </summary>
    [GreaterThanOrEqualToInteger(2)] public BigInteger Base => BaseInternal;

    /// <summary>
    /// Allows subclasses to override <see cref="Base"/> with a smaller integral type, while also
    /// ensuring this class cannot be extended outside of this assembly.
    /// </summary>
    [GreaterThanOrEqualToInteger(2)] private protected abstract BigInteger BaseInternal { get; }

    /// <summary>
    /// Gets the digits of the representation.
    /// </summary>
    public DigitList Digits => DigitsInternal;

    /// <summary>
    /// Allows subclasses to override <see cref="Digits"/> with subclasses of <see cref="DigitList"/>, while also
    /// ensuring this class cannot be extended outside of this assembly.
    /// </summary>
    private protected abstract DigitList DigitsInternal { get; }

    /// <summary>
    /// Checks that the digits in the list are less than the base.
    /// </summary>
    /// <typeparam name="TDigitList"></typeparam>
    /// <typeparam name="TDigit"></typeparam>
    /// <param name="Digits"></param>
    /// <param name="Base"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private protected static TDigitList CheckDigits<TDigitList, TDigit>(TDigitList Digits, TDigit Base)
        where TDigitList : DigitList<TDigit>
        where TDigit : IComparable<TDigit>
    {
        foreach (var digit in Throw.IfArgNull(Digits, nameof(Digits)))
        {
            if (digit.CompareTo(Base) >= 0)
            {
                throw new ArgumentOutOfRangeException(
                    null, $"Digit was greater than or equal to base value (Digit: {digit}, Base: {Base}).");
            }
        }

        return Digits;
    }

    /// <summary>
    /// Deconstructs the current instance.
    /// </summary>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    public void Deconstruct([GreaterThanOrEqualToInteger(2)] out BigInteger Base, out DigitList Digits)
    {
        Base = this.Base;
        Digits = this.Digits;
    }
}
#endregion
