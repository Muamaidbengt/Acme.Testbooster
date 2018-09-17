using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Types;
using Xunit;

namespace Acme.GenericBusiness.Tests
{
    [Trait("Category", "MetaTests")]
    public class TestsTests
    {
        [Theory]
        [MemberData(nameof(GetAllClassesInTestAssembly))]
        public void AllTestClassesShouldBeAnnotatatedAsTests(Type testclass)
        {
            testclass.Methods()
                .ThatArePublicOrInternal
                .ThatReturnVoid
                .Should().BeDecoratedWith<FactAttribute>();
        }

        public void ForgottenTest()
        {
            "This is a test and it".Should().Be("run");
        }

        public static IEnumerable<object[]> GetAllClassesInTestAssembly()
        {
            return AllTypes.From(typeof(TestsTests).Assembly).Select(x => new object[] {x});
        }
    }
}