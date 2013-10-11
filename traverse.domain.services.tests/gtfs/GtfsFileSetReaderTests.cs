﻿using System;
using System.Linq;
using CsvHelper;
using NUnit.Framework;
using traverse.domain.services.gtfs;
using traverse.domain.services.io;
using traverse.gtfs.models;

namespace traverse.domain.services.tests.gtfs
{
    [TestFixture]
    public class GtfsFileSetReaderTests
    {
        [Test]
        public void When_reading_a_zip_file_then_all_files_are_read()
        {
            // Arrange
            var zipFilePath = @"C:\Users\Administrator\Downloads\GTFS.zip";

            var reader = new GtfsFileSetReader(new FileSystem(), new CsvFactory());

            // Act
            var result = reader.Read(zipFilePath);

            // Assert
            Assert.That(result.Agencies,Is.Not.Empty);
            Assert.That(result.Calendars,Is.Not.Empty);
            Assert.That(result.CalendarDates,Is.Not.Empty);
            Assert.That(result.CalendarDates.Select(d => (int)d.ExceptionType).Distinct(), Is.EquivalentTo(new[] { 1, 2 }));
        }
    }
}