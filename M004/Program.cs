using System.Net;

namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;

			while (a < b)
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife
				a++;
			}

			int c = 0;
			int d = 10;

			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //Code danach überspringen und zum Kopf/Fuß zurück
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;
			while (true)
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine("while true: " + c);

				if (c >= d) //Äquivalent zur Bedingung im do-while
					break;
			}

			//for + Tab + Tab
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("for: " + i);
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine("forr: " + i);
			}

			//for-Schleife ist sehr flexibel
			for (int i = 0, x = 1; i < 10 && x < 10; i+=2, x *= 2)
			{

			}

			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			for (int i = 0; i < zahlen.Length; i++)
			{
				Console.WriteLine(zahlen[i]);
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen)
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(item);

			string s = "Hallo";
			foreach (char z in s) //String durchgehen mit foreach
			{
				Console.WriteLine(z);
			}
			#endregion

			#region Enums
			string tag = Console.ReadLine();
			if (tag == "Montag")
			{
				Console.WriteLine("Es ist Montag"); //Fehleranfälligkeit bei Strings
			}

			Wochentag wt = Enum.Parse<Wochentag>(tag); //Konvertiert einen String oder eine Zahl zu dem gegebenen Enum
			if (wt == Wochentag.Mo)
			{
				Console.WriteLine("Es ist Montag");
			}

			int e = 0;
			Wochentag w = (Wochentag) e;
			Console.WriteLine(w);
			int r = (int) w;

			Wochentag[] tage = Enum.GetValues<Wochentag>();
			foreach (Wochentag t in tage)
			{
				Console.WriteLine(t);
			}

			Flags f = Flags.A | Flags.B;
			if (f.HasFlag(Flags.A))
			{

			}
			#endregion

			#region Switch
			Wochentag sw = Wochentag.Di;
			if (sw == Wochentag.Mo) 
			{
				Console.WriteLine("Wochenanfang");
			}
			else if (sw == Wochentag.Di || sw == Wochentag.Mi || sw == Wochentag.Do || sw == Wochentag.Fr)
			{
				Console.WriteLine("Wochenmitte");
			}
			else if (sw == Wochentag.Sa || sw == Wochentag.So)
			{
				Console.WriteLine("Wochenende");
			}
			else
			{
				Console.WriteLine("Fehler");
			}

			switch (sw)
			{
				case Wochentag.Mo:
					Console.WriteLine("Wochenanfang");
					break;
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}

			switch (sw)
			{
				//and und or statt && und ||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}
			#endregion
		}
	}

	enum Wochentag
	{
		Mo = 1, //Enumwerten eigene Werte zuweisen
		Di,
		Mi,
		Do = 10, //hier neu anfangen zu zählen
		Fr,
		Sa,
		So
	}

	[Flags]
	enum Flags
	{
		A = 1, //0001
		B = 2, //0010
		C = 4, //0100
		D = 8  //1000
	}
}