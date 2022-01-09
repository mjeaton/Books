namespace Books.API;

public class Book
{
    public string[] publishers { get; set; }
    public Table_Of_Contents[] table_of_contents { get; set; }
    public Link[] links { get; set; }
    public string full_title { get; set; }
    public string[] lc_classifications { get; set; }
    public int latest_revision { get; set; }
    public string key { get; set; }
    public Author[] authors { get; set; }
    public string[] publish_places { get; set; }
    public string edition_name { get; set; }
    public string pagination { get; set; }
    public string[] source_records { get; set; }
    public string title { get; set; }
    public string[] lccn { get; set; }
    public Notes notes { get; set; }
    public int number_of_pages { get; set; }
    public string[] isbn_13 { get; set; }
    public Created created { get; set; }
    public Language[] languages { get; set; }
    public string[] subject_places { get; set; }
    public string[] subjects { get; set; }
    public string publish_date { get; set; }
    public string publish_country { get; set; }
    public Last_Modified last_modified { get; set; }
    public Work[] works { get; set; }
    public Type type { get; set; }
    public int revision { get; set; }
}

public class Notes
{
    public string type { get; set; }
    public string value { get; set; }
}

public class Created
{
    public string type { get; set; }
    public DateTime value { get; set; }
}

public class Last_Modified
{
    public string type { get; set; }
    public DateTime value { get; set; }
}

public class Type
{
    public string key { get; set; }
}

public class Table_Of_Contents
{
    public int level { get; set; }
    public string label { get; set; }
    public string title { get; set; }
    public string pagenum { get; set; }
}

public class Link
{
    public string url { get; set; }
    public string title { get; set; }
}

public class Language
{
    public string key { get; set; }
}

public class Work
{
    public string key { get; set; }
}

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

