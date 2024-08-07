using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            Console.WriteLine("Running on Linux!");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Console.WriteLine("Running on Windows!");

#if LINUX
        Console.WriteLine("Built on Linux!");
#elif WINDOWS
        Console.WriteLine("Built in Windows!");
#endif
    }
}
