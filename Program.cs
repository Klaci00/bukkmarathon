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
    }
}

Console.WriteLine("4-es feladat");

int DNF = adatok.Count(x => x.Ido == "Nem teljesítő");

double DNFratio = (Convert.ToDouble(DNF) / adatok.Count())*100;

Console.WriteLine($"A versenyzők {Math
    .Round(DNFratio,2)}%-a nem teljesítette a versenyt.");

Console.WriteLine("5-ös feladat");

int femaleShort = adatok.Count(x=>x.Nem()=="Nő" && x.Tav()=="Rövidtáv");

Console.WriteLine($"A rövidtávon induló nők létszáma: {femaleShort}");