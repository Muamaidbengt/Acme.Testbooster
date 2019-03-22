using Monsters.Equipment;

namespace Monsters
{
    public class CluelessVillagerSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Villager",
                Alignment = Alignment.Good,
                Strength = 12,
                Dexterity = 12,
                Hitpoints = Diceroll.D4(level),
                Level = level,
                Weapon = new Pitchfork()
            };
        }
    }
}