using System.IO;

static string HR(long b) =>
    b switch
    {
        >= 1L << 40 => $"{b / (double)(1L << 40):0.##} TB",
        >= 1L << 30 => $"{b / (double)(1L << 30):0.##} GB",
        >= 1L << 20 => $"{b / (double)(1L << 20):0.##} MB",
        >= 1L << 10 => $"{b / (double)(1L << 10):0.##} KB",
        _ => $"{b} B"
    };

var fs = new DriveInfo("/");
Console.WriteLine($"Free space: {HR(fs.AvailableFreeSpace)}");
