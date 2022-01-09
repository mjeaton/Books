using Serilog;

Log.Information("Running Books.Console");

SetupLogger();

if(args.Length == 0)
{
	bool exit = false;
	PrintUsage();
	while(!exit)
    {
		HandleInput();
    }
	Log.CloseAndFlush();
	Log.Information("Done");
}

static void HandleInput()
{
	var input = Console.ReadLine();
	switch(input.ToLower())
    {
		case "x":
			Environment.Exit(0);
			break;
		case "h":
			PrintUsage();
			break;
		default:
			Console.WriteLine($"You entered {input}");
			break;
    }
}

static void PrintUsage()
{
	Console.WriteLine("");
	Console.WriteLine("----- Books.Console -----");
    Console.WriteLine("");
    Console.WriteLine("Enter an ISBN (or X to quit).");
    Console.WriteLine("Enter H to see this information.");
    Console.WriteLine("");
}

static void SetupLogger()
{
Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.Seq(serverUrl: "http://seq:5341")
	.CreateLogger();
}
