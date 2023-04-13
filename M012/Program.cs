using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Liste von <Start> bis <Anzahl> Elemente
		//Liste von 1-20
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Sum());
		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.First()); //Erstes Element, Exception wenn kein Element gefunden
		Console.WriteLine(ints.FirstOrDefault()); //Erstes Element, default Wert (0, null, false, ...) wenn kein Element gefunden

		Console.WriteLine(ints.Last()); //Letztes Element, Exception wenn kein Element gefunden
		Console.WriteLine(ints.LastOrDefault()); //Letztes Element, default Wert (0, null, false, ...) wenn kein Element gefunden

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Suche das erste Element das der Bedingung entspricht
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //Suche das erste Element das der Bedingung entspricht
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq-Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug fzg in fahrzeuge)
			if (fzg.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(fzg);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenketten
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(f => f.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objekten
		//Alle VWs finden
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);

		//Alle Fahrzeuge mit MaxV >= 200
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs mit MaxV >= 200
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV >= 200);
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200);

		//Alle Fahrzeuge nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Wichtig: Neue Liste
		//fahrzeuge = fahrzeuge.OrderBy(e => e.Marke).ToList(); //Änderungen übernehmen

		//Alle Fahrzeuge nach Marke und danach nach Maximalgeschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Alle Marken finden
		fahrzeuge.Select(e => e.Marke).ToList();
		fahrzeuge.Select(e => e.Marke).Distinct(); //Elemente eindeutig machen

		//Anwendungbeispiel Select
		string[] pfadeMitEndungen = Directory.GetFiles(@"C:\Windows\System32");
		List<string> dateiNamen = new();
		foreach (string s in pfadeMitEndungen)
			dateiNamen.Add(Path.GetFileNameWithoutExtension(s));

		List<string> namen = Directory.GetFiles(@"C:\Windows\System32").Select(e => Path.GetFileNameWithoutExtension(e)).ToList();

		Enumerable.SequenceEqual(namen, dateiNamen); //Bei Zwei Listen die Inhalte vergleichen

		//Fahren alle Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug mindestens 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi);
		//fahrzeuge.Where(e => e.Marke == FahrzeugMarke.Audi).Count(); //Ineffizient

		//Wieviele Audis und BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi || e.Marke == FahrzeugMarke.BMW);

		//Einfaches Linq mit Selektoren
		fahrzeuge.Sum(e => e.MaxV);
		fahrzeuge.Select(e => e.MaxV).Sum();

		fahrzeuge.Average(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Min: Das kleinste Element (Ergebnis int)
		fahrzeuge.MinBy(e => e.MaxV); //MinBy: Das Element mit dem kleinsten Kriterium (Ergebnis Fahrzeug)

		fahrzeuge.Max(e => e.MaxV); //Max: Das größte Element (Ergebnis int)
		fahrzeuge.MaxBy(e => e.MaxV); //MaxBy: Das Element mit dem größten Kriterium (Ergebnis Fahrzeug)

		//Teile die Liste in X große Teile auf
		fahrzeuge.Chunk(10); //10er Array, 2er Array

		//Die Durchschnittsgeschwindigkeit aller VWs
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);

		//Alle Autos nach Marke gruppieren
		fahrzeuge.GroupBy(e => e.Marke); //Audi-Gruppe, BMW-Gruppe, VW-Gruppe

		IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> x = fahrzeuge.GroupBy(e => e.Marke); //Typ unhandlich

		Dictionary<FahrzeugMarke, List<Fahrzeug>> dict = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.ToList());

		Dictionary<FahrzeugMarke, double> avg = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.Average(x => x.MaxV)); //Unterschiedliche Namen bei verschachtelten Linq-Abfragen (e von außen ist innen auch verwendbar)

		//Aggregate
		string output = fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n");
		Console.WriteLine(output);

		IEnumerable<Fahrzeug> vws = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);
		foreach (Fahrzeug fzg in vws)
			Console.WriteLine($"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.");

		Console.WriteLine(fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n"));

		Console.WriteLine(string.Join('\n', fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV}km/h fahren.")));
		#endregion

		#region Erweiterungsmethoden
		int y = 523479;
		y.Quersumme();

		Console.WriteLine(983257.Quersumme());

		fahrzeuge.Shuffle(); //Neue Liste wiedereinmal
		#endregion
	}
}

[DebuggerDisplay("Marke: {Marke}, Geschwindigkeit: {MaxV} - {typeof(Fahrzeug).FullName}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }