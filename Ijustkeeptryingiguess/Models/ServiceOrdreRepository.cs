// ServiceOrdreRepository er et repository som håndterer databasen interaksjonene for ServiceOrdre-objekter.

using Dapper;
using Ijustkeeptryingiguess.Models;
using Microsoft.Extensions.Configuration;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ijustkeeptryingiguess.Models
{
    public class ServiceOrdreRepository
    {
        private readonly IConfiguration _config;

        // Konstruktør som tar inn IConfiguration-innstillingene for å koble til databasen.
        public ServiceOrdreRepository(IConfiguration config)
        {
            _config = config;
        }

        // Egenskap som gir en IDbConnection tilkobling til databasen basert på konfigurasjonsinnstillingene.
        public IDbConnection Connection
        {
            get { return new MySqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        // Metode som henter alle serviceordre fra databasen.
        public IEnumerable<ServiceOrdre> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                // Bruker Dapper til å utføre en SQL-spørring og returnere en liste av ServiceOrdre-objekter.
                return dbConnection.Query<ServiceOrdre>("SELECT * FROM serviceordre");
            }
        }

        // Metode som legger til en ny serviceordre i databasen.
        public void Insert(ServiceOrdre serviceordre)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                // Bruker Dapper til å utføre en SQL INSERT-spørring basert på egenskapene til serviceordre-objektet.
                dbConnection.Execute(
                    @"
                    INSERT INTO serviceordre (
                                     Serienummer,
                                     Fornavn,
                                     Etternavn,
                                     Mobil,
                                     Email,
                                     Addresse,
                                     Feil_beskrivelse,
                                     Bestillingsnummer,
                                     Produkttype,
                                     Dato,
                                     Aarsmodell,
                                     Garanti,
                                     Service,
                                     Reparasjon,
                                     Kunde_kommentar
                                 )
                                 VALUES (
                                     @Serienummer,
                                     @Fornavn,
                                     @Etternavn,
                                     @Mobil,
                                     @Email,
                                     @Addresse,
                                     @Feil_beskrivelse,
                                     @Bestillingsnummer,
                                     @Produkttype,
                                     @Dato,
                                     @Aarsmodell,
                                     @Garanti,
                                     @Service,
                                     @Reparasjon,
                                     @Kunde_kommentar
                                 )
                    ",
                    serviceordre);
            }
        }
    }
}
