using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaboratoryLibrary.Classes;
using LaboratoryLibrary.Exceptions;
using System.Collections.Generic;

namespace LaboratoryTest;
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CreatePrenotation_WithValidReagents_ReturnsTrue()
    {
        // Arrange
        Laboratory laboratory = new Laboratory();
        var analysis = new Analysis("TestAnalysis");
        analysis.AddReagent(new List<Reagent> { new Reagent("Reagent1"), new Reagent("Reagent2") });
        laboratory.SetAnalyses(new List<Analysis> { analysis });
        laboratory.SetReagents(new List<Reagent> { new Reagent("Reagent1"), new Reagent("Reagent2") });

        // Act
        bool result = laboratory.CreatePrenotation("TestUser", analysis);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CreatePrenotation_WithInsufficientReagents_ThrowsReagentUnavailableException()
    {
        // Arrange
        Laboratory laboratory = new Laboratory();
        var analysis = new Analysis("TestAnalysis");
        analysis.AddReagent(new List<Reagent> { new Reagent("Reagent1") });
        laboratory.SetAnalyses(new List<Analysis> { analysis });
        laboratory.SetReagents(new List<Reagent> { new Reagent("Reagent1") });

        // Act & Assert
        Assert.ThrowsException<ReagentUnavailableException>(() => laboratory.CreatePrenotation("TestUser", analysis));
    }

    // Add more test methods for other scenarios

    [TestMethod]
    public void GetUserHistory_UserHasHistory_ReturnsHistory()
    {
        // Arrange
        Laboratory laboratory = new Laboratory();
        var prenotations = new List<Prenotation> { new Prenotation(new Analysis("TestAnalysis")) };
        laboratory.SetPrenotations(new Dictionary<string, List<Prenotation>> { { "TestUser", prenotations } });

        // Act
        List<Prenotation> history = laboratory.GetUserHistory("TestUser");

        // Assert
        CollectionAssert.AreEqual(prenotations, history);
    }

    [TestMethod]
    public void GetUserHistory_UserHasNoHistory_ThrowsPrenotationUnavailableException()
    {
        // Arrange
        Laboratory laboratory = new Laboratory();

        // Act & Assert
        Assert.ThrowsException<PrenotationUnavailableException>(() => laboratory.GetUserHistory("NonExistentUser"));
    }
}
