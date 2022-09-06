using Rem.Core.Attributes;
using Rem.Core.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

#region Classes
#region Concrete
/// <summary>
/// A wrapper for a list of <see cref="byte"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class ByteDigitList([NonDefaultableStruct] ImmutableArray<byte> Digits)
    : DigitList<byte>(Digits), IByteDigitList
{
    #region Index
    ushort IUShortDigitList.this[int index] => Digits[index];

    uint IUIntDigitList.this[int index] => Digits[index];

    ulong IULongDigitList.this[int index] => Digits[index];

    [return: NonNegative]
    private protected override BigInteger IndexInternal([NonNegative] int index)
        => Digits[index];
    #endregion

    #region IEnumerable
    IEnumerator<ushort> IEnumerable<ushort>.GetEnumerator()
    {
        foreach (var b in Digits) yield return b;
    }

    IEnumerator<uint> IEnumerable<uint>.GetEnumerator()
    {
        foreach (var b in Digits) yield return b;
    }

    IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
    {
        foreach (var b in Digits) yield return b;
    }

    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var b in Digits) yield return b;
    }
    #endregion

    /// <summary>
    /// A builder for a <see cref="ByteDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<byte>.Builder
    {
        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="byte"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((byte)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList<byte> ToGenericListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new ByteDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="ushort"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class UShortDigitList([NonDefaultableStruct] ImmutableArray<ushort> Digits)
    : DigitList<ushort>(Digits), IUShortDigitList
{
    #region Index
    uint IUIntDigitList.this[int index] => Digits[index];

    ulong IULongDigitList.this[int index] => Digits[index];

    [return: NonNegative]
    private protected override BigInteger IndexInternal([NonNegative] int index) => Digits[index];
    #endregion

    #region IEnumerable
    IEnumerator<uint> IEnumerable<uint>.GetEnumerator()
    {
        foreach (var us in Digits) yield return us;
    }

    IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
    {
        foreach (var us in Digits) yield return us;
    }

    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var us in Digits) yield return us;
    }
    #endregion

    /// <summary>
    /// A builder for a <see cref="UShortDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<ushort>.Builder
    {
        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ushort"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((ushort)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList<ushort> ToGenericListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new UShortDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="uint"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class UIntDigitList([NonDefaultableStruct] ImmutableArray<uint> Digits)
    : DigitList<uint>(Digits), IUIntDigitList
{
    #region Index
    /// <inheritdoc cref="DigitList.this[int]"/>
    public new uint this[[NonNegative] int index] => Digits[index];

    ulong IULongDigitList.this[int index] => Digits[index];

    [return: NonNegative]
    private protected override BigInteger IndexInternal([NonNegative] int index) => Digits[index];
    #endregion

    #region IEnumerable
    IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
    {
        foreach (var ui in Digits) yield return ui;
    }

    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var ui in Digits) yield return ui;
    }
    #endregion

    /// <summary>
    /// A builder for a <see cref="UIntDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<uint>.Builder
    {
        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="uint"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((uint)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList<uint> ToGenericListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new UIntDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="ulong"/> digits.
/// </summary>
/// <param name="Digits">The list of digits to wrap.</param>
/// <exception cref="StructArgumentDefaultException">
/// <paramref name="Digits"/> was default.
/// </exception>
public sealed record class ULongDigitList([NonDefaultableStruct] ImmutableArray<ulong> Digits)
    : DigitList<ulong>(Digits), IULongDigitList
{
    /// <inheritdoc cref="DigitList.this[int]"/>
    public new ulong this[[NonNegative] int index] => Digits[index];

    [return: NonNegative]
    private protected override BigInteger IndexInternal([NonNegative] int index) => Digits[index];

    /// <inheritdoc cref="DigitList.GetEnumerator"/>
    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var ul in Digits) yield return ul;
    }

    /// <summary>
    /// A builder for a <see cref="ULongDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<ulong>.Builder
    {
        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ulong"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((ulong)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList<ulong> ToGenericListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new ULongDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="BigInteger"/> digits.
/// </summary>
public sealed record class BigIntegerDigitList : DigitList<BigInteger>
{
    [return: NonNegative] private protected override BigInteger IndexInternal([NonNegative] int index)
        => Digits[index];

    /// <summary>
    /// Constructs a new instance of the <see cref="BigIntegerDigitList"/> class with the list of digits to wrap.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="StructArgumentDefaultException">
    /// <paramref name="Digits"/> was default.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="Digits"/> contained a negative number.
    /// </exception>
    public BigIntegerDigitList([NonDefaultableStruct] ImmutableArray<BigInteger> Digits) : base(Digits)
    {
        foreach (var digit in Digits)
        {
            if (digit < 0) throw new ArgumentException("Cannot construct a digit list with negative digits.");
        }
    }

    /// <inheritdoc cref="DigitList.GetEnumerator"/>
    public new ImmutableArray<BigInteger>.Enumerator GetEnumerator() => Digits.GetEnumerator();

    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var bi in Digits) yield return bi;
    }

    /// <summary>
    /// A builder for a <see cref="BigIntegerDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<BigInteger>.Builder
    {
        /// <inheritdoc/>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add(Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList<BigInteger> ToGenericListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new BigIntegerDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}
#endregion

#region Abstract
/// <summary>
/// A wrapper for a list of digits of a specific generic type.
/// </summary>
/// <typeparam name="TDigit">
/// The type of digit stored in the list.
/// <para/>
/// This class cannot be extended outside of this assembly; therefore, the only possible values of this parameter are
/// <see cref="byte"/>, <see cref="ushort"/>, <see cref="uint"/>, <see cref="ulong"/> and <see cref="BigInteger"/>.
/// </typeparam>
/// <param name="Digits">The list of digits to wrap.</param>
/// <exception cref="StructArgumentDefaultException"><paramref name="Digits"/> was the default.</exception>
public abstract record class DigitList<TDigit>(
    [NonDefaultableStruct] ImmutableArray<TDigit> Digits) : DigitList, IEnumerable<TDigit>
{
    /// <inheritdoc cref="DigitList.this[int]"/>
    public new TDigit this[[NonNegative] int index] => Digits[index];

    /// <inheritdoc/>
    public sealed override int Count => Digits.Length;

    /// <summary>
    /// Gets an immutable array containing the digits the list is comprised of.
    /// </summary>
    [NonDefaultableStruct] public ImmutableArray<TDigit> Digits { get; }
        = Throw.IfStructArgDefault(Digits, nameof(Digits));

    private protected sealed override IEnumerator GetNonGenericEnumeratorInternal()
    {
        foreach (var d in Digits) yield return d;
    }

    /// <summary>
    /// Returns an <see cref="IEnumerator{T}"/> that can be used to iterate through the digits of the list.
    /// </summary>
    /// <returns></returns>
    public new ImmutableArray<TDigit>.Enumerator GetEnumerator() => Digits.GetEnumerator();

    IEnumerator<TDigit> IEnumerable<TDigit>.GetEnumerator()
    {
        foreach (var d in Digits) yield return d;
    }

    /// <summary>
    /// A builder for a <see cref="DigitList{TDigit}"/>.
    /// </summary>
    public abstract new class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public sealed override int Count => _listBuilder.Count;

        private protected readonly ImmutableArray<TDigit>.Builder _listBuilder
            = ImmutableArray.CreateBuilder<TDigit>();

        private protected sealed override DigitList ToListInternal() => ToGenericListInternal();

        /// <inheritdoc cref="DigitList.Builder.ToListInternal"/>
        private protected abstract DigitList<TDigit> ToGenericListInternal();
    }
}

/// <summary>
/// A wrapper for a list of digits.
/// </summary>
/// <remarks>
/// This class is particularly useful in cases where a large number of digits need to be represented in an arbitrary
/// base.
/// If the base is small but the digit count is large, this class can save programmers lots of memory by allowing the
/// digits to be represented as a list of <see cref="byte"/> values rather than a list of a more memory-intensive type.
/// </remarks>
public abstract record class DigitList : IDigitList
{
    /// <inheritdoc/>
    [NonNegative] public abstract int Count { get; }

    /// <inheritdoc/>
    [NonNegative] public BigInteger this[[NonNegative] int index] => IndexInternal(index);

    /// <summary>
    /// Allows <see cref="this[int]"/> to be implemented on a smaller numeric type in subclasses, while also ensuring
    /// this class cannot be extended outside of this assembly.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    [return: NonNegative] private protected abstract BigInteger IndexInternal([NonNegative] int index);

    IEnumerator IEnumerable.GetEnumerator() => GetNonGenericEnumeratorInternal();

    /// <summary>
    /// Allows <see cref="IEnumerable.GetEnumerator"/> to be implemented on a smaller generic numeric type, and also
    /// prevents this class from being extended outside of this assembly.
    /// </summary>
    /// <returns></returns>
    private protected abstract IEnumerator GetNonGenericEnumeratorInternal();

    /// <summary>
    /// Returns an enumerator that iterates through the digit list.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<BigInteger> GetEnumerator() => GetEnumeratorInternal();

    /// <summary>
    /// Allows <see cref="GetEnumerator"/> to be implemented on a smaller generic numeric type, and also prevents this
    /// class from being extended outside of this assembly.
    /// </summary>
    /// <returns></returns>
    private protected abstract IEnumerator<BigInteger> GetEnumeratorInternal();

    /// <summary>
    /// A builder for a <see cref="DigitList"/>.
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// Gets the number of digits currently in the builder.
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Prevents this class from being extended outside of this assembly.
        /// </summary>
        private protected Builder() { }

        /// <summary>
        /// Adds a digit to the list.
        /// </summary>
        /// <param name="Digit"></param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Digit"/> was negative.</exception>
        public abstract void Add([NonNegative] BigInteger Digit);

        /// <summary>
        /// Gets the <see cref="DigitList"/> represented by the current state of the builder.
        /// </summary>
        /// <returns></returns>
        public DigitList ToList() => ToListInternal();

        /// <summary>
        /// Allows the <see cref="ToList"/> method to be hidden in derived classes so that the return type matches
        /// the type of list being built.
        /// </summary>
        /// <returns></returns>
        private protected abstract DigitList ToListInternal();
    }
}
#endregion
#endregion

#region Interfaces
/// <summary>
/// An interface for types wrapping a list of <see cref="byte"/> digits.
/// </summary>
public interface IByteDigitList : IUShortDigitList, IEnumerable<byte>
{
    /// <inheritdoc cref="IDigitList.this[int]"/>
    public new byte this[[NonNegative] int index] { get; }
}

/// <summary>
/// An interface for types wrapping a list of <see cref="ushort"/> digits.
/// </summary>
public interface IUShortDigitList : IUIntDigitList, IEnumerable<ushort>
{
    /// <inheritdoc cref="IDigitList.this[int]"/>
    public new ushort this[[NonNegative] int index] { get; }
}

/// <summary>
/// An interface for types wrapping a list of <see cref="uint"/> digits.
/// </summary>
public interface IUIntDigitList : IULongDigitList, IEnumerable<uint>
{
    /// <inheritdoc cref="IDigitList.this[int]"/>
    public new uint this[[NonNegative] int index] { get; }
}

/// <summary>
/// An interface for types wrapping a list of <see cref="ulong"/> digits.
/// </summary>
public interface IULongDigitList : IDigitList, IEnumerable<ulong>
{
    /// <inheritdoc cref="IDigitList.this[int]"/>
    public new ulong this[[NonNegative] int index] { get; }
}

/// <summary>
/// An interface for types wrapping a list of digits.
/// </summary>
public interface IDigitList : IEnumerable<BigInteger>
{
    /// <summary>
    /// Gets the number of digits in the list.
    /// </summary>
    [NonNegative] public int Count { get; }

    /// <summary>
    /// Gets the digit at the specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> was out of range.</exception>
    [NonNegative] public BigInteger this[[NonNegative] int index] { get; }
}
#endregion
