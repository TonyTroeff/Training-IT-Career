const int BufferSize = 1 * 1024 * 1024;

List<byte[]> globalBuffers = new List<byte[]>();

await Diagnose();
await Diagnose();
await Diagnose();
await Diagnose();
await Diagnose();

async Task Diagnose()
{
    List<byte[]> buffers = new List<byte[]>();

    for (int i = 0; i < 10; i++)
    {
        byte[] buffer = new byte[BufferSize];
        buffers.Add(buffer);
        Console.WriteLine($"Iteration #{i + 1}: Prepared buffer with length {buffer.Length}");
        await Task.Delay(2000);
    }
}