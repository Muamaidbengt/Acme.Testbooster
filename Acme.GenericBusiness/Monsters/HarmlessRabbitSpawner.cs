using Monsters.Equipment;

namespace Monsters
{
    public class HarmlessRabbitSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Rabbit",
                Alignment = Alignment.Neutral,
                Strength = 4,
                Dexterity = 18,
                Hitpoints = 2,
                Level = level,
                Weapon = new Carrot()
            };
        }
    }
}