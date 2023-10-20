--drop database nosted_app;
create database if not exists nosted_app;
use nosted_app;
CREATE TABLE IF NOT EXISTS serviceordre (
 serienummer VARCHAR(50) PRIMARY KEY,
        fornavn VARCHAR(255),
        etternavn VARCHAR(20),
        mobil VARCHAR(255),
        email VARCHAR(255),
        addresse VARCHAR(255),
        feil_beskrivelse TEXT,
        bestillingsnummer VARCHAR(255),
        produkttype VARCHAR(255),
        dato DATE,
        aarsmodell INT,
        Garanti BOOLEAN,
        Service BOOLEAN,
        Reparasjon BOOLEAN,
        kunde_kommentar TEXT
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