using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Monsters;

namespace Tests.MonsterSpawnerTests
{
    public static class MonsterAssertionsExtensions
    {
        public static MonsterAssertions Should(this Monster monster)
        {
            return new MonsterAssertions(monster);
        }
    }

    public class MonsterAssertions : ObjectAssertions
    {
        private readonly Monster _monster;
        public MonsterAssertions(Monster monster) : base(monster)
        {
            _monster = monster;
        }

        public AndWhichConstraint<MonsterAssertions, Monster> BeAValidMonster(string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope(_monster.ToString())
                .BecauseOf(because, becauseArgs))
            {
                Execute.Assertion
                    .ForCondition(!string.IsNullOrEmpty(_monster.Name))
                    .FailWith("Expected {context:monster} to have a name{reason}, but its name was {0}",
                        _monster.Name == null ? "(null)" : "(empty string)");
                Execute.Assertion
                    .ForCondition(_monster.Alignment == Alignment.Evil)
                    .FailWith("Expected {context:monster} to be evil{reason}, but it was {0}", _monster.Alignment);
                Execute.Assertion
                    .ForCondition(_monster.Dexterity > 0)
                    .FailWith("Expected {context:monster} to be nimble{reason}, but its dexterity was {0}", _monster.Dexterity);
                Execute.Assertion
                    .ForCondition(_monster.Strength > 0)
                    .FailWith("Expected {context:monster} to be strong{reason}, but its strength was {0}", _monster.Strength);
                Execute.Assertion
                    .ForCondition(_monster.Wisdom > 0)
                    .FailWith("Expected {context:monster} to be cunning{reason}, but its wisdom was {0}", _monster.Wisdom);
                Execute.Assertion
                    .ForCondition(_monster.Level > 0)
                    .FailWith("Expected {context:monster} to be experienced{reason}, but its level was {0}", _monster.Level);
                Execute.Assertion
                    .ForCondition(_monster.Hitpoints > 0)
                    .FailWith("Expected {context:monster} to be alive{reason}, but its hitpoints was {0}", _monster.Hitpoints);
                Execute.Assertion
                    .ForCondition(_monster.Weapon is Attack)
                    .FailWith("Expected {context:monster} to be able to attack{reason}, but its weapon was {0}", _monster.Weapon.ToString());
            }

            return new AndWhichConstraint<MonsterAssertions, Monster>(this, _monster);
        }
    }
}
