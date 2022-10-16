using AutoTrainerDB.Models;
using AutoTrainerServices.DTO.Muscle;
using AutoTrainerServices.Services.Exeptions;
using AutoTrainerServices.Services.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTrainerTest.MuscleTest
{
    public class MuscleTest: BaseTestFixture
    {
        [Test]
        public void GetMuscleWittCorrectID()
        {
            using ( var scope = Testing._scopeFactory.CreateScope())
            {
               var MuscleService = scope.ServiceProvider.GetRequiredService<IMuscleService>();

                CreateMuscleDTO testMuscle = new CreateMuscleDTO { Name = "Тестовое поле Name", SubName = "Тестовое поле SubName" };

                int ID = MuscleService.CreateMuscle(testMuscle);

                Muscle muscle = MuscleService.GetMuscle(ID);

                muscle.ID.Should().Be(ID);
                muscle.Name.Should().Be(testMuscle.Name);
                muscle.SubName.Should().Be(testMuscle.SubName);
            }

        }
        [Test]
        public void GetMuscleWittUnCorrectID()
        {
            using (var scope = Testing._scopeFactory.CreateScope())
            {
                var MuscleService = scope.ServiceProvider.GetRequiredService<IMuscleService>();              
                                

                FluentActions.Invoking(()=>MuscleService.GetMuscle(0)).Should().Throw<NotFoundExeption>();

            }

        }


    }
}
