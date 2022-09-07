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
public sealed record class UnsignedIntegralDigitRep
{
    /// <summary>
    /// Gets the base of the representation.
    /// </summary>
    [GreaterThanOrEqualToInteger(2)] public BigInteger Base { get; }

    /// <summary>
    /// Gets the digits of the representation, with no leading zeroes.
    /// </summary>
    public DigitList Digits { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="UnsignedIntegralDigitRep"/> class with the digits of
    /// the representation.
    /// </summary>
    internal UnsignedIntegralDigitRep(BigInteger Base, DigitList Digits)
    {
        this.Base = Base;
        this.Digits = Digits;
    }

    /// <summary>
    /// Creates a new <see cref="UnsignedIntegralDigitRep"/> with the base and digits passed in.
    /// </summary>
    /// <remarks>
    /// Leading zeroes will be stripped off of the digit list before creation.
    /// </remarks>
    /// <param name="Base"></param>
    /// <param name="Digits"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"><paramref name="Digits"/> was <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="Base"/> was less than 2.</exception>
    public static UnsignedIntegralDigitRep Create([GreaterThanOrEqualToInteger(2)] BigInteger Base, DigitList Digits)
    {
        Throw.IfArgLessThan(2, Base, nameof(Base));
        Digits = Throw.IfArgNull(Digits, nameof(Digits)).WithoutLeadingZeroes();
        return new(Base, Digits);
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
