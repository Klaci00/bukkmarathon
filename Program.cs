// See https://aka.ms/new-console-template for more information
using BukkMaraton2019;
using System.Reflection;
using System.Runtime.ExceptionServices;

string dir = Directory.GetCurrentDirectory();
Console.WriteLine(dir);

string filepath = "./2019_bukkmaraton_eredmeny.csv";

FileStream fileStream = File.Open(path:filepath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
BufferedStream bufferedStream = new BufferedStream(fileStream);
StreamReader reader = new StreamReader(bufferedStream);

List<Versenytav> adatok = new List<Versenytav>();

string line;

while ((line = reader.ReadLine()) != null)
{
    string[] strings = line.Split(';');
    string rajtszam = strings[0];
    string kategoria = strings[1];
    string nev=strings[2];
    string egyesulet=strings[3];
    string ido = strings[4];
    if (kategoria!="Kategória "){
        Versenytav versenytav = new(rajtszam:rajtszam,kategoria: kategoria,nev:nev,egyesulet:egyesulet,ido:ido);
        adatok.Add(versenytav);
        Console.WriteLine(versenytav.FelnottFerfi());
    }
}

Console.WriteLine("4-es feladat");

int DNF = adatok.Count(x => x.Ido == "Nem teljesítő");

double DNFratio = (Convert.ToDouble(DNF) / adatok.Count())*100;

Console.WriteLine($"A versenyzők {Math
    .Round(DNFratio,2)}%-a nem teljesítette a versenyt.");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("5-ös feladat");

int femaleShort = adatok.Count(x=>x.Nem()=="Nő" && x.Tav()=="Rövidtáv");

Console.WriteLine($"A rövidtávon induló nők létszáma: {femaleShort}");

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("6-os feladat");

foreach (Versenytav versenytav in adatok)
{
    if (Versenytav.Getseconds(versenytav.Ido) < (3600 * 6))
    {
        Console.WriteLine("Volt olyan versenyző, aki több mint hat órát töltött a versenypályán.");
        break;
    }
    else Console.WriteLine("Nem volt olyan versenyző, aki több mint hat órát töltött a versenypályán.");
}

Console.WriteLine("--------------------------------------------------");
Console.WriteLine("7-es feladat");

var felnottferfirovid = adatok.Where(x => x.FelnottFerfi() && x.Tav() == "Rövidtáv");

var winner = felnottferfirovid.MinBy(x =>Versenytav.Getseconds(x.Ido));

Console.WriteLine($"A győztes {winner.Nev}, rajtszáma: {winner.Rajtszam}, {winner.Ido} idővel teljesítette a {winner.Tav()}ot. Kategóriája: {winner.Kategoria} ");

if (winner.Kategoria.Length == 0)
{ Console.WriteLine("Nem tagja egyesületnek."); }
else Console.WriteLine($"Egyesülete: {winner.Egyesulet}");
