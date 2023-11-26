using Ijustkeeptryingiguess.Controllers;
using Ijustkeeptryingiguess.Data;
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class LeadsControllerTests
    {
        [Test]
        public async Task Index_ReturnsListOfSalesLeadObjects()
        {
            // Arrange

            // Opprett alternativer for en minnebasert database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Bruk en separat databasekontekst for testing
            using (var context = new ApplicationDbContext(options))
            {
                // Legg til noen testobjekter av typen SalesLead i den minnebaserte databasen
                context.SalesLead.AddRange(new List<SalesLeadEntity>
                {
                    new SalesLeadEntity { Id = 1, FirstName = "John", LastName = "Doe", Mobile = "123456789", Email = "john.doe@example.com", Source = "TestSource" },
                    new SalesLeadEntity { Id = 2, FirstName = "Jane", LastName = "Doe", Mobile = "987654321", Email = "jane.doe@example.com", Source = "TestSource" }
                });

                // Lagre endringene i den minnebaserte databasen
                context.SaveChanges();
            }

            // Act

            // Opprett en instans av LeadsController med kontekst for den minnebaserte databasen
            using (var context = new ApplicationDbContext(options))
            {
                var controller = new LeadsController(context);

                // Kall på metoden Index asynkront og fang resultatet
                var result = await controller.Index();

                // Assert

                // Verifiser at resultatet er en instans av ViewResult
                Assert.That(result, Is.InstanceOf<ViewResult>());

                // Hent modellen fra ViewResult og verifiser at den er en liste av SalesLeadEntity
                var viewResult = result as ViewResult;
                Assert.That(viewResult.Model, Is.InstanceOf<List<SalesLeadEntity>>());

                // Hent listen av SalesLeadEntity fra modellen og verifiser antallet
                var model = viewResult.Model as List<SalesLeadEntity>;
                Assert.That(model.Count, Is.EqualTo(2)); // Juster antallet basert på antallet testobjekter du la til
            }
        }
    }
}
