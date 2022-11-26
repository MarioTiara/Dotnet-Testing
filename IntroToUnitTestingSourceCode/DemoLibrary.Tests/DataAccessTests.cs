using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Mario", LastName = "Tiara" };
            List<PersonModel> people= new List<PersonModel>();
            DataAccess.AddPersonToPeopleList(people, newPerson);
            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Mario", "", "LastName")]
        [InlineData("", "Pratama", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();
            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            List<PersonModel> people = new List<PersonModel>() { 
                new PersonModel{FirstName="mario", LastName="pratama"}    
            };
            List<string> expected = new List<string>() {"mario,pratama"};
            List<string> actual = DataAccess.ConvertModelsToCSV(people);
            Assert.True(actual.Count == 1);
            Assert.Equal(expected, actual);
        }
    }
}
