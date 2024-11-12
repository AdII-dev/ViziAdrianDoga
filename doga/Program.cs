using doga;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Dolgozat_11._12;
class Program
{
    const string FILE_PATH = @"..\..\..\src\varosok.csv";

    static void Main()
    {
        List<Varos> varosok = new();

        using StreamReader sr = new(FILE_PATH, Encoding.UTF8);
        sr.ReadLine(); 
        while (!sr.EndOfStream)
        {
            varosok.Add(new Varos(sr.ReadLine()));
        }

        Console.WriteLine($"kollekcio hossza: {varosok.Count}");

        Console.WriteLine("1");
        var osszNepessegKina = varosok
            .Where(v => v.Orszag == "Kína")
            .Sum(v => v.Nepesseg);
        Console.WriteLine($"Kínai nagyvarosok ossznepessege: {osszNepessegKina:F2} millio fo");


        Console.WriteLine("2");
        var atlagNepessegIndia = varosok
            .Where(v => v.Orszag == "India")
            .Average(v => v.Nepesseg);
        Console.WriteLine($"Indiai nagyvárosok átlaglélekszáma: {atlagNepessegIndia:F2} millio fo");


        Console.WriteLine("3");
        var legnepesebbVaros = varosok.MaxBy(v => v.Nepesseg);
        Console.WriteLine($"Legnepesebb nagyvaros: {legnepesebbVaros}");

        Console.WriteLine("4");
        var nagyV20M = varosok
            .Where(v => v.Nepesseg > 20)
            .OrderByDescending(v => v.Nepesseg)
            .ToList();
        Console.WriteLine("20 millio fo feletti nagyvarosok nepesseg szerint csokkeno sorrendben:");
        nagyV20M.ForEach(v => Console.WriteLine($"\t{v}"));


        Console.WriteLine("5");
        var orszTobbVa = varosok
            .GroupBy(v => v.Orszag)
            .Count(g => g.Count() > 1);
        Console.WriteLine($"Orszagok, amik tobb nagyvarossal szerepelnek: {orszTobbVa} db");


        Console.WriteLine("6");
        var legGyakKeB = varosok
            .GroupBy(v => v.VarosNev[0])
            .OrderByDescending(g => g.Count())
            .First().Key;
        Console.WriteLine($"Leggyakoribb kezdobetu a nagyvarosok neveiben: {legGyakKeB}");
    }
}