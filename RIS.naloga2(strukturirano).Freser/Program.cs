using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using RIS.naloga2_strukturirano_.Freser;

void NapolniSeznamArtiklov(List<Artikel> seznam)
{
    Artikel artikel1 = new Artikel { Id = "b1", Naziv = "Specialized Stump Jumper", Cena = 2250.2, Zaloga = 20, ZadnjaNabava = DateTime.Now.Date, IdDobavitelja = 1 };
    Artikel artikel2 = new Artikel { Id = "b2", Naziv = "SantaCruz", Cena = 5999.5, Zaloga = 2, ZadnjaNabava = DateTime.Now.Date, IdDobavitelja = 1 };
    Artikel artikel3 = new Artikel { Id = "b3", Naziv = "YT Capra", Cena = 3000.2, Zaloga = 10, ZadnjaNabava = DateTime.Now.Date, IdDobavitelja = 2 };
    Artikel artikel4 = new Artikel { Id = "b4", Naziv = "Trek Session", Cena = 5500.2, Zaloga = 5, ZadnjaNabava = DateTime.Now.Date, IdDobavitelja = 2 };
    Artikel artikel5 = new Artikel { Id = "b5", Naziv = "GT Fury", Cena = 3500.7, Zaloga = 13, ZadnjaNabava = DateTime.Now.Date, IdDobavitelja = 1 };
    seznam.Add(artikel1);
    seznam.Add(artikel2);
    seznam.Add(artikel3);
    seznam.Add(artikel4);
    seznam.Add(artikel5);

}

void NapolniSeznamDobaviteljev(List<Dobavitelj> seznam)
{
    Dobavitelj dobavitelj1 = new Dobavitelj { Id = "d1", Naziv = "Obsession", Davcna = "1192999", Kontakt = "+38603255433;obsession@gmail.com", Naslov = "Glavni trg 4", Opis = "Prodajalna s skate, bike in snow izdelki." };
    Dobavitelj dobavitelj2 = new Dobavitelj { Id = "d2", Naziv = "Fox", Davcna = "1155559", Kontakt = "+38603252271;Fox@gmail.com", Naslov = "Kočevje 15", Opis = "Prodajalna z kolesarsko opremo in oblačili." };
    Dobavitelj dobavitelj3 = new Dobavitelj { Id = "d3", Naziv = "Bike24", Davcna = "9928199", Kontakt = "+37213225430;bike24@gmail.com", Naslov = "Karlsberg, Germany", Opis = "Europes biggest bike parts supplier." };
    Dobavitelj dobavitelj4 = new Dobavitelj { Id = "d4", Naziv = "ExtremeVital", Davcna = "6666666", Kontakt = "+38603112932;ExtremeVital@gmail.com", Naslov = "Pod pohorjem 4", Opis = "Servis in prodaja kolesarske opreme." };
    Dobavitelj dobavitelj5 = new Dobavitelj { Id = "d5", Naziv = "Freestyle", Davcna = "2918223", Kontakt = "+38603199233;freestyle@gmail.com", Naslov = "Štubičeva ulica 15", Opis = "Vse za kolesa in kolesarja, servis koles." };

    seznam.Add(dobavitelj1);
    seznam.Add(dobavitelj2);
    seznam.Add(dobavitelj3);
    seznam.Add(dobavitelj4);
    seznam.Add(dobavitelj5);

}

//void SerializirajArtikleVDatoteko(List<Artikel> seznam, string pot)
//{
//    Artikli vsi = new();
//    vsi.Seznam = seznam;

//    var xmlSer = new XmlSerializer(typeof(Artikli));
//    using (var sw = new StreamWriter(pot))
//    {
//        xmlSer.Serialize(sw, vsi);
//    }
//}



//void DeserializacijaArtiklovVList(ref List<Artikel> seznam, string pot)
//{
//    var xmlSer = new XmlSerializer(typeof(List<Artikel>));
//    using(var sr = new StreamReader(pot))
//    {
//        seznam = (List<Artikel>)xmlSer.Deserialize(sr);
//    }
//}

//void DeserializacijaDobaviteljevVList(ref List<Dobavitelj> seznam, string pot)
//{
//    var xmlSer = new XmlSerializer(typeof(List<Dobavitelj>));
//    using (var sr = new StreamReader(pot))
//    {
//        seznam = (List<Dobavitelj>)xmlSer.Deserialize(sr);
//    }
//}

bool ValidacijaDokumenta(string pot)
{
    XmlReaderSettings settings = new();
    settings.DtdProcessing = DtdProcessing.Parse;
    settings.ValidationType = ValidationType.DTD;
    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
    settings.XmlResolver = new XmlUrlResolver();

    XmlReader reader = XmlReader.Create(pot, settings);

    while (reader.Read()) ;

    reader.Close();
    return true;
}


void SerializirajArtikleVDatoteko(List<Artikel> seznam, string pot)
{


    using XmlWriter xw2 = XmlWriter.Create(pot);
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Artikel>));

        xw2.WriteDocType("ArrayOfArtikel", null, "Artikel.dtd", null);
        xs.Serialize(xw2, seznam);
    }
}

void DeserializacijaArtiklovVList(ref List<Artikel> seznam, string pot)
{
    XmlReaderSettings settings = new();
    settings.DtdProcessing = DtdProcessing.Parse;
    settings.ValidationType = ValidationType.DTD;
    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
    settings.XmlResolver = new XmlUrlResolver();

    XmlReader reader = XmlReader.Create(pot, settings);

    while (reader.Read()) ;
    reader.Close();

    var xmlSer = new XmlSerializer(typeof(List<Artikel>));
    using (var sr = new StreamReader(pot))
    {
        seznam = (List<Artikel>)xmlSer.Deserialize(sr);
    }
}



void SerializirajDobaviteljeVDatoteko(List<Dobavitelj> seznam, string pot)
{
    using(XmlWriter xw = XmlWriter.Create(pot))
    {
        XmlSerializer xs = new XmlSerializer(typeof(List<Dobavitelj>));

        xw.WriteDocType("ArrayOfDobavitelj", null, "Dobavitelj.dtd", null);
        xs.Serialize(xw, seznam);
    }
}



void DeserializacijaDobaviteljevVList(ref List<Dobavitelj> seznam, string pot)
{
    XmlReaderSettings settings = new();
    settings.DtdProcessing = DtdProcessing.Parse;
    settings.ValidationType = ValidationType.DTD;
    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
    settings.XmlResolver = new XmlUrlResolver();

    XmlReader reader = XmlReader.Create(pot, settings);

    while (reader.Read()) ;

    reader.Close();

    var xmlSer = new XmlSerializer(typeof(List<Dobavitelj>));
    using (var sr = new StreamReader(pot))
    {
        seznam = (List<Dobavitelj>)xmlSer.Deserialize(sr);
    }
}


static void ValidationCallBack(object sender, ValidationEventArgs e)
{
    Console.WriteLine("Napaka: {0}", e.Message);
    Helper.valid = false;
}


List<Artikel> ListArtikli = new();
List<Dobavitelj> ListDobavitelji = new();

bool validacija = true;
bool zakljuci = false, main = false;



//if (ValidacijaDokumenta() == true)
//    Console.WriteLine("THE DOCUMENT IS VALID");
//else
//    Console.WriteLine("THE DOCUMENT IS NOT VALID");


//List<Artikel> pomocArtikel = new();
//NapolniSeznamArtiklov(pomocArtikel);
//SerializirajArtikleVDatoteko(pomocArtikel, @"C:\FERI\RIS\strukturirani\DefaultArtikli.xml");

while (!main)
{
    DeserializacijaArtiklovVList(ref ListArtikli, @"C:\FERI\RIS\strukturirani\DefaultArtikli.xml");
    DeserializacijaDobaviteljevVList(ref ListDobavitelji, @"C:\FERI\RIS\strukturirani\DefaultDobavitelji.xml");

    Console.Write("Želite upravljati z (1) Artikli ali (2) Dobavitelji: ");

    bool stevilo = false;
    int izbira1 = 0, izbira2 = 0;
    while (!stevilo)
    {
        try
        {
            izbira1 = int.Parse(Console.ReadLine());
            stevilo = true;
        }
        catch (Exception)
        {
            Console.WriteLine("Vpisati je potrebno število 1 ali 2.");
        }
    }
    switch (izbira1)
    {

        case 1:

            stevilo = false;
            while (!stevilo)
            {
                Console.WriteLine("Izberite številko operacije:\n 1-Vpis artikla \n 2-Branje artiklov \n 3-Znižanje cen");
                Console.WriteLine();
                try
                {
                    izbira2 = int.Parse(Console.ReadLine());
                    stevilo = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Vpisati je potrebno število 1, 2 ali 3.");
                }
            }

            switch (izbira2)
            {
                case 1:
                    Artikel nov = new();
                    Console.WriteLine();
                    Console.Write("Vpišite id artikla: ");

                    while (true)
                    {
                        try
                        {
                            nov.Id = Console.ReadLine();
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno celo število (1, 5, 32,...)");
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Vpišite naziv artikla: ");
                    nov.Naziv = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Vpišite cena artikla: ");
                    while (true)
                    {
                        try
                        {
                            nov.Cena = double.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno celo število (1, 3.5, 320.40,...)");
                        }
                    }
                    Console.WriteLine();
                    Console.Write("Vpišite zalogo artikla: ");
                    while (true)
                    {
                        try
                        {
                            nov.Zaloga = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno celo število (1, 5, 32,...)");
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Artikel je trenutno (1) AKTIVEN / (0) NEAKTIVEN: ");
                    while (true)
                    {
                        try
                        {
                            nov.Aktiven = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno celo število (1, 5, 32,...)");
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Vpišite id dobavitelja artikla: ");
                    while (true)
                    {
                        try
                        {
                            nov.IdDobavitelja = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno celo število (1, 5, 32,...)");
                        }
                    }

                    nov.ZadnjaNabava = DateTime.Now.Date;
                    nov.Rezerva = string.Empty;

                    ListArtikli.Add(nov);

                    // Najprej zapišemo v testno datoteko,
                    SerializirajArtikleVDatoteko(ListArtikli, @"C:\FERI\RIS\strukturirani\TESTDefaultArtikli.xml");
                    // jo validiramo in v primeru uspeha zapišemo v default datoteko
                    ValidacijaDokumenta(@"C:\FERI\RIS\strukturirani\TESTDefaultArtikli.xml");
                    if (Helper.valid)
                    {
                        Console.WriteLine("Document is valid");
                        SerializirajArtikleVDatoteko(ListArtikli, @"C:\FERI\RIS\strukturirani\DefaultArtikli.xml");
                        Console.WriteLine();
                        Console.WriteLine("Artikel uspešno dodan na seznam.");
                    }
                    else
                    {
                        Console.WriteLine("Document is NOT valid");
                        Console.WriteLine();
                        ListArtikli.Remove(nov);
                        Console.WriteLine("Dodan artikel ni bil dodan na seznam.");
                        Helper.valid = true;
                    }


                    break;

                case 2:
                    DeserializacijaArtiklovVList(ref ListArtikli, @"C:\FERI\RIS\strukturirani\DefaultArtikli.xml");
                    foreach (var en in ListArtikli)
                    {
                        Console.WriteLine(en.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Vpišite za koliko procentov (%)  želite znižati izdelke ");
                    double popust = 0;
                    while (true)
                    {
                        try
                        {
                            popust = double.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Vpisati je potrebno celo število (1, 5, 32,...");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Znižati želim (1) EN IZDELEK ali (2) VSE IZDELKE");
                    int izbiraPopusta = 0;
                    while (true)
                    {
                        try
                        {
                            izbiraPopusta = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Vpisati je potrebno število 1 ali 2");
                        }
                    }

                    switch (izbiraPopusta)
                    {
                        case 1:
                            string id = string.Empty;
                            Console.Write("Vpišite id izdelka ki ga želite znižati: ");
                            Console.WriteLine();
                            while (true)
                            {
                                try
                                {
                                    id = Console.ReadLine();
                                    break;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Vpisati je potrebno identifikator ki se začne s črko ali znakom _");
                                    Console.WriteLine();
                                }
                            }
                            bool obstaja = false;
                            foreach (var en in ListArtikli)
                            {

                                if (en.Id == id)
                                {
                                    double prvotna = en.Cena;
                                    en.Cena = prvotna - (prvotna * (popust / 100.0));
                                    obstaja = true;
                                    break;
                                }
                            }
                            if (obstaja)
                            {
                                SerializirajArtikleVDatoteko(ListArtikli, @"C:\FERI\RIS\strukturirani\ZnizaniArtikli.xml");
                                Console.WriteLine("Znižan artikel uspešno zabeležen.");
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Artikel s vpisanim id v naši bazi ne obstaja.");
                            break;
                        case 2:

                            foreach (var en in ListArtikli)
                            {
                                double prvotna = en.Cena;
                                en.Cena = prvotna - (prvotna * (popust / 100.0));
                            }
                            SerializirajArtikleVDatoteko(ListArtikli, @"C:\FERI\RIS\strukturirani\ZnizaniArtikli.xml");
                            Console.WriteLine("Znižani artikli so uspešno zapisani v datoteko.");
                            Console.WriteLine();

                            break;
                    }

                    break;
            }

            break;
        case 2:
            stevilo = false;
            while (!stevilo)
            {
                Console.WriteLine("Izberite številko operacije:\n 1-Vpis dobavitelja \n 2-Branje dobaviteljev");
                Console.WriteLine();
                try
                {
                    izbira2 = int.Parse(Console.ReadLine());
                    stevilo = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Vpisati je potrebno število 1 ali 2.");
                }
            }
            switch (izbira2)
            {
                case 1:
                    Dobavitelj nov = new Dobavitelj();
                    Console.WriteLine();
                    Console.Write("Vpišite id dobavitelja: ");
                    while (true)
                    {
                        try
                        {
                            nov.Id = Console.ReadLine();
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Vpisati je potrebno identifikator ki se začne s črko ali znakom _");
                        }
                    }

                    Console.WriteLine();
                    Console.Write("Vpišite naziv dobavitelja: ");
                    nov.Naziv = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Vpišite naslov dobavitelja: ");
                    nov.Naslov = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Vpišite davčno številko dobavitelja: ");
                    nov.Davcna = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Vpišite kontaktne podatke dobavitelja: ");
                    nov.Kontakt = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Vpišite opis dobavitelja: ");
                    nov.Opis = Console.ReadLine();

                    ListDobavitelji.Add(nov);

                    //Najprej zapišemo v testno datoteko,
                    SerializirajDobaviteljeVDatoteko(ListDobavitelji, @"C:\FERI\RIS\strukturirani\TESTDefaultDobavitelji.xml");

                    //Jo validiramo in v primeru uspeha zapišemo v default datoteko
                    ValidacijaDokumenta(@"C:\FERI\RIS\strukturirani\TESTDefaultDobavitelji.xml");
                    if (Helper.valid)
                    {
                        Console.WriteLine("Document is valid");
                        SerializirajDobaviteljeVDatoteko(ListDobavitelji, @"C:\FERI\RIS\strukturirani\DefaultDobavitelji.xml");
                        Console.WriteLine();
                        Console.WriteLine("Nov dobavitelj uspešno dodan na seznam.");
                    }
                    else
                    {
                        Console.WriteLine("Document is NOT valid");
                        Console.WriteLine();
                        ListDobavitelji.Remove(nov);
                        Console.WriteLine("Nov dobavitelj ni bil dodan na seznam.");
                        Helper.valid = true;
                    }

                    break;
                case 2:
                    DeserializacijaDobaviteljevVList(ref ListDobavitelji, @"C:\FERI\RIS\strukturirani\DefaultDobavitelji.xml");
                    foreach (var en in ListDobavitelji)
                    {
                        Console.WriteLine(en.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
            }

            break;
    }
}

