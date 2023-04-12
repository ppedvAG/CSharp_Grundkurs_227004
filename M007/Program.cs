namespace M007
{
	internal class Program
	{
		static string Info { get; set; }

		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 5; i++)
			{
				Fenster f = new Fenster();
				Console.WriteLine($"Fenster {i}: {f.GetHashCode()}");
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
			#endregion

			#region Static
			//new Console(); //Nicht möglich, da statische Klasse
			Console.WriteLine();

			//new Program().Info //Nicht möglich
			Program.Info = "Test";

			//Test(); //Nicht möglich, da Objekt benötigt

			Program[] p = new Program[5];
			for (int i = 0; i < p.Length; i++)
				p[i] = new Program();
			Program.Info = "Noch ein Test";
			#endregion

			#region Werte-/Referenztypen
			//Wertetyp
			int original = 5;
			int x = original;
			original = 10;

			Console.WriteLine(original.GetHashCode());
			Console.WriteLine(x.GetHashCode());

			//Referenztyp
			Fenster f3 = new Fenster();
			Fenster f4 = f3;
			f3.Scheibenanzahl = 100;

			Console.WriteLine(f3.GetHashCode());
			Console.WriteLine(f4.GetHashCode());

			//class
			//Referenztyp
			//Zuweisungen haben Referenzen statt Kopien
			//==, != vergleichen Speicheradressen statt Inhalte

			//struct
			//Wertetyp
			//Zuweisungen erzeugen Kopien statt Referenzen
			//==, != werden die Werte des Objekts verglichen
			#endregion

			#region Null
			Fenster f5; //Standard: null
			f5 = null;
			//f5.FensterOeffnen();

			if (f5 == null || f5 != null)
			{

			}

			if (f5 is null || f5 is not null) //Selbiges wie == und !=
			{

			}
			#endregion
		}

		public void Test()
		{
			Main(null);
		}
	}
}