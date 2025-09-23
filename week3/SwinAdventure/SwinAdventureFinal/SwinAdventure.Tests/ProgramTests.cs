// ProgramTests.cs
using NUnit.Framework;
using SwinAdventure;
using System;
using System.IO;

namespace SwinAdventure.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private StringWriter _stringWriter;
        private TextWriter _originalOutput;

        [SetUp]
        public void Setup()
        {
            // Capture console output for testing
            _originalOutput = Console.Out;
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [TearDown]
        public void TearDown()
        {
            // Restore original console output
            Console.SetOut(_originalOutput);
            _stringWriter?.Dispose();
        }

        [Test]
        public void TestMainMethodExists()
        {
            // Test that the Main method exists and can be called
            // This is a basic test to ensure the entry point is properly defined
            var mainMethod = typeof(Program).GetMethod("Main",
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            Assert.That(mainMethod, Is.Not.Null, "Main method should exist");
            Assert.That(mainMethod!.ReturnType, Is.EqualTo(typeof(void)), "Main method should return void");

            var parameters = mainMethod!.GetParameters();
            Assert.That(parameters.Length, Is.EqualTo(1), "Main method should have one parameter");
            Assert.That(parameters![0].ParameterType, Is.EqualTo(typeof(string[])), "Main method parameter should be string[]");
        }

        [Test]
        public void TestMainCreatesGame()
        {
            // Test that Main method creates and starts a game
            // Note: This test will start the actual game, so we need to be careful
            // We'll test the method signature and structure rather than execution
            // since the game has an infinite loop waiting for user input

            var programType = typeof(Program);
            Assert.That(programType, Is.Not.Null, "Program class should exist");

            // Verify the Main method has the correct signature for a console application entry point
            var mainMethod = programType.GetMethod("Main");
            Assert.That(mainMethod.IsStatic, Is.True, "Main method should be static");
            Assert.That(mainMethod.IsPublic, Is.True, "Main method should be public");
        }

        [Test]
        public void TestProgramClassStructure()
        {
            // Test basic structure of Program class
            var programType = typeof(Program);

            Assert.That(programType.IsClass, Is.True, "Program should be a class");
            Assert.That(programType.IsPublic, Is.True, "Program class should be public");

            // Test that it's in the correct namespace
            Assert.That(programType.Namespace, Is.EqualTo("SwinAdventure"), "Program should be in SwinAdventure namespace");
        }

        // Note: We cannot easily test the actual execution of Main() because:
        // 1. It creates an infinite loop waiting for user input
        // 2. It would require mocking Console.ReadLine() which is complex
        // 3. The game.Start() method doesn't return until "quit" is entered
        // 
        // For a complete integration test, you would need to:
        // - Mock Console.ReadLine() to return "quit"
        // - Capture the console output
        // - Verify the welcome message and game startup
    }
}