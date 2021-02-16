using SportApp.Domain;
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
                new VideoUrl("https://www.youtube.com/watch?v=mieC65cBFEk", VideoService.YouTube),
                ExerciseType.Weightlifting);
        }
    }
}
