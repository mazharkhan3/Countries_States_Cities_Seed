using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WorldData.Dto;
using WorldData.Models;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  builder.Services.AddDbContext<CoreDbContext>(op =>
  {
    op.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
  });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/seed_countries", () =>
{
  // READ CSV DATA
  List<CountryModel> countries = new();
  using (var reader = new StreamReader("./Data/countries.csv"))
  using (CsvReader? csv = new(reader, CultureInfo.InvariantCulture))
  {
    countries = csv.GetRecords<CountryModel>().ToList();
  }

  var db = new CoreDbContext();
  var countryList = new List<Country>();
  foreach (var country in countries)
  {
    countryList.Add(new Country
    {
      CountryId = country.id,
      Name = country.name,
      CountryCode = country.iso2
    });
  }

  db.Countries.AddRange(countryList);
  db.SaveChanges();

  return "Countries Seeded";
})
.WithName("seed_countries");

app.MapGet("/seed_states", () =>
{
  List<StateModel> states = new();
  using (var reader = new StreamReader("./Data/states.csv"))
  using (CsvReader? csv = new(reader, CultureInfo.InvariantCulture))
  {
    states = csv.GetRecords<StateModel>().ToList();
  }

  var db = new CoreDbContext();
  var statesList = new List<State>();
  foreach (var state in states)
  {
    statesList.Add(new State
    {
      StateId = state.id,
      Name = state.name,
      CountryId = state.country_id
    });
  }

  db.States.AddRange(statesList);
  db.SaveChanges();

  return "States seeded";
})
.WithName("seed_states");

app.MapGet("/seed_cities", () =>
{
  List<CityModel> cities = new();
  using (var reader = new StreamReader("./Data/cities.csv"))
  using (CsvReader? csv = new(reader, CultureInfo.InvariantCulture))
  {
    cities = csv.GetRecords<CityModel>().ToList();
  }

  var db = new CoreDbContext();
  var cityList = new List<City>();
  foreach (var city in cities)
  {
    cityList.Add(new City
    {
      CityId = city.id,
      Name = city.name,
      StateId = city.state_id
    });
  }

  db.Cities.AddRange(cityList);
  db.SaveChanges();

  return "Cities seeded";
})
.WithName("seed_cities");



app.Run();