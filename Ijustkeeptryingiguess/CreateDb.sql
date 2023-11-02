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

CREATE OR REPLACE TABLE mekanisk(
    mek_id SMALLINT AUTO_INCREMENT PRIMARY KEY,
    c_lameller_slitasje VARCHAR(20),
    bremser_band_p VARCHAR(20),
    lager_trommel VARCHAR(20),
     pto_opplagring VARCHAR(20),
     kjedestrammer VARCHAR(20),
     wire VARCHAR(20),
     pinion_lager VARCHAR(20),
     kile_kjedehjul VARCHAR(20)
);

CREATE OR REPLACE TABLE hydraulisk(
    hyd_id SMALLINT AUTO_INCREMENT PRIMARY KEY,
    hydraulisk_syl_lek VARCHAR(20),
    slanger_skader_lek VARCHAR(20),
    t_hyd_testbenk VARCHAR(20),
     skift_olje_tank VARCHAR(20),
     skift_olje_girboks VARCHAR(20),
     ring_open_skift_t VARCHAR(20),
     bremse_syl_open_skift VARCHAR(20)
);

CREATE OR REPLACE TABLE elektro(
    elektro_id SMALLINT AUTO_INCREMENT PRIMARY KEY,
    led_nett_vinsj VARCHAR(20),
    sjekk_t_radio VARCHAR(20),
    sjekk_t_knappekasser VARCHAR(20)

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