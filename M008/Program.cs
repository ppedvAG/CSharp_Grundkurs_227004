namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 23);
		m.Name = "Test"; //Property wurde vererbt
		m.WasBinIch(); //Methode wurde vererbt

		Lebewesen lw = new Lebewesen("Test");

		lw.WasBinIch2();
		m.WasBinIch2();

		Katze k = new Katze("");
		k.WasBinIch2(); //Basisimplementation wird verwendet

		Console.WriteLine(lw.ToString()); //M008.Lebewesen
		Console.WriteLine(m.ToString()); //M008.Mensch
		Console.WriteLine(384.ToString()); //Überschrieben -> Zahl selbst (384)
	}
}

public class Lebewesen
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	public void WasBinIch()
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public virtual void WasBinIch2()
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}
}

public sealed class Mensch : Lebewesen //Mensch erbt von Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Mit base den oberen Konstruktor verketten
	{
		Alter = alter;
	}

	public override sealed void WasBinIch2() //sealed: Vererbung von Klassen oder Methoden verhindern
	{
		//base.WasBinIch2(); //Hier mit base die obere Methode aufrufen
		Console.WriteLine("Ich bin ein Mensch");
	}

	public override sealed string ToString()
	{
		return base.ToString();
	}
}

//public class Kind : Mensch
//{
//	public Kind(string name, int alter) : base(name, alter)
//	{
//	}

//	public override void wasbinich2()
//	{
//		base.wasbinich2();
//	}
//}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{
	}
}