namespace Playground
{
    // 1. Methods are not implemented.
    // 2. We cannot create (directly) instances for the `IExample` interface.
    public interface IPrintable
    {
        // Naming convention:
        // !!! Interface names should begin with capital "I".
        // It is recommended to name the interface so that they end in "able". (We should differentiate `IPrintable` amd `IPrinter`)
        // In all costs, try to avoid ambiguity

        string Print();
    }
}
