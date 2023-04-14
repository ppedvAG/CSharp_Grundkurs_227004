using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern

		string folderPath = Path.Combine(desktop, "Test");

		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new PKW(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Streams();

		//SystemJson();

		//NewtonsoftJson();

		//XML();
	}

	static void Streams()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern

		string folderPath = Path.Combine(desktop, "Test");

		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Flush();
		sw.Close();

		using (StreamWriter sw2 = new(filePath)) //using-Block: Hier ein Disposable Objekt deklaration, es wird am Ende geschlossen
		{
			sw2.WriteLine("Test4");
			sw2.WriteLine("Test5");
			sw2.WriteLine("Test6");
		} //Hier .Close() automatisch

		using StreamWriter sw3 = new(filePath); //using-Statement: Selbiges wie using-Block, Stream wird am Ende der Methode geschlossen
		sw3.WriteLine("Test4");
		sw3.WriteLine("Test5");
		sw3.WriteLine("Test6");
		sw3.Close();

		using StreamReader sr = new(filePath);
		string file = sr.ReadToEnd();
		file.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

		sr.BaseStream.Position = 0;

		List<string> lines = new List<string>();
		while (!sr.EndOfStream)
		{
			string line = sr.ReadLine();
			lines.Add(line);
		}

		sr.Close();


		string text = File.ReadAllText(filePath);
		string[] l = File.ReadAllLines(filePath);

		File.WriteAllText(filePath, "Text1\nText2");
		File.WriteAllLines(filePath, lines);
	}

	static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern

		string folderPath = Path.Combine(desktop, "Test");

		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new PKW(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//JsonSerializerOptions options = new(); //Wichtig: Options bei Serialize/Deserialize mitgeben
		//options.WriteIndented = true;

		//string json = JsonSerializer.Serialize(fahrzeuge, options);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] fzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options);
	}

	static void NewtonsoftJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern

		string folderPath = Path.Combine(desktop, "Test");

		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new PKW(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		JsonSerializerSettings settings = new();
		settings.Formatting = Formatting.Indented;
		settings.TypeNameHandling = TypeNameHandling.Objects;

		string json = JsonConvert.SerializeObject(fahrzeuge, settings);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] fzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings);
	}

	static void XML()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern

		string folderPath = Path.Combine(desktop, "Test");

		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new PKW(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
		{
			xml.Serialize(sw.BaseStream, fahrzeuge);
		}

		using StreamReader sr = new(filePath);
		List<Fahrzeug> f = xml.Deserialize(sr.BaseStream) as List<Fahrzeug>;
	}
}

[JsonDerivedType(typeof(Fahrzeug), "F")]
[JsonDerivedType(typeof(PKW), "P")]
[XmlInclude(typeof(Fahrzeug))]
[XmlInclude(typeof(PKW))]
public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	[System.Text.Json.Serialization.JsonIgnore]
	//[Newtonsoft.Json.JsonIgnore]
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

	public Fahrzeug()
	{

	}
}

[MyAttribute]
public class PKW : Fahrzeug
{
	[MyAttribute]
	public PKW(int v, FahrzeugMarke fm) : base(v, fm)
	{
	}

	public PKW()
	{

	}
}

public enum FahrzeugMarke { Audi, BMW, VW }


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor)]
public class MyAttribute : Attribute { }