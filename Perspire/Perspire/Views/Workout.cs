public class Workout
{
    public string Name { get; set; }
    public string Part { get; set; }
    public string ImageSrc { get; set; }

    public override string ToString()
    {
        return Name;
    }
}