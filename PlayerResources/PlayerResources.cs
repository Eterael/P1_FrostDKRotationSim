namespace FrostDKRotation;



public class PlayerResource
{
    private const int MaxRunes = 6;
    private const int MaxRunicPower = 100;
    private const double RuneRechargeTime = 10.0; // seconds


    private enum RuneState
    {
        Ready,
        Recharging,
        Queued
    }

    private class Rune
    {
        public RuneState State { get; set; }
        public float Timer { get; set; }

        public Rune()
        {
            State = RuneState.Ready;
            Timer = 0.0;
        }
    }

    public int ReadyRunes {
        get
        {
            readyrunes = 0;
            for (int i = 0; i < MaxRunes; i++)
            {
                if (runes[i].State == RuneState.Ready)
                {
                    readyrunes++;
                }
            }
            return readyrunes;
        }
    }
    public int RunicPower { get; private set; }

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
            if (runes[i].State == RuneState.Ready)
                runescount++;
        }

        if (runescount < amount)
            return; // Not enough runes to spend

        int spent = 0;
        for (int i = 0; i < MaxRunes && spent < amount; i++)
        {
            if (runes[i].State == RuneState.Ready)
            {
                runes[i].State = RuneState.Queued;
                runes[i].Timer = 0.0;
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
            if (runes[i].State == RuneState.Recharging)
            {
                runes[i].Timer += deltaTime;
                if (runes[i].Timer >= RuneRechargeTime)
                {
                    runes[i].State = RuneState.Ready;
                    runes[i].Timer = 0.0f;
                }
            }
        }
    }


    private void UpdateRunes(double deltaTime)
    {
        if (deltaTime <= 0.0)
            return;
    
    }
}

