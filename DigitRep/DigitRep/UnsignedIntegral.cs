using Rem.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.Digits;

/// <summary>
/// A representation of an unsigned integral value in a given base.
/// </summary>
public sealed record class UnsignedIntegralDigitRepresentation
{
    /// <summary>
    /// Gets the base of the representation.
    /// </summary>
    [GreaterThanOrEqualToInteger(2)] public BigInteger Base { get; }

    /// <summary>
    /// Gets the digits of the representation.
    /// </summary>
    public DigitList Digits { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="UnsignedIntegralDigitRepresentation"/> class with the digits of
    /// the representation.
    /// </summary>
    internal UnsignedIntegralDigitRepresentation(BigInteger Base, DigitList Digits)
    {
        this.Base = Base;
        this.Digits = Digits;
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
