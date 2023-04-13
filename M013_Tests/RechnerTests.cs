using M013;

namespace M013_Tests;

[TestClass]
public class RechnerTests
{
	//Dependencies -> Rechtsklick -> Add Projekt Reference -> Projekt auswählen
	//Test Explorer -> View -> Test Explorer

	Rechner r;

	[TestInitialize]
	public void Init()
	{
		r = new();
	}

	[TestCleanup]
	public void Cleanup()
	{
		r = null;
	}

	[TestMethod]
	[TestCategory("Addiere Test")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(4, 5);
		Assert.AreEqual(9, ergebnis);
	}

	[TestMethod]
	[TestCategory("Subtrahiere Test")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(7, 3);
		Assert.AreEqual(4, ergebnis);
	}
}