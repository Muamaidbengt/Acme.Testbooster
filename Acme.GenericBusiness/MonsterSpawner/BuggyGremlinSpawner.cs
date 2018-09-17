namespace Acme.GenericBusiness.MonsterSpawner
{
    public class BuggyGremlinSpawner : IMonsterSpawner
    {
        public Monster CreateMonster(int level)
        {
            return new Monster
            {
                Name = "Gremlin",
                Alignment = Alignment.Neutral,
                Strength = 4
            };
        }
    }
}