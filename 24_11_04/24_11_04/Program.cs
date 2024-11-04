using _24_11_04;

List<Versenyzo> versenyzok = new();

StreamReader r = new("..\\..\\..\\src\\forras.txt", encoding: System.Text.Encoding.UTF8);
while (!r.EndOfStream)
{
    versenyzok.Add(new Versenyzo(r.ReadLine()!));
}
r.Close();

Console.WriteLine($"{versenyzok.Count} versenyző vett részt a triatlonon.");    
Console.WriteLine($"{versenyzok.Count(p => p.Kategoria == "elit")} versenyző vett részt az elit kategórában.");
Console.WriteLine($"{versenyzok.Count(p => p.Kategoria == "elit junior")} versenyző vett részt az elit junior kategórában.");
Console.WriteLine($"{versenyzok.Count(p => p.Kategoria == "25-29")} versenyző vett részt a 25-29 kategórában.");
Console.WriteLine($"A versenyzők átlagéletkora {versenyzok.Average(p => DateTime.Now.Year - p.SzuletesiEv):0.00} év.");
Console.WriteLine($"A férfi versenyzők átlagéletkora {versenyzok.Where(p => p.Nem).Average(p => DateTime.Now.Year - p.SzuletesiEv):0.00} év.");
Console.WriteLine($"A női versenyzők átlagéletkora {versenyzok.Where(p => !p.Nem).Average(p => DateTime.Now.Year - p.SzuletesiEv):0.00} év.");
Console.WriteLine($"A versenyzők kerékpározással töltött összideje: {versenyzok.Sum(p => p.Idok["kerékpár"].TotalHours):0.00} óra");
Console.WriteLine($"A versenyzők futással töltött összideje: {versenyzok.Sum(p => p.Idok["futás"].TotalHours):0.00} óra");
Console.WriteLine($"Átlagos úszási idő elit junior kategóriában: {versenyzok.Where(p => p.Kategoria == "elit junior").Average(p => p.Idok["úszás"].TotalMinutes):0.00} perc");
Console.WriteLine($"Átlagos úszási idő 20-24 kategóriában: {versenyzok.Where(p => p.Kategoria == "20-24").Average(p => p.Idok["úszás"].TotalMinutes):0.00} perc");
Console.WriteLine($"Átlagos úszási idő elit kategóriában: {versenyzok.Where(p => p.Kategoria == "elit").Average(p => p.Idok["úszás"].TotalMinutes):0.00} perc");
Console.WriteLine($"A férfi győztes: {versenyzok.Where(p => p.Nem).MinBy(p => p.Idok.Sum(p => p.Value.TotalSeconds))}");
Console.WriteLine($"A női győztes: {versenyzok.Where(p => !p.Nem).MinBy(p => p.Idok.Sum(p => p.Value.TotalSeconds))}");

var kategoriak = versenyzok.GroupBy(p => p.Kategoria).OrderBy(p => p.Key);
Console.WriteLine("Korkategóriánként a versenyt befejezők száma(kategória, fő, depó idő):");
foreach (var item in kategoriak)
{
    Console.WriteLine($"\t{item.Key + ":", -11}\t{item.Count(), 2} fő\t{item.Average(p => (p.Idok["I. depó"] + p.Idok["II. depó"]).TotalMinutes):0.00} perc");
}

Console.WriteLine("Nemenként a versenyt befejezők száma");
foreach (var item in versenyzok.GroupBy(p => p.Nem).OrderBy(p => p.Key))
{
    Console.WriteLine($"\t{(item.Key ? "Férfi" : "Nő")}:\t{item.Count()} fő");
}