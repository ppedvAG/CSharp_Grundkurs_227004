namespace M002
{
	/// <summary>
	/// Die Program Klasse
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args">Die Programmargumente</param>
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			//Ein Kommentar

			/*
				 Mehrzeilige
				 Kommentare
			 */

			#region Variablen
			int zahl;
			zahl = 5;

			int zahl2 = 5;

			Console.WriteLine(zahl);

			int zahlMalZwei = zahl * 2;
			Console.WriteLine(zahlMalZwei);

			string wort = "Hallo";
			char zeichen = 'A';

			double kostenDouble = 35982.2358;
			float kostenFloat = 2940.32845f;
			decimal kostenDecimal = 324598.4357m; //Für Geldwerte

			bool b = true;
			#endregion

			#region Strings
			string kombi = "Das Wort ist " + wort + ", das Zeichen ist " + zeichen + ", die Zahl ist " + zahl; //Anstrengend

			//Interpolated String (Dollar-String): Ermöglicht Code innerhalb eines Strings
			string inter = $"Das Wort ist {wort}, das Zeichen ist {zeichen}, die Zahl ist {zahl}";

			Console.WriteLine(kombi);
			Console.WriteLine(inter);

			string code = $"Die Zahl mal drei ist: {zahl * 3}";

			string escape = "\n \t \\";
			string verbatim = @"\n \t \\";
			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_04_11\M002";

			string umbruch = @"Umbruch
Umbruch";
			#endregion

			#region Eingabe
			string eingabe = Console.ReadLine();

			ConsoleKeyInfo info = Console.ReadKey();

			int.Parse(eingabe);
			double.Parse(eingabe);
			#endregion

			#region Konvertierungen
			int x = 5;
			double d = x; //Implizite Konvertierung

			double d2 = 20.5;
			int x2 = (int) d2; //Konvertierung hier erzwingen -> Kommastellen werden abgeschnitten

			x.ToString(); //Beliebiges Objekt zu einem String konvertieren
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;
			Console.WriteLine(z1 + z2); //Ergebnis der Berechnung, originale Werte werden nicht verändert

			z1 += z2; //Originale Werte verändern

			z1++; //z1 plus 1 mit Zuweisung
			z1--;

			double round = 382754.32958729357;
			Math.Ceiling(round); //Aufrunden
			Math.Floor(round); //Abrunden
			Math.Round(round); //Rundet auf die nächsten Zahl, bei .5 wird auf die nächste gerade Zahl gerundet
			Math.Round(4.5); //4
			Math.Round(5.5); //6
			Math.Round(round, 2); //Auf X Kommastellen runden

			Console.WriteLine(8 / 5); //1.6 erwartet, 1 als Ergebnis da zwei Int Werte gegeben sind -> Int-Division
			Console.WriteLine(8d / 5); //Double-Division erzwungen
			Console.WriteLine(8 / 5d);
			Console.WriteLine(8f / 5);
			Console.WriteLine((double) z1 / z2);
			#endregion
		}
	}
}