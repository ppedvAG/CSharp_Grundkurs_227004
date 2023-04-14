namespace M014;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		List<int> x = Enumerable.Range(10, 100).ToList();

		Action<int, int> action = Addiere; //Action: Methode mit void als Rückgabewert und bis zu 16 Parametern
		action(2, 3);
		DoAction(5, 8, Addiere); //Eigene Methode schreiben mit Action Parameter
		DoAction(5, 3, action); //Über die Action das Verhalten der Methode anpassen

		//Action Beispiele
		x.ForEach(Console.WriteLine); //Beispiel für Action Methode in List
		x.ForEach(PrintMalZwei); //Verhalten anpassen: 1. cw, 2. PrintMalZwei

		/////////////////////////////////

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		bool b = pred(0); //Ergebnis von Predicate in einer Variable speichern
		DoPredicate(3, CheckForZero); //Eigene Methode schreiben mit Predicate Parameter
		DoPredicate(0, pred); //Über das Predicate das Verhalten der Methode anpassen

		//Predicate Beispiele
		x.Find(CheckForZero);
		x.FindAll(pred);

		/////////////////////////////////

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Typ), bis zu 16 Parameter
		double d = func(3, 6);
		DoFunc(3, 6, Multipliziere); //Eigene Methode schreiben mit Func Parameter
		DoFunc(2, 4, func); //Über die Func das Verhalten der Methode anpassen

		//Func Beispiele
		//=> Linq

		/////////////////////////////////

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(4, 6, (x, y) => Console.WriteLine(x - y));
		DoAction(4, 6, (x, y) => Console.WriteLine(x + y));

		DoPredicate(2, (x) => x % 2 == 0);
		DoPredicate(2, x => x % 2 == 0); //Klammern optional bei einem Parameter

		DoFunc(3, 9, (x, y) => (double) x / y);
		DoFunc(4, 6, (x, y) => (double) x % y);
	}

	#region Action
	static void Addiere(int x, int y) => Console.WriteLine(x + y);

	static void DoAction(int x, int y, Action<int, int> action) => action(x, y);

	static void PrintMalZwei(int x) => Console.WriteLine(x * 2);
	#endregion

	#region Predicate
	static bool CheckForZero(int x) => x == 0;

	static bool DoPredicate(int x, Predicate<int> pred) => pred(x);
	#endregion

	#region Func
	static double Multipliziere(int x, int y) => x * y;

	static double DoFunc(int x, int y, Func<int, int, double> func) => func(x, y);
	#endregion
}