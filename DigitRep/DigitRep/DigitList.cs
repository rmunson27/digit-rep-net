using Rem.Core.Attributes;
using Rem.Core.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

#region Classes
/// <summary>
/// A wrapper for a list of <see cref="byte"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class ByteDigitList(ImmutableArray<byte> Digits) : DigitList, IByteDigitList
{
    /// <inheritdoc/>
    [NonNegative] public override int Count => Digits.Length;

    /// <inheritdoc cref="ULongDigitList.Digits"/>
    public ImmutableArray<byte> Digits
    {
        get => _digits;
        init => Throw.IfStructPropSetDefault(in value);
    }
    private readonly ImmutableArray<byte> _digits = Throw.IfStructArgDefault(in Digits, nameof(Digits));

    /// <inheritdoc/>
    public byte ByteAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public ushort UShortAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public uint UIntAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public ulong ULongAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    [return: NonNegative] public override BigInteger BigIntegerAt(int index) => Digits[index];

    /// <summary>
    /// A builder for a <see cref="ByteDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public override int Count => _listBuilder.Count;

        private readonly ImmutableArray<byte>.Builder _listBuilder = ImmutableArray.CreateBuilder<byte>();

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="byte"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((byte)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList ToListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new ByteDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="ushort"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class UShortDigitList(ImmutableArray<ushort> Digits) : DigitList, IUShortDigitList
{
    /// <inheritdoc/>
    [NonNegative] public override int Count => Digits.Length;

    /// <inheritdoc cref="ULongDigitList.Digits"/>
    public ImmutableArray<ushort> Digits
    {
        get => _digits;
        init => Throw.IfStructPropSetDefault(in value);
    }
    private readonly ImmutableArray<ushort> _digits = Throw.IfStructArgDefault(in Digits, nameof(Digits));

    /// <inheritdoc/>
    public ushort UShortAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public uint UIntAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public ulong ULongAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    [return: NonNegative] public override BigInteger BigIntegerAt(int index) => Digits[index];

    /// <summary>
    /// A builder for a <see cref="UShortDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public override int Count => _listBuilder.Count;

        private readonly ImmutableArray<ushort>.Builder _listBuilder = ImmutableArray.CreateBuilder<ushort>();

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ushort"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((ushort)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList ToListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new UShortDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="uint"/> digits.
/// </summary>
/// <inheritdoc cref="ULongDigitList"/>
public sealed record class UIntDigitList(ImmutableArray<uint> Digits) : DigitList, IUIntDigitList
{
    /// <inheritdoc/>
    [NonNegative] public override int Count => Digits.Length;

    /// <inheritdoc cref="ULongDigitList.Digits"/>
    public ImmutableArray<uint> Digits
    {
        get => _digits;
        init => Throw.IfStructPropSetDefault(in value);
    }
    private readonly ImmutableArray<uint> _digits = Throw.IfStructArgDefault(in Digits, nameof(Digits));

    /// <inheritdoc/>
    public uint UIntAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    public ulong ULongAt([NonNegative] int index) => Digits[index];

    /// <inheritdoc/>
    [return: NonNegative] public override BigInteger BigIntegerAt(int index) => Digits[index];

    /// <summary>
    /// A builder for a <see cref="UIntDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public override int Count => _listBuilder.Count;

        private readonly ImmutableArray<uint>.Builder _listBuilder = ImmutableArray.CreateBuilder<uint>();

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="uint"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((uint)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList ToListInternal() => ToList();

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
public sealed record class ULongDigitList(ImmutableArray<ulong> Digits) : DigitList, IULongDigitList
{
    /// <inheritdoc/>
    [NonNegative] public override int Count => Digits.Length;

    /// <summary>
    /// Gets or initializes the list of digits stored.
    /// </summary>
    /// <exception cref="StructPropertySetDefaultException">
    /// This property was initialized to a default array.
    /// </exception>
    public ImmutableArray<ulong> Digits
    {
        get => _digits;
        init => Throw.IfStructPropSetDefault(in value);
    }
    private readonly ImmutableArray<ulong> _digits = Throw.IfStructArgDefault(in Digits, nameof(Digits));

    /// <inheritdoc/>
    public ulong ULongAt(int index) => Digits[index];

    /// <inheritdoc/>
    [return: NonNegative] public override BigInteger BigIntegerAt(int index) => Digits[index];

    /// <summary>
    /// A builder for a <see cref="ULongDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public override int Count => _listBuilder.Count;

        private readonly ImmutableArray<ulong>.Builder _listBuilder = ImmutableArray.CreateBuilder<ulong>();

        /// <inheritdoc/>
        /// <exception cref="OverflowException">
        /// <paramref name="Digit"/> was too large for a <see cref="ulong"/>.
        /// </exception>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add((ulong)Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList ToListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new ULongDigitList ToList() => new(_listBuilder.ToImmutable());
    }
}

/// <summary>
/// A wrapper for a list of <see cref="BigInteger"/> digits.
/// </summary>
/// <param name="Digits">The list of digits to wrap.</param>
/// <exception cref="StructArgumentDefaultException">
/// <paramref name="Digits"/> was default.
/// </exception>
/// <exception cref="ArgumentException">
/// <paramref name="Digits"/> contained a negative number.
/// </exception>
public sealed record class BigIntegerDigitList(ImmutableArray<BigInteger> Digits) : DigitList
{
    /// <inheritdoc/>
    [NonNegative] public override int Count => Digits.Length;

    /// <summary>
    /// Gets or initializes the list of digits stored.
    /// </summary>
    /// <exception cref="StructPropertySetDefaultException">
    /// This property was initialized to a default array.
    /// </exception>
    /// <exception cref="PropertySetException">
    /// This property was initialized to a list that contained a negative number.
    /// </exception>
    public ImmutableArray<BigInteger> Digits
    {
        get => _digits;
        init => CheckDigitsPropertySet(in value);
    }
    private readonly ImmutableArray<BigInteger> _digits = CheckDigitsArgument(in Digits);

    private static ImmutableArray<BigInteger> CheckDigitsArgument(in ImmutableArray<BigInteger> Digits)
    {
        foreach (var digit in Throw.IfStructArgDefault(in Digits, nameof(Digits)))
        {
            if (digit < 0) throw new ArgumentException("Cannot construct a digit list with negative digits.");
        }
        return Digits;
    }

    private static ImmutableArray<BigInteger> CheckDigitsPropertySet(in ImmutableArray<BigInteger> Digits)
    {
        foreach (var digit in Throw.IfStructPropSetDefault(in Digits, nameof(Digits)))
        {
            if (digit < 0) throw new PropertySetException("Cannot initialize a digit list with negative digits.");
        }
        return Digits;
    }

    /// <inheritdoc/>
    [return: NonNegative] public override BigInteger BigIntegerAt(int index) => Digits[index];

    /// <summary>
    /// A builder for a <see cref="BigIntegerDigitList"/>.
    /// </summary>
    public new sealed class Builder : DigitList.Builder
    {
        /// <inheritdoc/>
        public override int Count => _listBuilder.Count;

        private readonly ImmutableArray<BigInteger>.Builder _listBuilder = ImmutableArray.CreateBuilder<BigInteger>();

        /// <inheritdoc/>
        public override void Add([NonNegative] BigInteger Digit)
        {
            _listBuilder.Add(Throw.IfArgNegative(Digit, nameof(Digit)));
        }

        private protected override DigitList ToListInternal() => ToList();

        /// <inheritdoc cref="DigitList.Builder.ToList"/>
        public new BigIntegerDigitList ToList() => new(_listBuilder.ToImmutable());
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

    /// <summary>
    /// Prevents this class from being extended outside of this assembly.
    /// </summary>
    private protected DigitList() { }

    /// <inheritdoc/>
    [return: NonNegative] public abstract BigInteger BigIntegerAt(int index);

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

#region Interfaces
/// <summary>
/// An interface for types wrapping a list of <see cref="byte"/> digits.
/// </summary>
public interface IByteDigitList : IUShortDigitList
{
    /// <inheritdoc cref="IDigitList.BigIntegerAt(int)"/>
    public byte ByteAt([NonNegative] int index);
}

/// <summary>
/// An interface for types wrapping a list of <see cref="ushort"/> digits.
/// </summary>
public interface IUShortDigitList : IUIntDigitList
{
    /// <inheritdoc cref="IDigitList.BigIntegerAt(int)"/>
    public ushort UShortAt([NonNegative] int index);
}

/// <summary>
/// An interface for types wrapping a list of <see cref="uint"/> digits.
/// </summary>
public interface IUIntDigitList : IULongDigitList
{
    /// <inheritdoc cref="IDigitList.BigIntegerAt(int)"/>
    public uint UIntAt([NonNegative] int index);
}

/// <summary>
/// An interface for types wrapping a list of <see cref="ulong"/> digits.
/// </summary>
public interface IULongDigitList : IDigitList
{
    /// <inheritdoc cref="IDigitList.BigIntegerAt(int)"/>
    public ulong ULongAt([NonNegative] int index);
}

/// <summary>
/// An interface for types wrapping a list of digits.
/// </summary>
public interface IDigitList
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
    [return: NonNegative] public BigInteger BigIntegerAt([NonNegative] int index);
}
#endregion
