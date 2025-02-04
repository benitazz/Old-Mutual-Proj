public class Country
{
    public Name name { get; set; }
    public Flags flags { get; set; }

}

public class Name
{
    public string common { get; set; }
}

public class Flags
{
    public string png { get; set; }
}