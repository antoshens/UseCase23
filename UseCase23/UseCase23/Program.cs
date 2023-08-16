using Bogus;
using Bogus.DataSets;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using UseCase23.Models;
using UseCase23.Extensions;

// Generate Titles data
const int NumberOfRecords = 200;

var lorem = new Lorem("en_US");
var name = new Name("en_US");

var titleIds = 1;
var testTitlesData = new Faker<TitleRecord>()
    .StrictMode(false)
    .RuleFor(t => t.Id, f => titleIds++)
    .RuleFor(t => t.Certification, f => f.PickRandom<Certification>().GetDescription())
    .RuleFor(t => t.ReleaseYear, f => f.Random.Int(-1, 2100))
    .RuleFor(t => t.Runtime, f => f.Random.Int(-1, 1000))
    .RuleFor(t => t.Seasons, f => f.Random.Int(-1, 50))
    .RuleFor(t => t.Title, f => lorem.Sentence())
    .RuleFor(t => t.Description, f => lorem.Sentences())
    .RuleFor(t => t.Genres, f => lorem.Words(5).ToList())
    .RuleFor(t => t.Country, f => f.Address.CountryCode(Iso3166Format.Alpha3));

// Generate Credits data
var creditIds = 1;
var testCreditsData = new Faker<Credit>()
    .StrictMode(false)
    .RuleFor(t => t.Id, f => creditIds++)
    .RuleFor(t => t.TitleId, f => f.Random.Int(1, NumberOfRecords))
    .RuleFor(t => t.Role, f => f.PickRandom<Role>().GetDescription())
    .RuleFor(t => t.RealName, f => name.FullName())
    .RuleFor(t => t.CharacterName, f => name.FullName());

var titles = testTitlesData.Generate(NumberOfRecords);
var credits = testCreditsData.Generate(NumberOfRecords);

// Save Titles data
var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    ShouldQuote = args => true,
};

using (var writer = new StreamWriter(@".\Titles.csv", false, Encoding.UTF8))
using (var csv = new CsvWriter(writer, config))
{
    csv.Context.RegisterClassMap<TitleMap>();
    csv.WriteRecords(titles);
    writer.Flush();
}

// Save Credits data
using (var writer = new StreamWriter(@".\Credits.csv", false, Encoding.UTF8))
using (var csv = new CsvWriter(writer, config))
{
    csv.WriteRecords(credits);
    writer.Flush();
}
