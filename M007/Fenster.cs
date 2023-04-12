namespace M007;

internal class Fenster
{
	#region Variable + Get/Set
	private double laenge;

	public double GetLaenge()
	{
		return laenge;
	}

	/// <summary>
	/// Setzt die Länge des Fensters auf einen neuen Wert.
	/// </summary>
	/// <param name="neueLaenge">Die neue Länge des Fenstern in Meter (0 bis 10)</param>
	public void SetLaenge(double neueLaenge)
	{
		if (neueLaenge > 0 && neueLaenge < 10)
			laenge = neueLaenge;
		else
			Console.WriteLine("Neue Länge zu klein/groß");
	}
	#endregion

	#region Properties
	private double breite;

	public double Breite
	{
		get
		{
			return breite;
		}
		set
		{
			if (value > 0 && value < 10)
				breite = value;
			else
				Console.WriteLine("Neue Breite zu klein/groß");
		}
	}

	public double BreiteKurz
	{
		get => breite;
		set
		{
			if (value > 0 && value < 10)
				breite = value;
			else
				Console.WriteLine("Neue Breite zu klein/groß");
		}
	}

	private FensterStatus status = FensterStatus.Geschlossen;

	public FensterStatus Status
	{
		get => status;
		private set => status = value; //Nur innerhalb der Klasse setzbar
	}

	public void FensterOeffnen()
	{
		if (Status != FensterStatus.Offen)
			Status = FensterStatus.Offen;
		else
			Console.WriteLine("Fenster ist bereits geöffnet");
	}

	public double Area
	{
		get
		{
			return laenge * breite;
		}
	}

	public double Area2
	{
		get => laenge * breite;
	}

	public double Area3 => laenge * breite;

	public double CalcArea() => laenge * breite;

	public int Scheibenanzahl { get; set; } = 2;
	#endregion

	public Fenster() { } //Leerer Konstruktor wird gelöscht wenn ein eigener Konstruktor erstellt wird

	public Fenster(double laenge, double breite)
	{
		this.laenge = laenge;
		this.breite = breite;
	}

	public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite)
	{
		Scheibenanzahl = scheiben;
	}

	~Fenster()
	{
		Console.WriteLine($"Fenster eingesammelt: {GetHashCode()}");
	}
}

public enum FensterStatus
{
	Offen,
	Gekippt,
	Geschlossen
}