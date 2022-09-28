namespace Hospital;

public struct Location
{
    public string? city;
    public string? region;
    public string? State { get; set; }


    public Location(string? city, string? region, string? state)
    {
        this.city = city;
        this.region = region;
        State = state;
    }

    public override string ToString()
    {
        return @$"City {city},
region {region},
state {State}";
    }
}

