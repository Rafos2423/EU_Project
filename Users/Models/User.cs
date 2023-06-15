using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }

        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsLoged { get; set; }
    }

    public enum Gender { Male, Female }
}
