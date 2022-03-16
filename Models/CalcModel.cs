namespace WEB_Lab_2.Models
{
    public class CalcModel
    {
        public float X { get; init; }
        public float Y { get; init; }
        public string? Operation { get; init; }

        public string Calc() =>
            Operation switch
            {
                "+" => $"{X} + {Y} = {X + Y}",
                "-" => $"{X} - {Y} = {X - Y}",
                "*" => $"{X} * {Y} = {X * Y}",
                "/" => $"{X} / {Y} = {X / Y}",
                _ => "Invalid operation"
            };
    }
}
