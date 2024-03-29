# Nosted
Nosted is a webapplication project in ASP.NET for handling service orders internally at [Nøsted &](https://www.nosted.com/) - [Igland](https://www.nosted.com/igland), for [UiA BACIT](https://www.uia.no/studieplaner/programme/BACIT) Fall 2023 by Group 1/ Gruppe 1.

# Notice
Please read and understand how the dockerfile works. Understand that all scripts used (build.* & startDb.*) can be run in the terminal without the scripts. We recommend getting familiar with executing docker commands in the terminal before using the scripts.

## How to use
### Prerequisites:
To make this work, you need to have [Docker](https://www.docker.com/) installed and running on your system.    

### Via commandline with docker (Recommended):

#### 1. Build then start the docker container with the web application:    
```C#
docker image build -t webapp    
docker container run --rm -it -d --name webapp --publish 80:80 webapp
```
#### 2. Start a mariadb container using the localdirectory "database" to store the data:    
##### Powershell (Windows)
```C#
docker run --rm --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11
```

#### 3. Enter the database and create the database and table for this skeleton:    
```C#
docker exec -it mariadb mysql -p
```
When prompted enter the password (`12345`), then type or copy in the SQL from [this file](CreateDb.sql) (line by line).

#### 4. Test out the code at http://localhost:80/

### Via scripts:
The following takes the above steps and deduce them into scripts. (all the above commands are present in the below scripts).
The scripts allow us to build and deploy our application faster, which can be beneficial when the core concepts of using docker are understood.

##### Powershell (Windows)
* Run `build.cmd` to compile source code and build tomcat docker image.
* Run `startDb.cmd` to start database

## Contribution
Pull requests are welcome. For major changes, please do NOT open an issue first to discuss what you would like to change.
This project, like most university semester projects, will likely be abondoned in near future. 

Code can be copied freely. Have fun and experiment :-)

## Developers - Group 1/Gruppe 1: 
* Shekina Lokoto [github.com/Shekina22](https://github.com/Shekina22)
* Arman Mangal [github.com/arman7203](https://github.com/arman7203)
* Jaime Segundo Oyarzun Montanares [github.com/jaimemontanares](https://github.com/jaimemontanares)
* Sander Javier Nomedal [github.com/sanderjn1](https://github.com/sanderjn1)
* Majd Monther Dawood Saleh [github.com/Masa-44/](https://github.com/Masa-44/)
* Ruben Teikari [github.com/Mordadin](https://github.com/Mordadin)

# Nøsted & forenklet kodeguide. 

## Oppbygning:

### wwwroot:
wwwroot-mappen er en spesiell mappe som spiller en betydelig rolle i å servere statiske filer, som HTML, CSS, JavaScript, bilder og andre klient-sideressurser til webklienter (nettlesere).

#### Actual eksempel:
### Site CSS fil 
Site.CSS inneholder oppbygningen av nettsidens layout og farger. Her finnes det blant annet Hover options som gjør at knapper på nettsiden lyser når musen kjøres over dem. Her bestemmes også høyden og bredden. Koden her definerer layouten og begrensningene på nettsiden. 
Her styles nettsiden gjennom blant annet Nav A (Legger til farge og style for links. Eksempel: endre av farge når musa beveger seg over linken) og Nav A hover (Endrer fargen av linken til hvit når musa beveger seg over den. 

### Controllers:
Ansvar for interaksjoner mellom objekter. Med andre ord, metoder. Metodene bestemmer hvordan et objekt skal oppføre seg, eller lage et mønster. Her kontrolleres flyten på nettsiden. Eksempel, her bestemmer du koden som gjør at en knapp fører deg fra et sted til et annet. Sjekkliste → Sjekkliste siden. 
#### Actual eksempel:
```
public IActionResult NyServiceOrdre()
{
    return View();
}
```
Denne koden benytter seg av IActionResult som setter i gang metoden “NyServiceOrdre()”  og “return View()” som returnerer en visning gjennom IActionResult. Med andre ord, metoden gjør det mulig å trykke på “NyServiceOrdre” knappen og sende brukeren videre til en ny side som viser (return View) en tabell med serviceordre. 

### Models:
Modelfilen definerer dataen og gir struktur. Her finner du klasser som ServiceOrdre samt strukturen på klassen. Modellene eksisterer for å gjøre koden lett å lese og dermed enkel å vedlikeholde. Denne koden lager felt som blant annet “fornavn” og “etternavn” som kan fylles inn og lagres/oppdateres av brukeren. 
#### Actual eksempel:
```
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
```
Denne koden har en struktur som lager instanser (objekter) der man kan legge inn informasjon som blant annet Email og Adresse. Den benytter seg av “get og set” metodene. “get” henter inn informasjonen som blir tastet inn i feltet som blant annet “E-mail, og “set” oppdaterer feltet. Dermed blir feltet E-mailen som har blitt tastet inn. 
Koden “public int Id { get; set; }” Lager et felt på nettsiden der man kan sette inn integars (heltall) gjennom “get” metoden, og lagre/oppdatere den gjennom “set” metoden. 

### Views: 
Ansvar for å vise hva som kommer opp på skjermen til brukeren. Her lages det templates gjennom HTML kode. Blant annet 
```
<head><head/>
<h1> (header)</h1>
<title>
```
Her finner du oppsettet av sidene du ser når du er inne på nettsiden. 

#### Actual eksempel:
```HTML
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
```
Koden viser en nettside med headeren “Wilkommen” på midten av siden og justerer den basert på skjermen som brukes av brukeren gjennom “ <meta name="viewport" content="width=device-width, initial-scale=1.0">”. 

## Oppsumering:

### wwwroot: 
Dette er stedet der tredjeparts biblioteker og pakker blir inkludert for å bygge rammeverket for koden. For eksempel, CSS-filer som styrer nettsidens utseende og oppførsel. Det kan inkludere stilregler som definerer layout og farger, samt spesielle effekter som hover-effekter for knapper. wwwroot-mappen spiller en betydelig rolle i å servere statiske filer, som HTML, CSS, JavaScript, bilder, og andre klient-sideressurser til webklienter (nettlesere). Den brukes til å lagre offentlige eller offentlig tilgjengelige filer som er tilgjengelige for offentligheten via URL-er.
Dette er hvordan wwwroot-mappen bidrar til webutviklingsprosjektet, spesielt når det gjelder klient-sideressurser og presentasjon av nettstedets innhold og utseende.

### Controllers: 
Dette er hvor du definerer interaksjonene mellom objekter, vanligvis i form av metoder. Controller-metodene styrer hvordan nettsiden fungerer, for eksempel ved å bestemme hvordan knapper fører til forskjellige deler av nettsiden.

### Models: 
Modellene gir strukturen for dataen som skal behandles i applikasjonen. De inneholder klasser som definerer datafeltene, som fornavn, etternavn, e-postadresse osv. Modellene gjør koden mer lesbar og organisert ved å representere dataen.

### Views: 
Views er ansvarlige for å vise innholdet på skjermen for brukeren. Dette er HTML-templater som bestemmer hvordan sidene ser ut. 
De inneholder elementer som for eksempel: 
##### Overskrifter:
```HTML
<h1> </h1> 
```
##### Tittelen på siden:
```HTML
<title> </title> 
```
##### og formateringsregler som styrer layout og utseende:
```HTML
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
```

#### Hver av disse delene i koden (Lib Filen, Controllers, Models, og Views) har spesifikke oppgaver og ansvar i en webapplikasjon. Dette er en nyttig guide for å forstå hvordan koden er organisert og hvordan den fungerer sammen for å bygge en fullverdig nettside.

# Acknowledgements
## Some Text provided by: 
* Trym [https://github.com/Nosp1](https://github.com/Nosp1)
* Espen [https://github.com/espenlimi](https://github.com/espenlimi)
* Danny Guo [https://github.com/dguo](https://github.com/dguo) through [makeareadme.com/](https://www.makeareadme.com/)
* OpenAI [ChatGTP](https://chat.openai.com/)

## Some Code provided by:
* Digital TechJoint [ASP.NET Identity - User Registration, Login and Log-out] ([placeholder.link](https://youtu.be/ghzvSROMo_M?si=DQTld956iFbFOENL))
* Digital TechJoint [ASP.NET MVC - How To Implement Role Based Authorization] ([placeholder.link](https://youtu.be/qvsWwwq2ynE?si=KOt6TilFO4BmNl1F))

### Text and code modified slightly to fit this project. 
