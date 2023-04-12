namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("", 12); //Variablentyp Mensch, kann Mensch oder Unterklassen von Mensch halten
		
		Lebewesen lw = new Mensch("", 23); //Variablentyp Lebewesen, kann Lebewesen oder Unterklassen von Lebewesen halten

		lw = m; //Kompatibel weil Lebewesen > Mensch
		//m = lw; //Nicht kompatibel
		m = (Mensch) lw; //Möglich durch Cast, wenn an lw ein Mensch Objekt hängt

		object o = new object(); //Variablentyp Object, kann alle Objekte halten
		o = m; //Mensch
		o = 123; //int
		o = false; //bool
		o = "Test"; //string

		//GetType(): gibt den Typen des Objekts zurück
		Console.WriteLine(m.GetType()); //M009.Mensch
		Console.WriteLine(lw.GetType()); //M009.Mensch
		Console.WriteLine(o.GetType()); //System.String

		//typeof(<Klassenname>): Ein Typ Objekt über einen Klassennamen erzeugen
		Console.WriteLine(typeof(Mensch)); //M009.Mensch

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //Ist m genau ein Mensch?
		{
			//true
		}

		if (m.GetType() == typeof(Lebewesen))
		{
			//false
		}
		#endregion

		#region Vererbungshierarchie Typvergleich
		if (m is Mensch) //Ist m ein Mensch oder eine Unterklasse von Mensch?
		{
			//true
		}

		if (m is Lebewesen)
		{
			//true
		}

		if (m is object)
		{
			//immer true
		}

		if (m is Program)
		{
			//false
		}
		#endregion

		#region Virtual Override
		Mensch mensch = new Mensch("", 12);
		mensch.WasBinIch(); //Ich bin ein Mensch und bin 12 Jahre alt

		Lebewesen lebewesen = mensch;
		lebewesen.WasBinIch(); //Ich bin ein Mensch und bin 12 Jahre alt
								//Verbindung zwischen Lebewesen und Mensch hergestellt, deshalb wird die Mensch Methode verwendet
		#endregion

		#region New
		Mensch mensch2 = new Mensch("", 12);
		mensch2.WasBinIch2(); //Ich bin ein Mensch und bin 12 Jahre alt

		Lebewesen lebewesen2 = mensch2;
		lebewesen2.WasBinIch2(); //Ich bin ein Lebewesen
								 //Hier wird die Methode von Lebewesen verwendet, da die Verbindung getrennt wurde
		#endregion

		Lebewesen[] array = new Lebewesen[3];
		array[0] = new Mensch("", 34);
		array[1] = new Katze("");
		array[2] = new Mensch("", 111);
		//array[3] = new Lebewesen(""); //Von Abstrakten Klassen können keine Objekte erstellt werden

		foreach (Lebewesen leb in array) //Hier nur generisches Lebewesen, mit Typvergleichen überprüfen was das Objekt ist
		{
			if (leb.GetType() == typeof(Katze))
			{
				Katze k = (Katze) leb;
				k.KatzeMethode();
			}

			if (leb is Mensch men)
			{
				//Mensch men = (Mensch) leb; //Kann gespart werden, da die Variablendeklaration in der if passiert
				men.MenschMethode();
			}
		}
	}
}

public abstract class Lebewesen //abstract: Strukturklasse für die Unterklassen, kann keine Objekte erzeugen
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	public void WasBinIch2()
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public virtual void WasBinIch()
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public abstract void Bewegen();
}

public class Mensch : Lebewesen //Mensch erbt von Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Mit base den oberen Konstruktor verketten
	{
		Alter = alter;
	}

	public new void WasBinIch2()
	{
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	public override void WasBinIch()
	{
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	public override void Bewegen()
	{
		Console.WriteLine("Der Mensch bewegt sich");
	}

	public void MenschMethode()
	{

	}
}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{
	}

	public override void Bewegen()
	{
		throw new NotImplementedException();
	}

	public void KatzeMethode()
	{

	}
}