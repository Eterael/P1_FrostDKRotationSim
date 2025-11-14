namespace FrostDKRotation;



public class PlayerResource
{
    private const int MaxRunes = 6;
    private const int MaxRunicPower = 100;
    private const double RuneRechargeTime = 10.0; // seconds





    private readonly Rune[] runes = new Rune[MaxRunes];

    public int ReadyRunes {
        get
        {
            int readyrunes = 0;
            for (int i = 0; i < MaxRunes; i++)
            {
                if (runes[i].State == Rune.RuneState.Ready)
                {
                    readyrunes++;
                }
            }
            return readyrunes;
        }
    }
    public int RunicPower { get; private set; }
    private static readonly Random rng = new Random();

    public PlayerResource()
    {
        RunicPower = 0;
        for (int i = 0; i < MaxRunes; i++)
        {
            runes[i] = new Rune();
        }
    }

    public void SpendRunes(int amount)
    {
        if (amount <= 0) return;

        int runescount = 0;
        for (int i = 0; i < MaxRunes; i++)
        {
            if (runes[i].State == Rune.RuneState.Ready)
                runescount++;
        }

        if (runescount < amount)
            return; // Not enough runes to spend

        int spent = 0;
        for (int i = 0; i < MaxRunes && spent < amount; i++)
        {
            if (runes[i].State == Rune.RuneState.Ready)
            {
                runes[i].State = Rune.RuneState.Queued;
                runes[i].Timer = 0.0f;
                spent++;
            }
        }

        IncreaseRunicPower(amount * 10); // Example: Each spent rune gives 10 Runic Power
    }

    private void IncreaseRunicPower(int amount)
    {
        RunicPower += amount;
        if (RunicPower > MaxRunicPower)
        {
            RunicPower = MaxRunicPower;
        }
    }

    private void RunePassiveGeneration(float deltaTime)
    {
        for (int i = 0; i < MaxRunes; i++)
        {
            if (runes[i].State == Rune.RuneState.Recharging)
            {
                runes[i].Timer += deltaTime;
                if (runes[i].Timer >= RuneRechargeTime)
                {
                    runes[i].State = Rune.RuneState.Ready;
                    runes[i].Timer = 0.0f;
                }
            }
        }
    }


    private void UpdateRunes(double deltaTime)
    {
        if (deltaTime <= 0.0)
            return;



        int rechargingCount = 0;
        for (int i = 0; i < MaxRunes; i++)
        {
            if (runes[i].State == Rune.RuneState.Recharging)
                rechargingCount++;
        }


        if (rechargingCount < 3)
        {
            for (int i = 0; i < MaxRunes && rechargingCount < 3; i++)
            {
                if (runes[i].State == Rune.RuneState.Queued)
                {
                    runes[i].State = Rune.RuneState.Recharging;
                    runes[i].Timer = 0.0f;
                    rechargingCount++;
                }
            }
        }


        for (int i = 0; i < MaxRunes; i++)
        {
            if (runes[i].State == Rune.RuneState.Recharging)
            {
                runes[i].Timer += (float)deltaTime;
                if (runes[i].Timer >= RuneRechargeTime)
                {
                    runes[i].State = Rune.RuneState.Ready;
                    runes[i].Timer = 0.0f;
                }
            }
        }
    }

    private void RunicPowerSpend(int amount)
    {
        if (amount <= 0) return;
        if (RunicPower < amount) return;

        RunicPower -= amount;



    }
}

