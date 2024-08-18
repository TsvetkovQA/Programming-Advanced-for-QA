using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string inputSentenceEmpty = "";
        var expectedDictionaryEmpty = new Dictionary<string, int>();

        // Act
        var resultDictionaryEmpty = YellingChecker.AnalyzeSentence(inputSentenceEmpty);

        // Assert
        Assert.AreEqual(expectedDictionaryEmpty, resultDictionaryEmpty);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        string inputSentenceUpperCase = "HELLO WORLD";
        var expectedDictionaryUpperCase = new Dictionary<string, int> { { "yelling", 2 } };

        // Act
        var resultDictionaryUpperCase = YellingChecker.AnalyzeSentence(inputSentenceUpperCase);

        // Assert
        Assert.AreEqual(expectedDictionaryUpperCase, resultDictionaryUpperCase);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        string inputSentenceLowerCase = "hello world";
        var expectedDictionaryLowerCase = new Dictionary<string, int> { { "speaking lower", 2 } };

        // Act
        var resultDictionaryLowerCase = YellingChecker.AnalyzeSentence(inputSentenceLowerCase);

        // Assert
        Assert.AreEqual(expectedDictionaryLowerCase, resultDictionaryLowerCase);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        // Arrange
        string inputSentenceMixedCase = "Hello World";
        var expectedDictionaryMixedCase = new Dictionary<string, int> { { "speaking normal", 2 } };

        // Act
        var resultDictionaryMixedCase = YellingChecker.AnalyzeSentence(inputSentenceMixedCase);

        // Assert
        Assert.AreEqual(expectedDictionaryMixedCase, resultDictionaryMixedCase);
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        string inputSentenceMixed = "HELLO world Test";
        var expectedDictionaryMixed = new Dictionary<string, int>
    {
        { "yelling", 1 },
        { "speaking lower", 1 },
        { "speaking normal", 1 }
    };

        // Act
        var resultDictionaryMixed = YellingChecker.AnalyzeSentence(inputSentenceMixed);

        // Assert
        Assert.AreEqual(expectedDictionaryMixed, resultDictionaryMixed);
    }
}

