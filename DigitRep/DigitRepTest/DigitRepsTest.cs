using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.DigitsTest;

using static DigitReps;

/// <summary>
/// Tests of the <see cref="DigitReps"/> class.
/// </summary>
[TestClass]
public class DigitRepsTest
{
    /// <summary>
    /// Tests the methods for generating digit representations of unsigned integral values.
    /// </summary>
    [TestMethod, TestCategory("UnsignedIntegral")]
    public void TestUnsignedIntegralRepresentations()
    {
        Assert.That.DigitRepEquals(10, new ByteDigitList(3, 4, 5, 6, 7, 0, 1), InBase(3456701u, 10));
        Assert.That.DigitRepEquals(10, new ByteDigitList(3, 4, 5, 6, 7, 0, 1), InBase(3456701ul, 10));
        Assert.That.DigitRepEquals(30000, new UShortDigitList(1, 4, 23), InBase(900120023u, 30000));
        Assert.That.DigitRepEquals(30000, new UShortDigitList(1, 4, 23), InBase(900120023ul, 30000));
    }

    /// <summary>
    /// Tests the methods for generating digit representations of signed integral values.
    /// </summary>
    [TestMethod, TestCategory("SignedIntegral")]
    public void TestSignedIntegralRepresentation()
    {
        Assert.That.DigitRepEquals(false, 10, new ByteDigitList(4, 2, 1, 3, 0, 5), InBase(421305, 10));
        Assert.That.DigitRepEquals(false, 10, new ByteDigitList(4, 2, 1, 3, 0, 5), InBase(421305L, 10));
        Assert.That.DigitRepEquals(
            false, 10, new ByteDigitList(4, 2, 1, 3, 0, 5), InBase(new BigInteger(421305), 10));
        Assert.That.DigitRepEquals(true, 300, new UShortDigitList(4, 20, 2, 2), InBase(-109800602, 300));
        Assert.That.DigitRepEquals(true, 300, new UShortDigitList(4, 20, 2, 2), InBase(-109800602L, 300));
        Assert.That.DigitRepEquals(
            true, 300, new UShortDigitList(4, 20, 2, 2), InBase(new BigInteger(-109800602), 300));
    }
}
