﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Types;
using Xunit;

namespace Tests
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

        public static IEnumerable<object[]> GetAllClassesInTestAssembly()
        {
            return AllTypes.From(typeof(TestsTests).Assembly).Select(x => new object[] {x});
        }
    }
}