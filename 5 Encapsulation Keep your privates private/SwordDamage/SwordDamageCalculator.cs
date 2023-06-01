using System;
using System.Diagnostics;

namespace SwordDamage
{
    public class SwordDamageCalculator
    {
        Random random = new Random();

        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll { get; private set; }

        private decimal MagicMultiplier = 1M;
        private int FlamingDamage = 0;

        public int Damage
        {
            get
            {
                return (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
            }
        }

        public bool Magic
        {
            set
            {
                MagicMultiplier = (value ? 1.75M : 1M);

                Debug.WriteLine($"Magic finished: {Damage} (roll: {Roll})");
            }
        }

        public bool Flaming
        {
            set
            {
                FlamingDamage = (value ? FLAME_DAMAGE : 0);

                Debug.WriteLine($"Flaming finished: {Damage} (roll: {Roll})");
            }
        }

        internal void RollDice()
        {
            Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);

            Debug.WriteLine($"RollDice finished: {Damage} (roll: {Roll}");
        }

        public string ToString()
        {
            return $" ( {Roll} * {MagicMultiplier} = {(int)(Roll * MagicMultiplier)}) + {BASE_DAMAGE} + {FlamingDamage}";
        }

    }

}
