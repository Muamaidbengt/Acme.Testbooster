using System;
using System.Linq;
using Acme.GenericBusiness.MonsterSpawner;
using FluentAssertions;
using Xunit;

namespace Acme.GenericBusiness.Tests.MonsterSpawnerTests
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
        public void HasAName()
        {
            _monster.Name.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void IsEvil()
        {
            _monster.Alignment.Should().Be(Alignment.Evil);
        }

        [Fact]
        public void HasDexterity()
        {
            _monster.Dexterity.Should().BeGreaterThan(0);
        }

        [Fact]
        public void HasStrength()
        {
            _monster.Strength.Should().BeGreaterThan(0);
        }

        [Fact]
        public void HasAWeapon()
        {
            _monster.Weapon.Should().NotBeNull();
        }

        [Fact]
        public void HasWisdom()
        {
            _monster.Wisdom.Should().BeGreaterThan(0);
        }

        [Fact]
        public void IsLevel4()
        {
            _monster.Level.Should().Be(4);
        }

        [Fact]
        public void HasAtLeastOneHitpointPerLevel()
        {
            _monster.Hitpoints.Should().BeGreaterOrEqualTo(4);
        }
    }

    public class ASpawnedKobold : ASpawnedFourthLevelMonster
    {
        public ASpawnedKobold() : base(new WorkingKoboldSpawner())
        {
        }
    }

    public class ASpawnedGremlin : ASpawnedFourthLevelMonster
    {
        public ASpawnedGremlin() : base(new BuggyGremlinSpawner())
        {
        }
    }
}

namespace Acme.GenericBusiness.Tests.MonsterSpawnerTests.SingleTestForAllProperties
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
            _monster.Name.Should().NotBeNullOrEmpty();
            _monster.Alignment.Should().Be(Alignment.Evil);
            _monster.Dexterity.Should().BeGreaterThan(0);
            _monster.Strength.Should().BeGreaterThan(0);
            _monster.Wisdom.Should().BeGreaterThan(0);
            _monster.Level.Should().Be(4);
            _monster.Hitpoints.Should().BeGreaterOrEqualTo(4);
            _monster.Weapon.Should().NotBeNull();
        }

        [Fact]
        public void IsAValidMonster_AssertionScope()
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
        public ASpawnedKobold() : base(new WorkingKoboldSpawner())
        {
        }
    }

    public class ASpawnedGremlin : ASpawnedFourthLevelMonster
    {
        public ASpawnedGremlin() : base(new BuggyGremlinSpawner())
        {
        }
    }
}

namespace Acme.GenericBusiness.Tests.MonsterSpawnerTests.ReflectedDiscovery
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
                monster.Weapon.Should().NotBeNull();
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