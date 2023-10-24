--drop database nosted_app;
create database if not exists nosted_app;
use nosted_app;
CREATE TABLE IF NOT EXISTS serviceordre (
        Id INT PRIMARY KEY AUTO_INCREMENT, 
        Serienummer VARCHAR(50),
        Fornavn VARCHAR(255),
        Etternavn VARCHAR(20),
        Mobil VARCHAR(255),
        Email VARCHAR(255),
        Addresse VARCHAR(255),
        Feil_beskrivelse TEXT,
        Bestillingsnummer VARCHAR(255),
        Produkttype VARCHAR(255),
        Dato DATE,
        Aarsmodell INT,
        Garanti BOOLEAN,
        Service BOOLEAN,
        Reparasjon BOOLEAN,
        Kunde_kommentar TEXT
);


/*create table if not EXISTS AspNetRoles
(
    Id varchar(255) not null,
    Name varchar(255),
    NormalizedName  varchar(255),
    ConcurrencyStamp  varchar(255),
    CONSTRAINT U_ROLE_ID_PK PRIMARY KEY (Id)
);
*/