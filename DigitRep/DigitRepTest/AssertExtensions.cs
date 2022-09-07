using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.DigitsTest;

/// <summary>
/// Extensions for the <see cref="Assert"/> class.
/// </summary>
internal static class AssertExtensions
{
    /// <summary>
    /// Asserts that the digit representation passed in equals the one described by the expected parts.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expectedBase"></param>
    /// <param name="expectedDigits"></param>
    /// <param name="actualRep"></param>
    /// <param name="message"></param>
    public static void DigitRepEquals(
        this Assert _,
        BigInteger expectedBase, DigitList expectedDigits,
        UnsignedIntegralDigitRep actualRep,
        string message = "")
    {
        Assert.AreEqual(expectedBase, actualRep.Base, message);
        Assert.AreEqual(expectedDigits, actualRep.Digits, message);
    }

    /// <summary>
    /// Asserts that the digit representation passed in equals the one described by the expected parts.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="expectedIsNegative"></param>
    /// <param name="expectedBase"></param>
    /// <param name="expectedDigits"></param>
    /// <param name="actualRep"></param>
    /// <param name="message"></param>
    public static void DigitRepEquals(
        this Assert _,
        bool expectedIsNegative, BigInteger expectedBase, DigitList expectedDigits,
        SignedIntegralDigitRep actualRep,
        string message = "")
    {
        Assert.AreEqual(expectedIsNegative, actualRep.IsNegative, message);
        Assert.AreEqual(expectedBase, actualRep.Base, message);
        Assert.AreEqual(expectedDigits, actualRep.Digits, message);
    }
}
