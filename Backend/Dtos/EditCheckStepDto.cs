namespace Backend.Dtos
{
    public class EditCheckStepDto
    {
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
        [Required] public int Id { get; set; }
        [Required] public bool IsCompleted { get; set; }
    }
}