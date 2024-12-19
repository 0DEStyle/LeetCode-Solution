/*Challenge link:https://www.codewars.com/kata/6473603854720900496e1c82/train/csharp
Question:
Consider the process of stepping from integer x to integer y. The length of each step must be a positive integer, and must be either one bigger, or equal to, or one smaller than, the length of the previous step. The length of the first and last steps must be 1.

Create a function that computes the minimum number of steps needed to go from x to y. It should handle 0 <= x <= y < 231.

Source: Problem 6.6.8 from Skiena & Revilla, "Programming Challenges".

Examples:

x = 45, y = 48: Clearly the steps are 46,47,48, so the result is 3.

x = 45, y = 49: We can take one 2-step: 46,48,49, so the result is still 3.

x = 45, y = 50: Still one 2-step: 46,48,49,50, so the result is 4.

x = 45, y = 51: Two 2-steps: 46,48,50,51, so the result remains 4.

And so on.

Having the function consider the different possibilities in this way is not practical for large values. What characterizes these optimal sequences of steps? The example tests might help.

You might also enjoy Shortest steps to a number. It looks somewhat similar (maybe)!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
must be either one bigger, or equal to, or one smaller than, the length of the previous step. 

The length of the first and last steps must be 1.
*/

public class Steps{
    public static int Step(int x, int y) => 
      (int) System.Math.Sqrt(4.0 * (y - x) - (y > x ? 1 : 0));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

public class StepsTests
{
    [Test]
    public void FixedTests()
    { 
        Assert.That(Steps.Step(0, 0), Is.EqualTo(0)); 
      
        Assert.That(Steps.Step(45, 45), Is.EqualTo(0));  
        Assert.That(Steps.Step(45, 46), Is.EqualTo(1));  
        Assert.That(Steps.Step(45, 47), Is.EqualTo(2));  
        
        Assert.That(Steps.Step(45, 48), Is.EqualTo(3));  
        Assert.That(Steps.Step(45, 49), Is.EqualTo(3));  
      
        Assert.That(Steps.Step(45, 50), Is.EqualTo(4));  
        Assert.That(Steps.Step(45, 52), Is.EqualTo(5));  
        Assert.That(Steps.Step(45, 55), Is.EqualTo(6));  
      
        Assert.That(Steps.Step(45, 71), Is.EqualTo(10));  
      
        Assert.That(Steps.Step(1, (int) Math.Pow(2, 31)), Is.EqualTo(92681));  
    }
  
    public static int ReferenceSolution(int x, int y)
    {
        int diff = y - x;
        if (diff == 0) return 0;

        int root = (int)Math.Sqrt(diff);
        if (diff == Math.Pow(root, 2)) return 2 * root - 1;
        else if (diff - Math.Pow(root, 2) < Math.Pow((root + 1), 2) - diff) return 2 * root;
        else return 2 * root + 1;
    }
  
    [Test]
    public void RandomTests()
    {
        Random random = new Random();
        for (int i = 0; i < 50; i++)
        {
            int x = random.Next(0, int.MaxValue);  // Ensuring the minimum value is 0
            int y = random.Next(x, int.MaxValue);  // Ensuring y is always greater than x
            
            int expected = ReferenceSolution(x, y);
            int actual = Steps.Step(x, y);
            Assert.That(actual, Is.EqualTo(expected), "Test Failed for x = " + x + " y = " + y);
        }
    }

}
