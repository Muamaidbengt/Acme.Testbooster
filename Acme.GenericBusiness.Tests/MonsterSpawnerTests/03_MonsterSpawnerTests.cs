using System;
using System.Linq;
using Monsters;
using FluentAssertions;
using Xunit;

namespace Tests.MonsterSpawnerTests.ReflectedDiscovery
{
    using FluentAssertions.Execution;
    using FluentAssertions.Types;
    using System.Collections.Generic;

    [Trait("Category", nameof(IMonsterSpawner))]
    public class AMonsterSpawner
    {
        [Theory]
        [MemberData(nameof(MonsterSpawners))]
        public void SpawnsAValidMonster(Type monsterSpawnerType)
        {
            var spawner = (IMonsterSpawner)Activator.CreateInstance(monsterSpawnerType);
            var monster = spawner.CreateMonster(4);
            using (new AssertionScope())
            {
                monster.Name.Should().NotBeNullOrEmpty();
                monster.Alignment.Should().Be(Alignment.Evil);
                monster.Dexterity.Should().BeGreaterThan(0);
                monster.Strength.Should().BeGreaterThan(0);
                monster.Wisdom.Should().BeGreaterThan(0);
                monster.Level.Should().Be(4);
                monster.Hitpoints.Should().BeGreaterOrEqualTo(4);
                monster.Weapon.Should().BeAssignableTo<Attack>();
            }
        }

        public static IEnumerable<object[]> MonsterSpawners()
        {
            return AllTypes.From(typeof(IMonsterSpawner).Assembly)
                .ThatImplement<IMonsterSpawner>()
                .Select(t => new object[] {t});
        }
    }
}