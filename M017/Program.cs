using System.Collections;

namespace M017;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Zug z = new();
		z += w1;
		z += w2;

		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z)
		{

		}

		//Console.WriteLine(z[2]);

		//Console.WriteLine(z["Rot"]);
		//z["rot"] = new();

		//Console.WriteLine(z[1, "Rot"]);

		System.Timers.Timer timer = new();
		timer.Elapsed += (sender, args) => Console.WriteLine("Intervall vergangen");
		timer.Interval = 1000;
		timer.Start();

		Console.ReadKey();
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons { get; set; } = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}

	public Wagon this[int i]
	{
		get { return Wagons[i]; }
		set { Wagons[i] = value; }
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anzSitze, string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe && e.AnzSitze == anzSitze);
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}