using SportApp.Domain.BaseObjects;

namespace SportApp.Domain
{
    public class Excercise : Entity, IAggregateRoot
    {
        public Excercise() { }

        public Excercise(string name, string description, VideoUrl url, ExerciseType exerciseType)
        {
            Name = name;
            Description = description;
            Url = url;
            ExerciseType = exerciseType;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public VideoUrl Url { get; private set; }
        public ExerciseType ExerciseType { get; private set; }
    }
}
