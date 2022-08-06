namespace WorldData.Dto;

public class CountryModel
{
  public int id { get; set; }
  public string? name { get; set; }
  public string? iso3 { get; set; }
  public string? iso2 { get; set; }
  public string? numeric_code { get; set; }
  public string? phone_code { get; set; }
  public string? capital { get; set; }
  public string? currency { get; set; }
  public string? currency_name { get; set; }
  public string? currency_symbol { get; set; }
  public string? tld { get; set; }
  public string? native { get; set; }
  public string? region { get; set; }
  public string? subregion { get; set; }
  public string? timezones { get; set; }
  public string? latitude { get; set; }
  public string? longitude { get; set; }
  public string? emoji { get; set; }
  public string? emojiU { get; set; }
}
