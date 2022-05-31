using Books.API;
using Serilog;
using System.Text.Json;

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Seq(serverUrl: "http://host.docker.internal:5341")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/books", async (string isbn) =>
{
    Log.Information($"API received '{isbn}'.");
    var apiHandler = new APIHandler();

    if (ISBN.TryParse(isbn, out var validisbn))
    {
        var (resultCode, json) = await apiHandler.GetBookByISBN(isbn);
        if((resultCode != System.Net.HttpStatusCode.OK) && (!string.IsNullOrEmpty(json)))
        {
            return Results.StatusCode((int)resultCode); 
        } else
        {
            var book = JsonSerializer.Deserialize<Book>(json);

            var value = new KeyValuePair<string, Book>(isbn, book);

            // put results in the queue
            QueueManager.Enqueue(data: value);

            return Results.Ok(book);
        }
    }
    else
    {
        return Results.BadRequest("Bad ISBN.");
    }
})
.WithName("GetBooks")
.Produces(200)
.Produces(404)
.Produces(400);

app.Run();
