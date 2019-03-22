using Monsters;
using FluentAssertions;
using Xunit;

namespace Tests.MonsterSpawnerTests
{
    using FluentAssertions.Execution;

    [Trait("Category", nameof(IMonsterSpawner))]
    public class ASpawnedFourthLevelKobold
    {
        private readonly Monster _monster;

        protected ASpawnedFourthLevelKobold()
        {
            var spawner = new AngryKoboldSpawner();
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

    [Trait("Category", nameof(IMonsterSpawner))]
    public class ASpawnedFourthLevelRabbit
    {
        private readonly Monster _monster;

        protected ASpawnedFourthLevelRabbit()
        {
            var spawner = new HarmlessRabbitSpawner();
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
}