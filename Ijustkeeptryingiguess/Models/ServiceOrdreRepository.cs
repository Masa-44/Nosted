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

        public ServiceOrdreRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get { return new MySqlConnection(_config.GetConnectionString("DefaultConnection")); }
        }

        public IEnumerable<ServiceOrdre> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<ServiceOrdre>("SELECT * FROM serviceordre");
            }
        }

        public void Insert(ServiceOrdre serviceordre)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(
                    @"INSERT INTO serviceordre (id, serienummer, fornavn, etternavn, mobil, email, addresse, feil_beskrivelse, bestillingsnummer, produkttype, dato, aarsmodell, Garanti, Service, Reparasjon, kunde_kommentar)
                VALUES (@id, @serienummer, @fornavn, @etternavn, @mobil, @email, @addresse, @feil_beskrivelse, @bestillingsnummer, @produkttype, @dato, @aarsmodell, @Garanti, @Service, @Reparasjon, @kunde_kommentar)");
            }
        }
    }
}