namespace Acme.GenericBusiness.MonsterSpawner
{
    public class WorkingKoboldSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Kobold",
                Alignment = Alignment.Evil,
                Weapon = new RustyDagger(),
                Strength = 10,
                Dexterity = 14,
                Wisdom = 8,
                Level = level,
                Hitpoints = level * 4
            };
        }
    }
}