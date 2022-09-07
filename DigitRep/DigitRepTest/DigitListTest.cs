using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Math.DigitsTest;

/// <summary>
/// Tests of the <see cref="DigitList"/> class hierarchy.
/// </summary>
[TestClass]
public class DigitListTest
{
    /// <summary>
    /// Tests the <see cref="DigitList.WithoutLeadingZeroes"/> method.
    /// </summary>
    [TestMethod]
    public void TestWithoutLeadingZeroes()
    {
        var listWithoutZeroes = new ByteDigitList(1, 2, 3, 4, 5);
        var listWithZeroes = new ByteDigitList(0, 0, 0, 1, 2, 3, 4, 5);
        Assert.AreEqual(listWithoutZeroes, listWithZeroes.WithoutLeadingZeroes());
        Assert.AreEqual(listWithoutZeroes, listWithoutZeroes.WithoutLeadingZeroes()); // Should be no change
    }

    /// <summary>
    /// Tests the <see cref="DigitList.IsEquivalentTo(DigitList)"/> method.
    /// </summary>
    [TestMethod]
    public void TestIsEquivalentTo()
    {
        var equivalentLists1 = CreateEquivalentLists(1, 2, 3, 4);
        var equivalentLists2 = CreateEquivalentLists(2, 3, 4, 5);
        var equivalentLists3 = CreateEquivalentLists(1, 2);

        foreach (var (lhs, rhs) in equivalentLists1.Zip(equivalentLists1))
        {
            Assert.IsTrue(lhs.IsEquivalentTo(rhs), notEquivalentErrorMsg(lhs, rhs));
        }

        foreach (var (lhs, rhs) in equivalentLists1.Zip(equivalentLists2))
        {
            Assert.IsFalse(lhs.IsEquivalentTo(rhs), equivalentErrorMsg(lhs, rhs));
            Assert.IsFalse(rhs.IsEquivalentTo(lhs), equivalentErrorMsg(rhs, lhs));
        }

        foreach (var (lhs, rhs) in equivalentLists1.Zip(equivalentLists3))
        {
            Assert.IsFalse(lhs.IsEquivalentTo(rhs), equivalentErrorMsg(lhs, rhs));
            Assert.IsFalse(rhs.IsEquivalentTo(lhs), equivalentErrorMsg(rhs, lhs));
        }

        static string notEquivalentErrorMsg(DigitList lhs, DigitList rhs)
            => $"Lists {lhs} ({GetListTypeString(lhs)}) and {rhs} ({GetListTypeString(rhs)}) were not equivalent.";

        static string equivalentErrorMsg(DigitList lhs, DigitList rhs)
            => $"Lists {lhs} ({GetListTypeString(lhs)}) and {rhs} ({GetListTypeString(rhs)}) were equivalent.";
    }

    private static DigitList[] CreateEquivalentLists(params byte[] digits) => new DigitList[]
    {
        new ByteDigitList(digits),
        new UShortDigitList(digits.Select(b => (ushort)b)),
        new UIntDigitList(digits.Select(b => (uint)b)),
        new ULongDigitList(digits.Select(b => (ulong)b)),
        new BigIntegerDigitList(digits.Select(b => (BigInteger)b)),
    };

    private static string GetListTypeString(DigitList list) => list switch
    {
        ByteDigitList => "byte",
        UShortDigitList => "ushort",
        UIntDigitList => "uint",
        ULongDigitList => "ulong",
        BigIntegerDigitList => "BigInteger",
        _ => "<ERROR_TYPE>"
    };
}
