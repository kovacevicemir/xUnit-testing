using System;
using System.Collections.Generic;
using System.Text;
using DemoLibrary;
using DemoLibrary.Models;
using Xunit;

namespace DemoLibraryTests.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            // Arrange
            PersonModel newPerson = new PersonModel
            {
                FirstName = "Emir",
                LastName = "Kovacevic"
            };

            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            // Assert
            Assert.True(people.Count == 1);

            // Assert
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Emir", "", "LastName")]
        [InlineData("", "Kovacevic", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            // Arrange
            PersonModel newPerson = new PersonModel
            {
                FirstName = firstName,
                LastName = lastName
            };

            List<PersonModel> people = new List<PersonModel>();

            // Assert Exception catch
            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            // Arange
            List<PersonModel> listOfPeople = new List<PersonModel>();

            PersonModel person1 = new PersonModel
            {
                FirstName = "Emir",
                LastName = "Kovacevic"
            };

            PersonModel person2 = new PersonModel
            {
                FirstName = "Tom",
                LastName = "Etc"
            };

            DataAccess.AddPersonToPeopleList(listOfPeople, person1);
            DataAccess.AddPersonToPeopleList(listOfPeople, person2);


            List<string> stringListOFPeople = DataAccess.ConvertModelsToCSV(listOfPeople);

            // Assert 
            Assert.Contains<string>(person1.FirstName + "," + person1.LastName, stringListOFPeople);
            Assert.Contains<string>(person2.FirstName + "," + person2.LastName, stringListOFPeople);
        }
    }
}
