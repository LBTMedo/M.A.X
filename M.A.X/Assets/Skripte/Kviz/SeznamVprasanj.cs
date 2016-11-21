using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeznamVprasanj : MonoBehaviour {

    public static List<Vprasanje> vprasanja = new List<Vprasanje>();
    public static List<Odgovor> odgovori1 = new List<Odgovor>();

    public static List<string> izvlecki = new List<string>();

    public void Awake()
    {
        odgovori1.Add(new Odgovor
        {
            odgovor = "Več kot 1400 različnih.",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Enega samega.",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Okoli 20 različnih.",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Koliko različnih bogov so častili Egipčani?",
            indeks = 0,
            vrednost = 1,
        });
        vprasanja[0].odgovori.AddRange(odgovori1);
        izvlecki.Add("Antični Egipčani so častili več kot 1400 ražličnih bogov in boginj.");

        
        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "59.5m",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "108m",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "146.5m",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Koliko je bila ob izgradnji visoka ti. velika piramida v Gizi?",
            indeks = 1,
            vrednost = 1,
        });
        vprasanja[1].odgovori.AddRange(odgovori1);
        izvlecki.Add("Velika piramida v Gizi je najstarejša in največja od treh piramid v Gizi. Je Najstarejša izmed 7 čudes antičnega sveta. Gradili so jo okoli 10 do 20 let, zgrajena pa je bila okoli 2560 pred Kristusom. Ob izgradnji je bila visoka 146.5m.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "5",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "21",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "17",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Koliko let je Egiptu vladala Kleopatra?",
            indeks = 2,
            vrednost = 2,
        });
        vprasanja[2].odgovori.AddRange(odgovori1);
        izvlecki.Add("Kleopatra VII. je bila zadnji vladar iz makedonske dinastije Ptolemejcev in ss tem zadnji grški vladar Egipta. Na prestol se je povzpela leta 51 pr. n. št. kot sovladarica svojega moža in brata Ptolemeja XIII. Vladala je vse do svoje smrti leta 30 pr. n. št.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "11",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "27",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "31",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Na koliko dinastij lahko delimo kronološko zgodovino Starega Egipta?",
            indeks = 3,
            vrednost = 2,
        });
        vprasanja[3].odgovori.AddRange(odgovori1);
        izvlecki.Add("Kronološko zgodovino starega Egipta lahko delimo na dva načina: po dinastijah(31 dinastij) ter po razvoju. Glede na raznolikost naravnega okolja pa je bil Egipt razdeljen na tri dele: ozko dolino zgornje-egiptovskega Nila, široko delto ter zahodne in vzhodne puščavske dele z oazami.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Prav",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Narobe",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Pozno obdobje Starega Egipta je trajalo od leta 1069 pr.n.št. do leta 65 pr.n.št",
            indeks = 4,
            vrednost = 3,
        });
        vprasanja[4].odgovori.AddRange(odgovori1);
        izvlecki.Add("Leta 672 pr. n. št. se je v Starem Egiptu začelo ti. pozno obdobje, ki se trajalo do leta 332 pr. n. št.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Kmetje",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Sužnji",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Meščanstvo",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kateri družbeni sloj je bil v Starem Egiptu najštevilčnejši?",
            indeks = 5,
            vrednost = 3,
        });
        vprasanja[5].odgovori.AddRange(odgovori1);
        izvlecki.Add("Družba v Egiptu je bila močno razdeljena. Na vrhu družbe je bilo plemstvo na vrhu katerega je bil faraon kot najpremožnejši človek v vsej egipčanski državi, ki je bila njegova osebna last. Naslednji sloj so bili meščanstvo, ki pa je bilo v egiptu bolj šibko zastopano. Najštevilčnejši sloj so bili kmetje, ki so bili ločeni na male lastnike zemljišč, ki so bili samostojni a so morali plačevati davke, in odvisne kmete. Najslabši položaj so imeli sužnji, ki niso imeli svobode in zemlje. Zadnji sloj pa je bila vojska v kateri so služili vsi svobodni ljudje razen svečenikov.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Egipčanski bog vojne",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Vrhovni svečenik",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Zdravnik",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kdo je bil Imhotep?",
            indeks = 6,
            vrednost = 4,
        });
        vprasanja[6].odgovori.AddRange(odgovori1);
        izvlecki.Add("Za vsako bolezen so v starem Egipt mislili, da je nastala zaradi zlih duhov, ki so obsedli bolnika. Bolezen so določili zdravniki in povedali, katera zdravila mora bolnik jemati. Duhove so poskušali spraviti iz telesa s čarobnimi izreki in gibi. Verjetno najbolj znan zdravnik je bil Imhotep, ki je živel okoli 2880 pr. n. št. Ljudje so ga zaradi njegovih zdravilnih sposobnosti častili skoraj kot boga.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Prav",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Narobe",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "V antičnem Egiptu so poznali seštevanje, odštevanje, množenje in deljenje.",
            indeks = 7,
            vrednost = 4,
        });
        vprasanja[7].odgovori.AddRange(odgovori1);
        izvlecki.Add("Matematika se je začela razvijati zaradi potrebe po meritvi polj po vsakoletnih poplavah in določanja meja med sosednjimi območji. Poleg tega so jo uporabljali pri izgradnji palač oz. svetišč. Številke so pisali s posebnimi pismenkami, uvedli pa so desetinski sistem. Poznali so seštevanje, odštevanje, množenje in deljenje, poznali pa so tudi tablice množenja in deljenja.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Na količini vode v reki Nil",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Na sončevem letu",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Na dolžini dni",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Na čem so temeljili koledarji, ki so jih uporabljali Egipčani?",
            indeks = 8,
            vrednost = 4,
        });
        vprasanja[8].odgovori.AddRange(odgovori1);
        izvlecki.Add("Poznali so prve koledarje, ki so temeljili na Sončevem letu. Kmalu so začeli opazovati nebo, tako da se je razvila astrologija in posledično tudi prvi horoskopi. Pokazali so se tudi prvi zametki astronomije, saj so že znali izračunati Sončeve in Lunine mrke, poznali pa so tudi 5 planetov in 36 zvezd. Opazovalnice so imeli v svetiščih.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Življenska in duhovna energija.",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Božanski par.",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Prvi Egipčanski faraon in njegova žena.",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kdo oziroma kaj sta Ka in Ba?",
            indeks = 9,
            vrednost = 5,
        });
        vprasanja[9].odgovori.AddRange(odgovori1);
        izvlecki.Add("Stari Egipčani so verjeli v posmrtno življenje, saj so verovali, da je človek sestavljen iz telesa ter duše, poimenovane Ka (življenjska energija) ter Ba (duhovna energija). Po njihovem naj bi se Ka po smrti vrnila nazaj v telo, zato je bilo potrebno truplo po smrti ustrezno pripraviti z balzamirjanjem (mumificiranjem) in ga pokopati v grobnice, ki so bile poimenovane kot hiše za Ka.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Knjiga o posmrtnem življenju.",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Knjiga z imeni mrtvih faraonov.",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Zbirka himen, molitev in zakletev.",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kaj je Knjiga mrtvih?",
            indeks = 10,
            vrednost = 5,
        });
        vprasanja[10].odgovori.AddRange(odgovori1);
        izvlecki.Add("Za najbolj znano egipčansko književno delo se šteje Knjiga mrtvih, ki je zbirka himen, molitev in zakletev, za katere so menili, da bodo v pomoč mrtvim, tako da so jih zakopali skupaj z njimi.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Knjiga o posmrtnem življenju.",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Knjiga z imeni mrtvih faraonov.",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Zbirka himen, molitev in zakletev.",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kateremu bogu je pripadalo svetišče Karnak?",
            indeks = 11,
            vrednost = 6,
        });
        vprasanja[11].odgovori.AddRange(odgovori1);
        izvlecki.Add("Egipčani so znani po mojstrski spretnosti gradnje, saj so ustvarili eno od sedmih čudes sveta, piramide. Služile so kot grobnica faraonov v stari in srednji državi. Najbolj znana je Keopsova piramida pri Gizi, ki je visoka 137 m (prvotno 146.5 m). V novi državi so piramide zamenjali skalni grobovi, najbolj znani so iz Doline kraljev. Gradili so tudi svetišča svojim številnim bogovom. Najbolj znano svetišče je Karnak, ki je pripadalo bogu Amon-Raju.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Prav",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Narobe",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Piramide so gradili sužnji.",
            indeks = 12,
            vrednost = 6,
        });
        vprasanja[12].odgovori.AddRange(odgovori1);
        izvlecki.Add("Gradbena dela so opravljali kmetje, medtem ko niso delali na polju. Zanimivo je, da so piramide gradili svobodni delavci, ki so to delo počeli z veseljem. Gojili so namreč globoko vero v faraona, ki jim je s tem, da so pomagali graditi, obljubil odrešitev.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Ehnaton",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Menes",
            pravilnost = true
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Ramzes",
            pravilnost = false
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Kdo je bil prvi staroegipčanski kralj(faraon)?",
            indeks = 13,
            vrednost = 6,
        });
        vprasanja[13].odgovori.AddRange(odgovori1);
        izvlecki.Add("Menes je po tradiciji prvi staroegipčanski kralj (faraon), ki je okoli leta 3000 pr. n. št. združil spodnji in zgornji Egipt. ). Za prestolnico je določil mesto Memfis, državo pa je razdelil na 42 okrožij ali nomov, ki so jim vladali nomarhi.");

        odgovori1.Clear();
        odgovori1.Add(new Odgovor
        {
            odgovor = "Prav",
            pravilnost = false
        });
        odgovori1.Add(new Odgovor
        {
            odgovor = "Narobe",
            pravilnost = true
        });

        vprasanja.Add(new Vprasanje
        {
            vprasanje = "Novo kraljestvo je trajalo od leta 1549 pr. n. št. do leat 1069 pr. n. št.",
            indeks = 14,
            vrednost = 6,
        });
        vprasanja[14].odgovori.AddRange(odgovori1);
        izvlecki.Add("Obdobje imenovano 'Novo Kraljestvo' je trajalo od leta 1549 pr. n. št. do leat 1069 pr. n. št.");
    }
}
