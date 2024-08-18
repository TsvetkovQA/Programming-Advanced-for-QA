using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();

        // Act
        int initialCargoCount = cargoManager.CargoCount;
        var initialCargoList = cargoManager.GetAllCargos();

        // Assert
        Assert.AreEqual(0, initialCargoCount);
        Assert.IsEmpty(initialCargoList);
    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();
        string cargoItemToAdd = "Container";

        // Act
        cargoManager.AddCargo(cargoItemToAdd);
        int cargoCountAfterAdd = cargoManager.CargoCount;
        var cargoListAfterAdd = cargoManager.GetAllCargos();

        // Assert
        Assert.AreEqual(1, cargoCountAfterAdd);
        CollectionAssert.Contains(cargoListAfterAdd, cargoItemToAdd);
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();

        // Act & Assert
        var exNull = Assert.Throws<ArgumentException>(() => cargoManager.AddCargo(null));
        var exEmpty = Assert.Throws<ArgumentException>(() => cargoManager.AddCargo(""));
        var exWhitespace = Assert.Throws<ArgumentException>(() => cargoManager.AddCargo("   "));

        // Assert (for exception message, if needed)
        Assert.That(exNull.Message, Is.EqualTo("Cargo cannot be empty or whitespace."));
        Assert.That(exEmpty.Message, Is.EqualTo("Cargo cannot be empty or whitespace."));
        Assert.That(exWhitespace.Message, Is.EqualTo("Cargo cannot be empty or whitespace."));
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();
        string cargoItemToRemove = "Container";
        cargoManager.AddCargo(cargoItemToRemove);

        // Act
        cargoManager.RemoveCargo(cargoItemToRemove);
        int cargoCountAfterRemove = cargoManager.CargoCount;
        var cargoListAfterRemove = cargoManager.GetAllCargos();

        // Assert
        Assert.AreEqual(0, cargoCountAfterRemove);
        CollectionAssert.DoesNotContain(cargoListAfterRemove, cargoItemToRemove);
    }

    [Test]
    public void Test_RemoveCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();
        string nonExistentCargoItem = "NonExistentCargo";

        // Act
        var exNull = Assert.Throws<ArgumentException>(() => cargoManager.RemoveCargo(null));
        var exEmpty = Assert.Throws<ArgumentException>(() => cargoManager.RemoveCargo(""));
        var exWhitespace = Assert.Throws<ArgumentException>(() => cargoManager.RemoveCargo("   "));
        var exNonExistent = Assert.Throws<ArgumentException>(() => cargoManager.RemoveCargo(nonExistentCargoItem));

        // Assert
        Assert.That(exNull.Message, Is.EqualTo("Cargo not found in the system."));
        Assert.That(exEmpty.Message, Is.EqualTo("Cargo not found in the system."));
        Assert.That(exWhitespace.Message, Is.EqualTo("Cargo not found in the system."));
        Assert.That(exNonExistent.Message, Is.EqualTo("Cargo not found in the system."));
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        // Arrange
        var cargoManager = new CargoManagementSystem();
        string firstCargoItem = "Container";
        string secondCargoItem = "Pallet";
        string thirdCargoItem = "Drum";

        cargoManager.AddCargo(firstCargoItem);
        cargoManager.AddCargo(secondCargoItem);
        cargoManager.AddCargo(thirdCargoItem);
        cargoManager.RemoveCargo(secondCargoItem);

        var expectedCargoCollection = new List<string> { firstCargoItem, thirdCargoItem };

        // Act
        var resultingCargoCollection = cargoManager.GetAllCargos();

        // Assert
        CollectionAssert.AreEqual(expectedCargoCollection, resultingCargoCollection);
    }
}

    