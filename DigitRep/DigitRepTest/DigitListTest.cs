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
    /// Tests the <see cref="DigitList.Builder.NewFromBaseSize(BigInteger)"/> factory method and overloads.
    /// </summary>
    [TestMethod]
    public void TestNewBuilderFromBaseSize()
    {
        // Test the limits of the range of builder types based on the size of the base passed in
        // A list of a given digit type should be able to handle a base that is one too large for the type
        var tests = new (Type SmallerBuilderType, Type BiggerBuilderType, BigInteger Limit)[]
        { 
            (typeof(ByteDigitList.Builder), typeof(UShortDigitList.Builder), byte.MaxValue + BigInteger.One),
            (typeof(UShortDigitList.Builder), typeof(UIntDigitList.Builder), ushort.MaxValue + BigInteger.One),
            (typeof(UIntDigitList.Builder), typeof(ULongDigitList.Builder), uint.MaxValue + BigInteger.One),
            (typeof(ULongDigitList.Builder), typeof(BigIntegerDigitList.Builder), ulong.MaxValue + BigInteger.One),
        };

        foreach (var (smallerType, biggerType, limit) in tests)
        {
            Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(limit), smallerType);
            Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(limit + 1), biggerType);

            if (limit < ulong.MaxValue)
            {
                var fixedSizeLimit = (ulong)limit;
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit), smallerType);
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit + 1), biggerType);
            }

            if (limit < uint.MaxValue)
            {
                var fixedSizeLimit = (uint)limit;
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit), smallerType);
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit + 1), biggerType);
            }

            if (limit < ushort.MaxValue)
            {
                var fixedSizeLimit = (ushort)limit;
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit), smallerType);
                Assert.IsInstanceOfType(DigitList.Builder.NewFromBaseSize(fixedSizeLimit + 1), biggerType);
            }
        }
    }

    /// <summary>
    /// Tests the <see cref="DigitList.WithoutLeadingZeroes"/> method.
    /// </summary>
    [TestMethod]
    public void TestWithoutLeadingZeroes()
    {
        var listWithoutZeroes = ByteDigitList.CreateRange(1, 2, 3, 4, 5);
        var listWithZeroes = ByteDigitList.CreateRange(0, 0, 0, 1, 2, 3, 4, 5);
        Assert.AreEqual(listWithoutZeroes, listWithZeroes.WithoutLeadingZeroes());
        Assert.AreEqual(listWithoutZeroes, listWithoutZeroes.WithoutLeadingZeroes()); // Should be no change
    }

    /// <summary>
    /// Tests the <see cref="DigitList.SplitAtIndices(int[])"/> method.
    /// </summary>
    [TestMethod]
    public void TestSplitAtIndices()
    {
        var list = ByteDigitList.CreateRange(0, 1, 2, 3, 4, 5, 6);

        Assert.IsTrue(list.SplitAtIndices().SequenceEqual(new[] { list }));
        Assert.IsTrue(list.SplitAtIndices(0).SequenceEqual(new[] { ByteDigitList.Empty, list }));
        Assert.IsTrue(
            list.SplitAtIndices(2, 4).SequenceEqual(new[]
            {
                ByteDigitList.CreateRange(0, 1), ByteDigitList.CreateRange(2, 3), ByteDigitList.CreateRange(4, 5, 6)
            }));

        Assert.ThrowsException<ArgumentNullException>(() => list.SplitAtIndices(null!));
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.SplitAtIndices(7));
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.SplitAtIndices(-1));
        Assert.ThrowsException<ArgumentException>(() => list.SplitAtIndices(4, 2));
    }

    private protected static List<IEnumerable<byte>> SplitIntoArraySegmentsAtIndices(ByteDigitList list, params int[] indices)
    {
        var subArrays = new List<IEnumerable<byte>>();
        int lastIndex = 0;
        IEnumerable<byte> enumerable = list;

        // Add all the subsegments indicated by the indices
        for (int i = 0; i < indices.Length; i++)
        {
            var currentIndex = indices[i];
            if (currentIndex < lastIndex)
            {
                throw new ArgumentException(
                    "Indices passed in must be non-negative and in (non-strictly) ascending order.", nameof(indices));
            }
            else if (currentIndex >= list.Count)
            {
                throw new IndexOutOfRangeException($"Index {currentIndex} was out of range of the digit list.");
            }

            subArrays.Add(enumerable.Skip(lastIndex).Take(currentIndex - lastIndex));

            lastIndex = currentIndex;
        }

        // Add the final subsegment
        subArrays.Add(enumerable.Skip(lastIndex).Take(list.Count - lastIndex));

        return subArrays;
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
        ByteDigitList.CreateRange(digits),
        UShortDigitList.CreateRange(digits.Select(b => (ushort)b)),
        UIntDigitList.CreateRange(digits.Select(b => (uint)b)),
        ULongDigitList.CreateRange(digits.Select(b => (ulong)b)),
        BigIntegerDigitList.CreateRange(digits.Select(b => (BigInteger)b)),
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
