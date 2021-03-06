﻿using SportApp.Domain;
using System.Collections.Generic;

namespace SportApp.Infrastructure.SeedData
{
    public class ExerciseSeedData
    {
        public void Seed(SportAppDbContext dbContext)
        {
            foreach (var data in GetSeedData())
            {
                dbContext.Excercises.Add(data);
            }
            dbContext.SaveChanges();
        }

        private IEnumerable<Excercise> GetSeedData()
        {
            yield return new Excercise(
                "Thruster",
                "Thruster description",
                new VideoUrl("https://www.youtube.com/embed/mieC65cBFEk", VideoService.YouTube),
                "http://2.bp.blogspot.com/-QSMkvHbTD88/VkG0t_7bgwI/AAAAAAAAErs/Yj8d7k1Do3M/s1600/2013-Thrusters-Combined.jpg",
                ExerciseType.Weightlifting);
        }
    }
}
