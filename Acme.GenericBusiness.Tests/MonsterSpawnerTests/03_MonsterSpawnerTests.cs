using Monsters;
using Xunit;

namespace Tests.MonsterSpawnerTests.CustomAssertion
{
    [Trait("Category", nameof(IMonsterSpawner))]
    public abstract class ASpawnedFourthLevelMonster
    {
        private readonly Monster _monster;

        protected ASpawnedFourthLevelMonster(IMonsterSpawner spawner)
        {
            _monster = spawner.CreateMonster(4);
        }

        [Fact]
        public void IsAValidMonster()
        {
            _monster.Should()
                .BeAValidMonster();
        }
    }

    public class ASpawnedKobold : ASpawnedFourthLevelMonster
    {
        public ASpawnedKobold() : base(new AngryKoboldSpawner())
        {
        }
    }

    public class ASpawnedRabbit : ASpawnedFourthLevelMonster
    {
        public ASpawnedRabbit() : base(new HarmlessRabbitSpawner())
        {
        }
    }
}