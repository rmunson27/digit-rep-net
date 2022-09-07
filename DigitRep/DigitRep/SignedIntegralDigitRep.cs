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
}
