using DbConnection.Entities;
using DbConnection.Repositories;
using FakeItEasy;
using NUnit.Framework;
using System;

namespace DbConnection.Test.Repositories
{
    [TestFixture]
    public class ActorRepositoryTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        private ActorRepository CreateActorRepository()
        {
            //return new ActorRepository();
            return null;
        }

        [Test]
        public void AddSave_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();
            Actor entity = new Actor()
            {
                FirstName = "Omar",
                LastName = "nb",
                LastUpdate = DateTime.Now
            };


            // Act
            actorRepository.AddSave(
                entity);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void DeleteById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();
            int id = 0;

            // Act
            actorRepository.DeleteById(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void DeleteSave_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();
            Actor entity = null;

            // Act
            actorRepository.DeleteSave(
                entity);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void GetAllList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();

            // Act
            var result = actorRepository.GetAllList();

            // Assert
            Assert.NotZero(result.Count());
        }

        [Test]
        public void GetById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();
            int id = 0;

            // Act
            var result = actorRepository.GetById(
                id);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void UpdateSave_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var actorRepository = this.CreateActorRepository();
            Actor entity = null;

            // Act
            actorRepository.UpdateSave(
                entity);

            // Assert
            Assert.Fail();
        }
    }
}
