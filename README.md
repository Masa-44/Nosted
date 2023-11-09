Nøsted & forenklet kodeguide. 

Oppbygning:

Lib:
inneholder tredjeparti pakker eller biblioteker som Java, CSS. Her bygges rammeverket for koden. Et eksempel på Lib er CSS filen som er med på å forme nettsiden som blant annet bakgrunnshøyde/bredde, farger og stil. En layout. 
Actual eksempel:
Site CSS fil 
Site.CSS inneholder oppbygningen av nettsidens layout og farger. Her finnes det blant annet Hover options som gjør at knapper på nettsiden lyser når musen kjøres over dem. Her bestemmes også høyden og bredden. Koden her definerer layouten og begrensningene på nettsiden. 
Her styles nettsiden gjennom blant annet Nav A (Legger til farge og style for links. Eksempel: endre av farge når musa beveger seg over linken) og Nav A hover (Endrer fargen av linken til hvit når musa beveger seg over den. 

Controllers:
Ansvar for interaksjoner mellom objekter. Med andre ord, metoder. Metodene bestemmer hvordan et objekt skal oppføre seg, eller lage et mønster. Her kontrolleres flyten på nettsiden. Eksempel, her bestemmer du koden som gjør at en knapp fører deg fra et sted til et annet. Sjekkliste → Sjekkliste siden. 
           Actual eksempel:
public IActionResult NyServiceOrdre()
{
    return View();
}
Denne koden benytter seg av IActionResult som setter i gang metoden “NyServiceOrdre()”  og “return View()” som returnerer en visning gjennom IActionResult. Med andre ord, metoden gjør det mulig å trykke på “NyServiceOrdre” knappen og sende brukeren videre til en ny side som viser (return View) en tabell med serviceordre. 


Models:
Modelfilen definerer dataen og gir struktur. Her finner du klasser som ServiceOrdre samt strukturen på klassen. Modellene eksisterer for å gjøre koden lett å lese og dermed enkel å vedlikeholde. Denne koden lager felt som blant annet “fornavn” og “etternavn” som kan fylles inn og lagres/oppdateres av brukeren. 
Actual eksempel:
    public class ServiceOrdre
    {   
        public int Id { get; set; }
        public string? Serienummer { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        public string? Mobil { get; set; }
        public string? Email { get; set; }
        public string? Addresse { get; set; }
        public string? Feil_beskrivelse { get; set; }
        public string? Bestillingsnummer { get; set; }
        public string? Produkttype { get; set; }
        public DateTime? Dato { get; set; }
        public int? Aarsmodell { get; set; }
        public bool Garanti { get; set; }
        public bool Service { get; set; }
        public bool Reparasjon { get; set; }
        public string? Kunde_kommentar { get; set; }
    }
}
Denne koden har en struktur som lager instanser (objekter) der man kan legge inn informasjon som blant annet Email og Adresse. Den benytter seg av “get og set” metodene. “get” henter inn informasjonen som blir tastet inn i feltet som blant annet “E-mail, og “set” oppdaterer feltet. Dermed blir feltet E-mailen som har blitt tastet inn. 
Koden “public int Id { get; set; }” Lager et felt på nettsiden der man kan sette inn integars (heltall) gjennom “get” metoden, og lagre/oppdatere den gjennom “set” metoden. 

Views: 
Ansvar for å vise hva som kommer opp på skjermen til brukeren. Her lages det templates gjennom HTML kode. Blant annet 
<head><head/>
<h1> (header)
<title> 
Her finner du oppsettet av sidene du ser når du er inne på nettsiden. 
Actual eksempel:

 <html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        .header1 {
            display: flex;
            justify-content: center; /* horizontally center */
            align-items: center;     /* vertically center (if you want) */
        }
    
        .header1 h1 {
            color: red;
            text-align: center;      /* ensures the text itself is centered */
        }
    </style>
    
    
</head>
<body>
<div class="header1">
<h1>Willkommen</h1>
</div>
</body>
</html>


Koden viser en nettside med headeren “Wilkommen” på midten av siden og justerer den basert på skjermen som brukes av brukeren gjennom “ <meta name="viewport" content="width=device-width, initial-scale=1.0">”. 

Oppsumering:

Lib: Dette er stedet der tredjeparts biblioteker og pakker blir inkludert for å bygge rammeverket for koden. For eksempel, CSS-filer som styrer nettsidens utseende og oppførsel. Det kan inkludere stilregler som definerer layout og farger, samt spesielle effekter som hover-effekter for knapper.

Controllers: Dette er hvor du definerer interaksjonene mellom objekter, vanligvis i form av metoder. Controller-metodene styrer hvordan nettsiden fungerer, for eksempel ved å bestemme hvordan knapper fører til forskjellige deler av nettsiden.

Models: Modellene gir strukturen for dataen som skal behandles i applikasjonen. De inneholder klasser som definerer datafeltene, som fornavn, etternavn, e-postadresse osv. Modellene gjør koden mer lesbar og organisert ved å representere dataen.

Views: Views er ansvarlige for å vise innholdet på skjermen for brukeren. Dette er HTML-templater som bestemmer hvordan sidene ser ut. De inneholder elementer som overskrifter (<h1>), tittelen på siden (<title>), og formateringsregler som styrer layout og utseende.

Hver av disse delene i koden (Lib Filen, Controllers, Models, og Views) har spesifikke oppgaver og ansvar i en webapplikasjon. Dette er en nyttig guide for å forstå hvordan koden er organisert og hvordan den fungerer sammen for å bygge en fullverdig nettside.
