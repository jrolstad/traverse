using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using NUnit.Framework;
using traverse.domain.services.io;
using traverse.domain.services.orca;
using traverse.orca.models;

namespace traverse.domain.services.tests.orca
{
    [TestFixture]
    public class OrcaFileReaderTests
    {
        private List<OrcaTransaction> _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            // Arrange
            var zipFile = GetSampleTransactionFile();

            var reader = new OrcaFileReader(new FileSystem(), new CsvFactory());

            // Act
            _result = reader.Read(zipFile);
        }


        [Test]
        public void Then_each_transaction_is_read()
        {
            // Assert
            Assert.That(_result.Count,Is.EqualTo(1163));
        }

        [Test]
        public void Then_the_dates_are_read()
        {
            // Assert
            Assert.IsTrue(_result.All(r=>r.Date>DateTime.MinValue));
        }

        [Test]
        public void Then_the_item_is_read()
        {
            // Assert
            Assert.IsTrue(_result.All(r => !string.IsNullOrWhiteSpace(r.Item)));
        }

        [Test]
        public void Then_the_location_is_read()
        {
            // Assert
            Assert.IsTrue(_result.All(r => !string.IsNullOrWhiteSpace(r.Location)));
        }

        [Test]
        public void Then_the_product_is_read()
        {
            // Assert
            Assert.IsTrue(_result.All(r => !string.IsNullOrWhiteSpace(r.Product)));
        }


        private Stream GetSampleTransactionFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "traverse.domain.services.tests.resources.orca_transactions.txt";

            var stream = assembly.GetManifestResourceStream(resourceName);

            return stream;
        }

    }
}