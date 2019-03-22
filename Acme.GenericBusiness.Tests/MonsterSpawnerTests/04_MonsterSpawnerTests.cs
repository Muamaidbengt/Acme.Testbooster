using System;
using System.Linq;
using Monsters;
using Xunit;
using FluentAssertions.Types;
using System.Collections.Generic;

namespace Tests.MonsterSpawnerTests.ReflectedDiscovery
{
    [Trait("Category", nameof(IMonsterSpawner))]
    public class AMonsterSpawner
    {
        [Theory]
        [MemberData(nameof(MonsterSpawners))]
        public void SpawnsAValidMonster(Type monsterSpawnerType)
        {
            var spawner = (IMonsterSpawner)Activator.CreateInstance(monsterSpawnerType);
            var monster = spawner.CreateMonster(4);
            monster.Should().BeAValidMonster();
        }

        public static IEnumerable<object[]> MonsterSpawners()
        {
            return AllTypes.From(typeof(IMonsterSpawner).Assembly)
                .ThatImplement<IMonsterSpawner>()
                .Select(t => new object[] {t});
        }
    }
}