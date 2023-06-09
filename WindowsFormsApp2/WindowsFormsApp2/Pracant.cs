using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Pracant
    {
        

        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string TelCislo { get; set; }
        public DateTime Narozeni { get; set; }

        public Pracant(int id, string jmeno, string prijmeni, string telCislo, DateTime narozeni)
        {
            Id = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            TelCislo = telCislo;
            Narozeni = narozeni;
        }
        public Pracant(string jmeno, string prijmeni, string telCislo, DateTime narozeni)
        {
            Id = -1;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            TelCislo = telCislo;
            Narozeni = narozeni;
        }
        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { Id.ToString(), Jmeno, Prijmeni, TelCislo, Narozeni.ToShortDateString() });
        }
    }
}
