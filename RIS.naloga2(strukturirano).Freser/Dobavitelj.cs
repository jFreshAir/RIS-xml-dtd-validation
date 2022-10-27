using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RIS.naloga2_strukturirano_.Freser
{
    public class Dobavitelj
    {
		private string id;

		[XmlAttribute]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		private string naziv;

		public string Naziv
		{
			get { return naziv; }
			set { naziv = value; }
		}

		private string naslov;

		public string Naslov
		{
			get { return naslov; }
			set { naslov = value; }
		}

		private string davcna;

		public string Davcna
		{
			get { return davcna; }
			set { davcna = value; }
		}

		private string kontakt;

		public string Kontakt
		{
			get { return kontakt; }
			set { kontakt = value; }
		}

		private string opis;

		public string Opis
		{
			get { return opis; }
			set { opis = value; }
		}

		public override string ToString()
		{
			return $"ID: {id.ToString()}, Naziv: {naziv}, Naslov: {naslov}, Davčna: {davcna}, Kontakt: {Kontakt}, Opis: {opis}";

        }
	}
}
