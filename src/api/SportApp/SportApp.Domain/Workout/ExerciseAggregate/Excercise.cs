using SportApp.Domain.BaseObjects;

namespace SportApp.Domain
{
    public class Excercise : Entity, IAggregateRoot
    {
        public Excercise() { }

        public Excercise(string name, string description, VideoUrl videoUrl, string tumbnailUrl, ExerciseType exerciseType)
        {
            Name = name;
            Description = description;
            VideoUrl = videoUrl;
            TumbnailUrl = tumbnailUrl;
            ExerciseType = exerciseType;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoUrl VideoUrl { get; private set; }
        public string TumbnailUrl { get; private set; }
        public ExerciseType ExerciseType { get; private set; }
    }
}
