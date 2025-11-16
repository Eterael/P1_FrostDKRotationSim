using FrostDKRotation.PlayerResource;

namespace FrostDKRotation.Abilities;

public static class Froststrike
{
    public const int RunicPowerCost = 35;


    public static bool CanSpendRunicPower(PlayerResource playerResource)
    {
        return playerResource.SpendRunicPower(RunicPowerCost);
    }
}