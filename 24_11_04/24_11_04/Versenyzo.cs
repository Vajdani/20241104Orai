namespace _24_11_04;

internal class Versenyzo
{
    public string Nev { get; set; }
    public int SzuletesiEv { get; set; }
    public string Rajtszam { get; set; }
    public bool Nem { get; set; }
    public string Kategoria { get; set; }
    public Dictionary<string, TimeSpan> Idok { get; set; }

    public Versenyzo(string line)
    {
        string[] split = line.Split(';');
        Nev = split[0];
        SzuletesiEv = int.Parse(split[1]);
        Rajtszam = split[2];
        Nem = split[3] == "f";
        Kategoria = split[4];

        Idok = new()
        {
            { "úszás",      TimeSpan.Parse(split[5]) },
            { "I. depó",    TimeSpan.Parse(split[6]) },
            { "kerékpár",   TimeSpan.Parse(split[7]) },
            { "II. depó",   TimeSpan.Parse(split[8]) },
            { "futás",      TimeSpan.Parse(split[9]) },
        };
    }

    public override string ToString() => $"[{Rajtszam}] {Nev} ({(Nem ? "Férfi" : "Nő")}, {Kategoria})";
}
