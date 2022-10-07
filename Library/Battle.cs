namespace DigiWorld
{
    /// <summary>
    /// Class <c>Battle</c> models a battle between two Digimon.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// Instance variable <c>_digimon1</c> represents one of the Digimons engaged in the battle.
        /// </summary>
        private Digimon _digimon1;
        /// <summary>
        /// Instance variable <c>_digimon2</c> represents one of the Digimons engaged in the battle.
        /// </summary>
        private Digimon _digimon2;
        /// <summary>
        /// Instance variable <c>_round</c> represents how many turns have passed in the battle.
        /// </summary>
        int _round = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Battle"/> class.
        /// </summary>
        /// <param name="userDigimon">
        /// The players <see cref="Digimon"/>, assigned to <see cref="_digimon1"/>.
        /// </param>
        /// <param name="opponentDigimon">
        /// The opponent <see cref="Digimon"/>, assigned to <see cref="_digimon2"/>.
        /// </param>
        public Battle(Digimon userDigimon, Digimon opponentDigimon)
        {
            _digimon1 = userDigimon;
            _digimon2 = opponentDigimon;
        }

        /// <summary>
        /// Logic to resolve a Digimon Battle
        /// </summary>
        /// <returns>
        /// int: 0 = Error, 1 = User won, 2 = Opponent won, 3 = Draw
        /// </returns>
        public int Resolve()
        {
            try
            {
                // Flip a coin to determine which Digimon attacks first
                Random rnd = new Random();
                int coinToss = rnd.Next(1, 2);
                Digimon first;
                Digimon second;

                // Track which digimon is first
                bool firstIsD1;

                if (coinToss == 1)
                {
                    first = _digimon1;
                    second = _digimon2;
                    firstIsD1 = true;
                }
                else
                {
                    first = _digimon2;
                    second = _digimon1;
                    firstIsD1 = false;
                }
                double firstHp = first.MaxHp;
                double secondHp = second.MaxHp;
                double dmg;

                while (firstHp > 0 && secondHp > 0)
                {
                    ++_round;
                    dmg = ResolveAttack(first, second);
                    if (dmg > 0)
                    {
                        secondHp -= dmg;
                    }

                    if (secondHp <= 0)
                    {
                        break;
                    }

                    dmg = ResolveAttack(second, first);
                    if (dmg > 0)
                    {
                        firstHp -= dmg;
                    }

                    Console.WriteLine(first.Name + " " + firstHp + "hp");
                    Console.WriteLine(second.Name + " " + secondHp + "hp");
                    if (_round > 100)
                    {
                        // Avoid infinite battles
                        return 3;
                    }
                }

                if (firstHp > 0 && secondHp <= 0)
                {
                    // First won
                    return firstIsD1 ? 1 : 2;
                }
                if (secondHp > 0 && firstHp <= 0)
                {
                    // Second won
                    return firstIsD1 ? 2 : 1;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Calculate the amount of damage done to a Digimon by another.
        /// </summary>
        /// <param name="attacker">
        /// The attacking <see cref="Digimon"/>.
        /// </param>
        /// <param name="defender">
        /// The defending <see cref="Digimon"/>.
        /// </param>
        /// <returns>
        /// double: The amount of damage dealt.
        /// </returns>
        private double ResolveAttack(Digimon attacker, Digimon defender)
        {
            Random rnd = new Random();
            // Determine elemental bonuses/penalties
            double attack_elemental_multiplier = 1;
            double defense_elemental_multiplier = 1;
            if (defender.Species.Element.Weaknesses.ContainsKey(attacker.Species.Element.Name))
            {
                attack_elemental_multiplier = 1.5;
            }
            if (defender.Species.Element.Strengths.ContainsKey(attacker.Species.Element.Name))
            {
                defense_elemental_multiplier = 1.5;
            }

            // Calculate attack value
            double attack = (attacker.Attack + rnd.Next(1, 20)) * attack_elemental_multiplier;
            // Calculate defense value
            double defense = defender.Defense * defense_elemental_multiplier;
            // Calculate damage
            double damage = attack - defense;

            if (damage > 0)
            {
                Console.WriteLine(attacker.Name + " attacked " + defender.Name + " for " + damage + " damage");
                if (attack_elemental_multiplier == 1.5)
                {
                    Console.WriteLine(attacker.Name + "s attack was extra effective!");
                }
            }
            else
            {
                Console.WriteLine(attacker.Name + "s attack missed!");
            }
            if (defense_elemental_multiplier == 1.5)
            {
                Console.WriteLine(defender.Name + " was resistant to " + attacker.Name + "s attack");
            }

            return damage;
        }
    }
}