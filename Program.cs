using FrostDKRotation;

internal class Program
{
    private static void Main(string[] args)
    {
        PlayerResource playerResource = new PlayerResource();
        System.Console.WriteLine($"Initial Runes: {playerResource.Runes}");
        System.Console.WriteLine($"Initial Runic Power: {playerResource.RunicPower}");
        playerResource.SpendRunes(3);
        System.Console.WriteLine($"Runes after spending 3: {playerResource.Runes}");
        System.Console.WriteLine($"Runic Power after spending 3 runes: {playerResource.RunicPower}");
    }
}

