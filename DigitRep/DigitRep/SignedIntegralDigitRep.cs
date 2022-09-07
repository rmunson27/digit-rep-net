using Rem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

/// <summary>
/// A representation of a signed integral value in a given base.
/// </summary>
public sealed record class SignedIntegralDigitRep
{
    /// <summary>
    /// Gets the base of the representation.
    /// </summary>
    [GreaterThanOrEqualToInteger(2)] public BigInteger Base { get; }

    /// <summary>
    /// Gets the sign of the value represented by this instance.
    /// </summary>
    public int Sign => IsNegative ? -1 : (Digits.Count == 0 ? 0 : 1);

    /// <summary>
    /// Gets whether or not the represented value is negative.
    /// </summary>
    public bool IsNegative { get; }

    /// <summary>
    /// Gets the digits of the representation, with no leading zeroes.
    /// </summary>
    public DigitList Digits { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="SignedIntegralDigitRep"/> class wrapping the base, sign
    /// and digits representing a signed integral value.
    /// </summary>
    /// <param name="IsNegative"></param>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    internal SignedIntegralDigitRep(
        bool IsNegative, [GreaterThanOrEqualToInteger(2)] BigInteger Base, DigitList Digits)
    {
        this.IsNegative = IsNegative;
        this.Digits = Digits;
        this.Base = Base;
    }

    /// <summary>
    /// Creates a new <see cref="SignedIntegralDigitRep"/> with the negative sign, base and digits passed in.
    /// </summary>
    /// <remarks>
    /// Leading zeroes will be stripped off of the digit list before creation.
    /// <para/>
    /// If the digit list is equal to zero, the <see cref="IsNegative"/> property of the return value will be
    /// <see langword="false"/> even if <paramref name="IsNegative"/> is set to <see langword="true"/>.
    /// </remarks>
    /// <param name="IsNegative"></param>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="Base"/> was less than 2.</exception>
    public static SignedIntegralDigitRep Create(
        bool IsNegative, [GreaterThanOrEqualToInteger(2)] BigInteger Base, DigitList Digits)
    {
        Throw.IfArgLessThan(2, Base, nameof(Base));
        Digits = Throw.IfArgNull(Digits, nameof(Digits)).WithoutLeadingZeroes();
        if (Digits.Count == 0) IsNegative = false; // Is zero, therefore is not a negative value
        return new(IsNegative, Base, Digits);
    }

    /// <summary>
    /// Deconstructs the current instance.
    /// </summary>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    public void Deconstruct(
        out bool IsNegative, [GreaterThanOrEqualToInteger(2)] out BigInteger Base, out DigitList Digits)
    {
        IsNegative = this.IsNegative;
        Base = this.Base;
        Digits = this.Digits;
    }

    /// <summary>
    /// Determines if this instance is equal to another object of the same type.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(SignedIntegralDigitRep? other) => other is not null
                                                            && IsNegative == other.IsNegative
                                                            && Base == other.Base
                                                            && Digits == other.Digits;

    /// <summary>
    /// Gets a hash code for the current instance.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(IsNegative, Base, Digits);

    /// <summary>
    /// Gets a string that represents the current instance.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Digits.Count switch
        {
            0 => "0",
            1 => $"{formatNegSign()}{Digits[0]}",
            _ => $"{formatNegSign()}{Digits} (Base {Base})",
        };

        string formatNegSign() => IsNegative ? "-" : string.Empty;
    }
}
