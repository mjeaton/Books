namespace Books.API.Models;

public class Author
{
    public string name { get; set; }
    public string personal_name { get; set; }
    public Last_Modified last_modified { get; set; }
    public string key { get; set; }
    public Type type { get; set; }
    public int id { get; set; }
    public int revision { get; set; }
}

