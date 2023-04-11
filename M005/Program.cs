namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(3, 5);
			PrintAddiere(4, 5);
			PrintAddiere(6, 5);
			PrintAddiere(8, 5);
			PrintAddiere(30, 5);

			int summe = Addiere(3, 2);
			Console.WriteLine(summe); //18 Overloads -> F12 in die Klasse springen

			Console.WriteLine("");
			Console.WriteLine('1');
			Console.WriteLine();

			Addiere(2, 3);
			Addiere(2d, 3); //Double Overload auswählen durch einen double
			Addiere(1, 2, 3);

			Summiere(); //Keine Parameter sind auch beliebig viele Parameter
			Summiere(1, 2, 3);
			Summiere(1, 2, 3, 4, 5, 6);

			Subtrahiere(4, 2);
			Subtrahiere(4, 2, 5); //z überschreiben

			SubtrahiereOderAddiere(5, 2);
			SubtrahiereOderAddiere(5, 6);
			SubtrahiereOderAddiere(3, 2);
			SubtrahiereOderAddiere(54, 2);
			SubtrahiereOderAddiere(54, 2, true);

			PrintPerson(alter: 10);
			PrintPerson(nachname: "Test", alter: 20);
			PrintPerson(vorname: "Test", alter: 20);

			int sub = 0;
			AddiereUndSubtrahiere(4, 3, out sub);

			//int parse = 0;
			//if (int.TryParse("123", out parse))
							
			if (int.TryParse("123", out int parse)) //Compiler schreibt danach eine Variable darüber
			{
				Console.WriteLine(parse);
			}
			else
			{
				Console.WriteLine("Parsen fehlgeschlagen");
			}

			(int, int) t = AddiereUndSubtrahiere(4, 6);
			Console.WriteLine(t.Item1);
			Console.WriteLine(t.Item2);

			var t2 = AddiereUndSubtrahiere(4, 6);
			Console.WriteLine(t2.a);
			Console.WriteLine(t2.s);
		}

		public static void PrintAddiere(int x, int y)
		{
			Console.WriteLine($"{x} + {y} = {x + y}");
		}

		public static int Addiere(int x, int y)
		{
			return x + y;
		}

		public static double Addiere(double x, double y)
		{
			return x + y;
		}

		public static int Addiere(int x, int y, int z)
		{
			return x + y + z;
		}

		public static int Summiere(params int[] ints) //Array erzwingend, beim Aufruf ist es dann kein Array mehr
		{
			return ints.Sum();
		}

		public static int Subtrahiere(int x, int y, int z = 0)
		{
			return x - y - z;
		}

		public static int SubtrahiereOderAddiere(int x, int y, bool add = false)
		{
			//if (add)
			//	return x + y;
			//else
			//	return x - y;
			return add ? x + y : x - y;
		}

		public static void PrintPerson(string vorname = "", string nachname = "", int alter = 0)
		{
			Console.WriteLine($"{vorname} {nachname}: {alter}");
		}

		public static int AddiereUndSubtrahiere(int x, int y, out int sub)
		{
			sub = x - y;
			return x + y;
		}

		public static (int a, int s) AddiereUndSubtrahiere(int x, int y)
		{
			return (x + y, x - y);
		}

		public static void PrintZahl(int zahl)
		{
			if (zahl < 0)
				return; //Beendet die Funktion

			Console.WriteLine();
			return;
			Console.WriteLine();
		}

		public static string PrintWochentag(DayOfWeek wt)
		{
			switch (wt)
			{
				case DayOfWeek.Monday: return "Montag"; //Bei einem Switch mit return muss kein break verwendet werden
				case DayOfWeek.Tuesday: return "Dienstag";
				case DayOfWeek.Wednesday: return "Mittwoch";
				case DayOfWeek.Thursday: return "Donnerstag";
				case DayOfWeek.Friday: return "Freitag";
				case DayOfWeek.Saturday: return "Samstag";
				case DayOfWeek.Sunday: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}
	}
}