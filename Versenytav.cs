using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkMaraton2019
{
    public class Versenytav
    {
        public string Rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev {  get; set; }
        public string Egyesulet { get; set; }
        public string Ido {  get; set; }
        public Versenytav(string rajtszam,string kategoria, string nev, string egyesulet, string ido) 
        {
            Rajtszam = rajtszam;
            Kategoria = kategoria;
            Nev = nev;
            Egyesulet = egyesulet;
            Ido = ido;

        }

        public string Tav()
        {
            char[] rajtsz=Rajtszam.ToCharArray();
            char kategoria = rajtsz[0];
            Dictionary<char, string> kategoriaDict = new()
            {
                {'R', "Rövidtáv"},
                {'K', "Középtáv" },
                {'H', "Hosszútáv" },
                {'M', "Marathon" },
                {'E', "E-bike" }
            };
        return kategoriaDict[kategoria] ; }

        public string Nem()
        {
            char[] nem = Kategoria.Trim().ToCharArray();
            
            if (nem[nem.Length-1] == 'n')
            {
                return "Nő";
            }
            else return "Férfi";
        }

        public static int Getseconds(string time)
        {
            string[] parts=time.Split(':');
            foreach (string part in parts)
            {
                foreach (char s in part)
                {
                    if (s != 0) break;
                    else part.Remove(s);

                }
            }
            Console.WriteLine(parts);
            int hours = Convert.ToInt32( parts[0]);
            int minutes = Convert.ToInt32( parts[1]);
            int seconds = Convert.ToInt32( parts[2]);

            int totalSeconds=hours*3600+minutes*60+seconds;
            return totalSeconds;
        }
    }
}
