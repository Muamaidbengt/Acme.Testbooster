using Monsters.Equipment;

namespace Monsters
{
    public class FirebreathingDragonSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Firebreathing dragon OF DOOM!!!",
                Alignment = Alignment.Evil,
                Strength = 25,
                Dexterity = 18,
                Wisdom = 23,
                Hitpoints = Diceroll.D8(level * 2),
                Level = level,
                Weapon = new FieryBreath()
            };
        }
    }
}
