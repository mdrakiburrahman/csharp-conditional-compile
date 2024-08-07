using System.Runtime.InteropServices;
#if BUILDING_ON_WINDOWS
using Bond;
using Bond.IO.Safe;
using Bond.Protocols;
#endif

class Program
{
    static void Main(string[] args)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            Console.WriteLine("Running on Linux!");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Console.WriteLine("Running on Windows!");

#if BUILDING_ON_LINUX
        Console.WriteLine("Built on Linux!");
#elif BUILDING_ON_WINDOWS
        Console.WriteLine("Built in Windows!");
        TestBond();
#endif
    }

#if BUILDING_ON_WINDOWS
    private static void TestBond()
    {
        // Create an instance of the class
        var person = new Person { Name = "John Doe", Age = 30 };

        // Serialize the object to a memory stream
        var output = new OutputBuffer();
        var writer = new CompactBinaryWriter<OutputBuffer>(output);
        Serialize.To(writer, person);

        // Deserialize the object from the memory stream
        var input = new InputBuffer(output.Data);
        var reader = new CompactBinaryReader<InputBuffer>(input);
        var deserializedPerson = Deserialize<Person>.From(reader);

        // Output deserialized data
        Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
    }
#endif
}

#if BUILDING_ON_WINDOWS
[Schema]
public class Person
{
    [Id(0)]
    public string Name { get; set; }

    [Id(1)]
    public int Age { get; set; }
}
#endif
