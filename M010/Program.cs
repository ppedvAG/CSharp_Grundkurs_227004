using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8; //€ Zeichen

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;
		//m.Lohnauszahlung();

		IArbeit a = m; //Variable vom Typ IArbeit genau wie bei Vererbung
		a.Lohnauszahlung();

		ITeilzeitArbeit ta = m;
		ta.Lohnauszahlung(); //Für explizite Implementierung muss das Objekt in den entsprechenden Interfacetyp umgewandelt werden

		//IEnumerable: Basisinterface für alle Collections in C# (Array, List, Dictionary, ...)
		IEnumerable<int> e1 = new int[10];
		IEnumerable<int> e2 = new List<int>();
		IEnumerable<KeyValuePair<string, int>> dict = new Dictionary<string, int>();

		e1.Sum();
		e2.Sum();
		//dict.Sum();

		Test(e1);
		Test(e2);
		Test(dict);
	}

	static void Test<T>(IEnumerable<T> x) { }
}

public class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	public int Gehalt { get; set; }

	public string Job { get; set; }

	//public void Lohnauszahlung()
	//{
	//	Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. " +
	//		$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
	//}

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}
}

public interface IArbeit
{
	static int Wochenstunden = 40;

	int Gehalt { get; set; }

	string Job { get; set; }

	void Lohnauszahlung();

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit
{
	static int Wochenstunden = 20;

	int Gehalt { get; set; }

	string Job { get; set; }

	void Lohnauszahlung();
}