﻿using Rem.Core.Attributes;
using Rem.Core.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

    #region Constructors
    /// <inheritdoc cref="ByteDigitList(IEnumerable{byte})"/>
    public ByteDigitList(params byte[] Digits) : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray()) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="ByteDigitList"/> class wrapping the digits passed in.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    public ByteDigitList(IEnumerable<byte> Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }
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

    #region Leading Zero Removal
    private protected override DigitList<byte> GenericWithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new ByteDigitList WithoutLeadingZeroes() => new(GetDigitsWithoutLeadingZeroes());
    #endregion

    /// <summary>
    /// A builder for a <see cref="ByteDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<byte>.Builder
    {
        /// <inheritdoc cref="ULongDigitList.Builder.ListBuilder"/>
        public ImmutableArray<byte>.Builder ListBuilder => _listBuilder;

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="byte"/>.
        /// </exception>
        public override void Add(uint Digit) => _listBuilder.Add((byte)Digit);

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="byte"/>.
        /// </exception>
        public override void Add(ulong Digit) => _listBuilder.Add((byte)Digit);

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

    #region Constructors
    /// <inheritdoc cref="UShortDigitList(IEnumerable{ushort})"/>
    public UShortDigitList(params ushort[] Digits) : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="UShortDigitList"/> class wrapping the digits passed in.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    public UShortDigitList(IEnumerable<ushort> Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }
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

    #region Leading Zero Removal
    private protected override DigitList<ushort> GenericWithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new UShortDigitList WithoutLeadingZeroes() => new(GetDigitsWithoutLeadingZeroes());
    #endregion

    /// <summary>
    /// A builder for a <see cref="UShortDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<ushort>.Builder
    {
        /// <inheritdoc cref="ULongDigitList.Builder.ListBuilder"/>
        public ImmutableArray<ushort>.Builder ListBuilder => _listBuilder;

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ushort"/>.
        /// </exception>
        public override void Add(uint Digit) => _listBuilder.Add((ushort)Digit);

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ushort"/>.
        /// </exception>
        public override void Add(ulong Digit) => _listBuilder.Add((ushort)Digit);

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

    #region Constructors
    /// <inheritdoc cref="UIntDigitList(IEnumerable{uint})"/>
    public UIntDigitList(params uint[] Digits) : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray()) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="UIntDigitList"/> class wrapping the digits passed in.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    public UIntDigitList(IEnumerable<uint> Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }
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

    #region Leading Zero Removal
    private protected override DigitList<uint> GenericWithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new UIntDigitList WithoutLeadingZeroes() => new(GetDigitsWithoutLeadingZeroes());
    #endregion

    /// <summary>
    /// A builder for a <see cref="UIntDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<uint>.Builder
    {
        /// <inheritdoc cref="ULongDigitList.Builder.ListBuilder"/>
        public ImmutableArray<uint>.Builder ListBuilder => _listBuilder;

        /// <inheritdoc/>
        public override void Add(uint Digit) => _listBuilder.Add(Digit);

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="uint"/>.
        /// </exception>
        public override void Add(ulong Digit) => _listBuilder.Add((uint)Digit);

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
    #region Index
    /// <inheritdoc cref="DigitList.this[int]"/>
    public new ulong this[[NonNegative] int index] => Digits[index];

    [return: NonNegative]
    private protected override BigInteger IndexInternal([NonNegative] int index) => Digits[index];
    #endregion

    #region Constructors
    /// <inheritdoc cref="ULongDigitList(IEnumerable{ulong})"/>
    public ULongDigitList(params ulong[] Digits) : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="ULongDigitList"/> class wrapping the digits passed in.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    public ULongDigitList(IEnumerable<ulong> Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }
    #endregion

    #region IEnumerable
    /// <inheritdoc cref="DigitList.GetEnumerator"/>
    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var ul in Digits) yield return ul;
    }
    #endregion

    #region Leading Zero Removal
    private protected override DigitList<ulong> GenericWithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new ULongDigitList WithoutLeadingZeroes() => new(GetDigitsWithoutLeadingZeroes());
    #endregion

    /// <summary>
    /// A builder for a <see cref="ULongDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<ulong>.Builder
    {
        /// <summary>
        /// Gets the builder for the list of digits.
        /// </summary>
        public ImmutableArray<ulong>.Builder ListBuilder => _listBuilder;

        /// <inheritdoc/>
        public override void Add(uint Digit) => _listBuilder.Add(Digit);

        /// <inheritdoc/>
        public override void Add(ulong Digit) => _listBuilder.Add(Digit);

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
    #region Index
    [return: NonNegative] private protected override BigInteger IndexInternal([NonNegative] int index)
        => Digits[index];
    #endregion

    #region Constructors
    /// <inheritdoc cref="BigIntegerDigitList(IEnumerable{BigInteger})"/>
    public BigIntegerDigitList(params BigInteger[] Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="BigIntegerDigitList"/> class wrapping the digits passed in.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="Digits"/> contained a negative number.
    /// </exception>
    public BigIntegerDigitList(IEnumerable<BigInteger> Digits)
        : this(Throw.IfArgNull(Digits, nameof(Digits)).ToImmutableArray())
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="BigIntegerDigitList"/> class with the list of digits to wrap.
    /// </summary>
    /// <param name="Digits"></param>
    /// <exception cref="StructArgumentDefaultException">
    /// <paramref name="Digits"/> was default.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="Digits"/> contained a negative number.
    /// </exception>
    public BigIntegerDigitList([NonDefaultableStruct] ImmutableArray<BigInteger> Digits) : base(Digits)
    {
        foreach (var digit in Digits)
        {
            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException(null, "Cannot construct a digit list with negative digits.");
            }
        }
    }
    #endregion

    #region IEnumerable
    /// <inheritdoc cref="DigitList.GetEnumerator"/>
    public new ImmutableArray<BigInteger>.Enumerator GetEnumerator() => Digits.GetEnumerator();

    private protected override IEnumerator<BigInteger> GetEnumeratorInternal()
    {
        foreach (var bi in Digits) yield return bi;
    }
    #endregion

    #region Leading Zero Removal
    private protected override DigitList<BigInteger> GenericWithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new BigIntegerDigitList WithoutLeadingZeroes() => new(GetDigitsWithoutLeadingZeroes());
    #endregion

    /// <summary>
    /// A builder for a <see cref="BigIntegerDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList<BigInteger>.Builder
    {
        /// <inheritdoc/>
        public override void Add(uint Digit) => _listBuilder.Add(Digit);

        /// <inheritdoc/>
        public override void Add(ulong Digit) => _listBuilder.Add(Digit);

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
    [NonDefaultableStruct] ImmutableArray<TDigit> Digits)
    : DigitList, IEnumerable<TDigit>
    where TDigit : struct, IEquatable<TDigit>
{
    #region Properties
    /// <inheritdoc/>
    public sealed override int Count => Digits.Length;

    #region Index
    /// <inheritdoc cref="DigitList.this[int]"/>
    public new TDigit this[[NonNegative] int index] => Digits[index];
    #endregion

    /// <summary>
    /// Gets an immutable array containing the digits the list is comprised of.
    /// </summary>
    [NonDefaultableStruct] public ImmutableArray<TDigit> Digits { get; }
        = Throw.IfStructArgDefault(Digits, nameof(Digits));
    #endregion

    #region IEnumerable
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
    #endregion

    #region Equality
    /// <summary>
    /// Determines if this object is equal to another object of the same type.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public virtual bool Equals(DigitList<TDigit>? other) => other is not null && Digits.SequenceEqual(other.Digits);

    /// <summary>
    /// Gets a hash code for the current instance.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var d in Digits) hash.Add(d);
        return hash.ToHashCode();
    }
    #endregion

    /// <summary>
    /// Gets a string that represents the current instance.
    /// </summary>
    /// <returns></returns>
    public sealed override string ToString() => $"{{ {JoinImmutableArrayWithCommas(Digits)} }}";


    #region Leading Zero Removal
    private protected sealed override DigitList WithoutLeadingZeroesInternal() => WithoutLeadingZeroes();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroes"/>
    public new DigitList<TDigit> WithoutLeadingZeroes() => GenericWithoutLeadingZeroesInternal();

    /// <inheritdoc cref="DigitList.WithoutLeadingZeroesInternal"/>
    private protected abstract DigitList<TDigit> GenericWithoutLeadingZeroesInternal();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private protected ImmutableArray<TDigit> GetDigitsWithoutLeadingZeroes()
    {
        var numberToRemove = 0;
        foreach (var digit in Digits)
        {
            if (digit.Equals(default)) numberToRemove++;
            else break;
        }
        return numberToRemove == 0 ? Digits : Digits.RemoveRange(0, numberToRemove);
    }
    #endregion

    /// <summary>
    /// A builder for a <see cref="DigitList{TDigit}"/>.
    /// </summary>
    public abstract new class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public sealed override int Count => _listBuilder.Count;

        private protected readonly ImmutableArray<TDigit>.Builder _listBuilder
            = ImmutableArray.CreateBuilder<TDigit>();

        /// <inheritdoc/>
        public sealed override void Reverse() => _listBuilder.Reverse();

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

    #region Index
    /// <inheritdoc/>
    [NonNegative] public BigInteger this[[NonNegative] int index] => IndexInternal(index);

    /// <summary>
    /// Allows <see cref="this[int]"/> to be implemented on a smaller numeric type in subclasses, while also ensuring
    /// this class cannot be extended outside of this assembly.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    [return: NonNegative] private protected abstract BigInteger IndexInternal([NonNegative] int index);
    #endregion

    #region IEnumerable
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
    #endregion

    #region Leading Zero Removal
    /// <summary>
    /// Gets a digit list equivalent to the current instance with all leading zeroes removed.
    /// </summary>
    /// <returns></returns>
    public DigitList WithoutLeadingZeroes() => WithoutLeadingZeroesInternal();

    /// <summary>
    /// Allows the <see cref="WithoutLeadingZeroes"/> method return value to be further specified, while also ensuring
    /// that this type cannot be extended outside of this assembly.
    /// </summary>
    /// <returns></returns>
    private protected abstract DigitList WithoutLeadingZeroesInternal();
    #endregion

    #region Helpers
    protected static string JoinImmutableArrayWithCommas<T>(ImmutableArray<T> arr)
    {
        var result = "";
        var isFirst = true;
        foreach (var item in arr)
        {
            if (isFirst)
            {
                result += item!.ToString();
                isFirst = false;
            }
            else result += $", {item}";
        }
        return result;
    }
    #endregion

    /// <summary>
    /// A builder for a <see cref="DigitList"/>.
    /// </summary>
    /// <remarks>
    /// Instances of this class store digits that can be used to construct lists of digits of various sizes; however,
    /// it should be noted that while methods for adding large integer types as digits (such as
    /// <see cref="BigInteger"/>) are provided to make programming with the builders easier, these methods will throw
    /// exceptions if there is an overflow.
    /// </remarks>
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
        public abstract void Add(uint Digit);

        /// <summary>
        /// Adds a digit to the list.
        /// </summary>
        /// <param name="Digit"></param>
        public abstract void Add(ulong Digit);

        /// <summary>
        /// Adds a digit to the list.
        /// </summary>
        /// <param name="Digit"></param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Digit"/> was negative.</exception>
        public abstract void Add([NonNegative] BigInteger Digit);

        /// <summary>
        /// Reverses the order of digits in the builder.
        /// </summary>
        public abstract void Reverse();

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

        #region Factory Methods
        /// <summary>
        /// Gets a new instance of this class capable of handling the smallest possible integral representation of
        /// digits in the given base.
        /// </summary>
        /// <remarks>
        /// Attempting to add digits larger than the base to the result of this method may cause an exception.
        /// <para/>
        /// Passing a negative <paramref name="Base"/> value to this method will not cause an exception, but in this
        /// case the method will return a builder that can only handle <see cref="byte"/> digits.
        /// </remarks>
        /// <param name="Base"></param>
        /// <returns></returns>
        public static Builder NewFromBaseSize([GreaterThanOrEqualToInteger(2)] BigInteger Base)
            => Base > ulong.MaxValue
                ? new BigIntegerDigitList.Builder()
                : NewFromBaseSizeInternal(unchecked((ulong)Base));

        /// <inheritdoc cref="NewFromBaseSize(ushort)"/>
        public static Builder NewFromBaseSize([GreaterThanOrEqualToInteger(2)] ulong Base)
            => NewFromBaseSizeInternal(Base);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Builder NewFromBaseSizeInternal([GreaterThanOrEqualToInteger(2)] ulong Base) => Base switch
        {
            > uint.MaxValue => new ULongDigitList.Builder(),
            > ushort.MaxValue => new UIntDigitList.Builder(),
            > byte.MaxValue => new UShortDigitList.Builder(),
            _ => new ByteDigitList.Builder(),
        };

        /// <inheritdoc cref="NewFromBaseSize(ushort)"/>
        public static Builder NewFromBaseSize([GreaterThanOrEqualToInteger(2)] uint Base) => Base switch
        {
            > ushort.MaxValue => new UIntDigitList.Builder(),
            > byte.MaxValue => new UShortDigitList.Builder(),
            _ => new ByteDigitList.Builder(),
        };

        /// <summary>
        /// Gets a new instance of this class capable of handling the smallest possible integral representation of
        /// digits in the given base.
        /// </summary>
        /// <remarks>
        /// Attempting to add digits larger than the base to the result of this method may cause an exception.
        /// </remarks>
        /// <param name="Base"></param>
        /// <returns></returns>
        public static Builder NewFromBaseSize([GreaterThanOrEqualToInteger(2)] ushort Base)
            => Base > byte.MaxValue ? new UShortDigitList.Builder() : new ByteDigitList.Builder();
    }
}
#endregion
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
