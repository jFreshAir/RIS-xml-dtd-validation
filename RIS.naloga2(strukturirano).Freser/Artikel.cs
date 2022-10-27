using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RIS.naloga2_strukturirano_.Freser
{
    public class Artikel
    {

        private string id;

        [XmlAttribute]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private int aktiven;

        [XmlAttribute]
        public int Aktiven
        {
            get { return aktiven; }
            set { aktiven = value; }
        }


        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value; }
        }

        private int zaloga;

        public int Zaloga
        {
            get { return zaloga; }
            set { zaloga = value; }
        }

        private DateTime zadnjaNabava;

        public DateTime ZadnjaNabava
        {
            get { return zadnjaNabava; }
            set { zadnjaNabava = value; }
        }


        private int idDobavitelja;

        public int IdDobavitelja
        {
            get { return idDobavitelja; }
            set { idDobavitelja = value; }
        }

        public string Rezerva { get; set; }

        public override string ToString()
        {
            return $"ID: {id.ToString()}, Naziv: {naziv}, Cena: {cena.ToString()}, Zaloga: {zaloga.ToString()}, Zadnja nabava: {zadnjaNabava.ToString("dd-MM-yyyy")}, ID dobavitelja: {idDobavitelja.ToString()}";
        }
    }
}
