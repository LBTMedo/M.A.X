using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Vprasanje
{
    public string vprasanje;

    public int indeks;

    public int vrednost;

    public List<Odgovor> odgovori = new List<Odgovor>();
}

public class Odgovor
{
    public string odgovor;

    public bool pravilnost;
}
