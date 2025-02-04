public class CountryDetails
{
    public Name name { get; set; }
    public Flags flags { get; set; }
    public int population { get; set; }
    public List<string> capital { get; set; }

    public string CommonName => name?.common;
    public string FlagUrl => flags?.png;
    public string CapitalCity => capital?.FirstOrDefault();
}