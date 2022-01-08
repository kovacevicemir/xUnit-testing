using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DemoLibrary;
using System.IO;

namespace DemoLibraryTests.Tests
{
    public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldWork()
        {
            string actual = Examples.ExampleLoadTextFile("this is a valid file name.");

            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void ExampleLoadTextFile_InvalidNameShouldWork()
        {
            Assert.Throws<ArgumentException>(() => Examples.ExampleLoadTextFile(""));
        }
    }
}
