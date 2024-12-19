/*Challenge link:https://www.codewars.com/kata/66e793bba4b1a6f2e8f890e5/train/csharp
Question:
Given a number n, find the number of trailing zeros in its binary representation.

Examples:
4  ->  2, because 4 is represented as 100
5  ->  0, because 5 is represented as 101

Limits:
0 < n <= 10^4
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public static class Kata{
  public static uint TrailingZeroes(uint n) => 
    (uint)(Convert.ToString(n,2).Length - Convert.ToString(n,2).TrimEnd('0').Length);
}


//****************Sample Test*****************
namespace Solution
{
  using System;
  using System.Collections.Generic;
  using System.Numerics;
  using NUnit.Framework;

  [TestFixture]
  public class SolutionTest
  {
    private const int MaxInput = 10000;
    private const int RandomTestAmount = 100;
    
    [TestCase(1u, 0u, TestName = "n = 1 should return 0")]
    [TestCase(4u, 2u, TestName = "n = 4 should return 2")]
    [TestCase(5u, 0u, TestName = "n = 5 should return 0")]
    [TestCase(8192u, 13u, TestName = "n = 8192 should return 13")]
    [TestCase(9999u, 0u, TestName = "n = 9999 should return 0")]
    public void FixedTests(uint input, uint expectedOutput)
    {
      Assert.AreEqual(expectedOutput, Kata.TrailingZeroes(input));
    }
    
    [Test, TestCaseSource("RandomTestData")]
    public void RandomTests(uint input, uint expectedOutput)
    {
      Assert.AreEqual(expectedOutput, Kata.TrailingZeroes(input));
    }
    
    private static IEnumerable<TestCaseData> RandomTestData()
    {
      Random random = new Random();
      
      for (int i = 0; i < RandomTestAmount; i++)
      {
        uint input = Convert.ToUInt32(random.Next(MaxInput + 1));
        uint expectedOutput = Convert.ToUInt32(BitOperations.TrailingZeroCount(input));
        yield return new TestCaseData(input, expectedOutput).SetName($"n = {input} should return {expectedOutput}");
      }
    }
  }
}
