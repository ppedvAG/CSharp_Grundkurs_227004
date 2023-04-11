namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			int[] zahlen;
			zahlen = new int[10];
			zahlen[3] = 5; //Index von 0 bis 9 bei Länge 10
			Console.WriteLine(zahlen[3]);

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Länge automatisch (5)
			int[] zahlenDirektKurz = new[] { 1, 2, 3, 4, 5 };
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 };

			Console.WriteLine(zahlen.Length);
			Console.WriteLine(zahlen.Contains(3)); //Ist das Element enthalten? true/false


			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3)
			zweiDArray = new[,]
			{
				{ 1, 2, 3 },
				{ 1, 2, 3 },
				{ 4, 5, 6 }
			};

			Console.WriteLine(zweiDArray[1, 1]);

			Console.WriteLine(zweiDArray.Length); //Gesamtanzahl der Elemente (9)
			Console.WriteLine(zweiDArray.Rank); //Anzahl der Dimensionen (2)
			Console.WriteLine(zweiDArray.GetLength(0)); //Länge der ersten Dimension (3)
			Console.WriteLine(zweiDArray.GetLength(1)); //Länge der zweiten Dimension (3)
			#endregion

			#region Bedingungen
			bool b1 = true;
			bool b2 = false;

			if (b1 ^ b2) //XOR: Wenn die Bedingungen unterschiedlich sind
			{

			}

			b1 = !b1;
			b1 ^= true;

			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean;
			//App.MainWindow.Button.Boolean ^= true;

			//Fragezeichen Operator (Ternary Operator): if/else kompakt machen
			if (zahlen.Length > 5)
			{
				Console.WriteLine("Zahlen Länge > 5");
			}
			else
			{
				Console.WriteLine("Zahlen Länge <= 5");
			}

			if (zahlen.Length > 5) //Einzeilige ifs und elses brauchen keine Klammern
				Console.WriteLine("Zahlen Länge > 5");
			else
				Console.WriteLine("Zahlen Länge <= 5");

			//zahlen.Length > 5 ? Console.WriteLine("Zahlen Länge > 5") : Console.WriteLine("Zahlen Länge <= 5"); //Nicht möglich
			Console.WriteLine(zahlen.Length > 5 ? "Zahlen Länge > 5" : "Zahlen Länge <= 5"); //? ist if, : ist else

			int x = 0;
			if (zahlen.Length > 5)
				x = 5;
			else
				x = zahlen.Length;

			int y = zahlen.Length > 5 ? 5 : zahlen.Length;
			#endregion
		}
	}
}