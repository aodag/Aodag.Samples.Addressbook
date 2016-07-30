using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aodag.Samples.Addressbook.Models
{
    public class Person
    {
        public int Id
        {
            get;
            set;
        }
        
        [Required]
        public string FirstName
        {
            get;
            set;
        }

        [Required]
        public string LastName
        {
            get;
            set;
        }

        [NotMapped]
        public string FullName
        {
            get {return FirstName + " " + LastName;}
        }

        [EmailAddress,Required]
        public string Email
        {
            get;
            set;
        }
    }
}