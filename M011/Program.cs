using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//List: funktioniert wie Array ([], foreach, ...) nur hat beliebig viele Plätze
		List<int> list = new List<int>(); //T: Generisches Typargument, alle T's in der Klasse werden durch den gegebenen Typen ersetzt
		list.Add(1); //Add(T) -> Add(int)
		list.Add(2); //T wird ersetzt durch int
		list.Add(3);

		List<string> strings = new List<string>();
		strings.Add("a"); //T wird ersetzt durch string

		Console.WriteLine(list[1]); //wie bei Array angreifen
		
		list[1] = 10; //Wert an einer Stelle überschreiben

		Console.WriteLine(list.Count); //hier nicht list.Count() verwenden

		list.Sort();

		foreach (int i in list) //Liste iterieren wie bei Array
		{
			Console.WriteLine(i);
		}

		if (list.Contains(1))
		{
			//true
		}

		list.Clear();

		/////////////////////////////////////////
		
		Stack<int> stack = new Stack<int>();
		stack.Push(1); //Elemente auflegen
		stack.Push(2);
		stack.Push(3);
		stack.Push(4);

		Console.WriteLine(stack.Peek()); //Oberstes Element anschauen

		Console.WriteLine(stack.Pop()); //Oberstes Element anschauen und entfernen

		Queue<int> queue = new Queue<int>();
		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);

		Console.WriteLine(queue.Peek()); //Vorderstes Element anschauen

		Console.WriteLine(queue.Dequeue()); //Vorderstes Element anschauen und entfernen

		/////////////////////////////////////////

		//Liste von Key-Value Paaren (Map), Keys müssen eindeutig sein
		Dictionary<string, int> einwohnerzahlen = new(); //new(): Target-Typed New, Typ bei new wird von der Variable links ergänzt
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000);

		if (einwohnerzahlen.ContainsKey("Wien"))
		{

		}

		Console.WriteLine(einwohnerzahlen.ContainsValue(2_000_000));

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary angreifen mit [] über den Key, Value als Ergebnis

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var: Typ ergänzen, Strg + . um den Typen von VS generieren zu lassen
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
		}

		List<string> keys = einwohnerzahlen.Keys.ToList(); //Nur Keys durchgehen
		List<int> values = einwohnerzahlen.Values.ToList(); //Nur Values durchgehen

		foreach (string s in einwohnerzahlen.Keys)
		{

		}

		SortedDictionary<string, int> sortedEinwohnerzahlen = new(); //1:1 wie Dictionary, sortiert sich automatisch nach dem Key
		sortedEinwohnerzahlen.Add("Wien", 2_000_000);
		sortedEinwohnerzahlen.Add("Berlin", 3_650_000); //Berlin vor Wien
		sortedEinwohnerzahlen.Add("Paris", 2_160_000); //Paris zwischen Berlin und WIen (achtung Performance)

		/////////////////////////////////////////

		ObservableCollection<string> str = new(); //Benachrichtigt bei Listenänderungen
		str.CollectionChanged += Str_CollectionChanged; //Methode wird jedes mal ausgeführt, wenn sich in der Liste etwas ändert
		str.Add("X");
		str.Add("Y");
		str.Add("Z");
		str.Remove("Y");
	}

	private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Element hinzugefügt: {e.NewItems[0]}");
				break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Element entfernt: {e.OldItems[0]}");
				break;
			default:
				Console.WriteLine($"Etwas anderes ist passiert: {e.Action}");
				break;
		}
	}
}