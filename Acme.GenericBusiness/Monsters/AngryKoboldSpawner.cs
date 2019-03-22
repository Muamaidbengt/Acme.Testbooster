using Monsters.Equipment;

namespace Monsters
{
    public class AngryKoboldSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Angry Kobold",
                Alignment = Alignment.Evil,
                Weapon = new RustyDagger(),
                Strength = 10,
                Dexterity = 14,
                Wisdom = 8,
                Level = level,
                Hitpoints = Diceroll.D4(level)
            };
        }
    }
}