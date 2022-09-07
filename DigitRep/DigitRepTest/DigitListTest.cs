using System;
using System.Collections.Generic;
using System.Linq;
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
}
