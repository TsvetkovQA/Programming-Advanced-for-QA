using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class StringLengthCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
        // Arrange
        var inputEmpty = "";
        int expectedEmpty = 0;

        // Act
        int resultEmpty = StringLengthCalculator.Calculate(inputEmpty);

        // Assert
        Assert.AreEqual(expectedEmpty, resultEmpty);
    }

    [Test]
    public void Test_Calculate_SingleEvenLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        var inputEven = "test";
        int expectedEven = 896; // t=116, e=101, s=115, t=116 -> 448 * 2 = 896

        // Act
        int resultEven = StringLengthCalculator.Calculate(inputEven);

        // Assert
        Assert.AreEqual(expectedEven, resultEven);

    }

    [Test]
    public void Test_Calculate_SingleOddLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        var inputOdd = "SoftUni";
        int expectedOdd = 356; // S=83, o=111, f=102, t=116, U=85, n=110, i=105 -> 712 / 2 = 356

        // Act
        int resultOdd = StringLengthCalculator.Calculate(inputOdd);

        // Assert
        Assert.AreEqual(expectedOdd, resultOdd);
    }

    [Test]
    public void Test_Calculate_WholeSentenceString_ReturnsCorrectInteger()
    {
        // Arrange
        var inputSentence = "SoftUni is the best!";
        int expectedSentence = 3624; // S=83, o=111, f=102, t=116, U=85, n=110, i=105, (space=32), i=105, s=115, (space=32), t=116, h=104, e=101, (space=32), b=98, e=101, s=115, t=116, !=33 -> 1812 * 2 = 3624

        // Act
        int resultSentence = StringLengthCalculator.Calculate(inputSentence);

        // Assert
        Assert.AreEqual(expectedSentence, resultSentence);
    }

}

