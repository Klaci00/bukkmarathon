using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            if (time == "Nem teljesítő") { return 0; }
            else
            {
                string[] parts = time.Split(':');
                foreach (string part in parts)
                {
                    foreach (char s in part)
                    {
                        if (s != 0) break;
                        else part.Remove(s);

                    }
                }

                bool a, b, c;
                int hours, minutes, seconds, totalSeconds;

                a = int.TryParse(parts[0], out hours);
                b = int.TryParse(parts[1], out minutes);
                c = int.TryParse(parts[2], out seconds);

                if (a && b && c)
                {
                    totalSeconds = hours * 3600 + minutes * 60 + seconds;
                    return totalSeconds;
                }
                else { throw new FormatException(); }
            }
        }
    }
}
