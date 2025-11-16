using FrostDKRotation.PlayerResource;

namespace FrostDKRotation.Abilities;

public static class Obliterate
{
    public const int RuneCost = 2;

    public static bool CanSpendRunes(PlayerResource playerResource)
    {
        return playerResource.SpendRunes(RuneCost);
    }
}