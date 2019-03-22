using Monsters;
using FluentAssertions;
using Xunit;

namespace Tests.MonsterSpawnerTests.SingleTestForAllProperties
{
    using FluentAssertions.Execution;

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
            using (new AssertionScope())
            {
                _monster.Name.Should().NotBeNullOrEmpty();
                _monster.Alignment.Should().Be(Alignment.Evil);
                _monster.Dexterity.Should().BeGreaterThan(0);
                _monster.Strength.Should().BeGreaterThan(0);
                _monster.Wisdom.Should().BeGreaterThan(0);
                _monster.Level.Should().Be(4);
                _monster.Hitpoints.Should().BeGreaterOrEqualTo(4);
                _monster.Weapon.Should().NotBeNull();
            }
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