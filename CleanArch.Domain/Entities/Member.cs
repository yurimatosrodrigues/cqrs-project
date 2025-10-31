using CleanArch.Domain.Validation;
using System.Text.Json.Serialization;

namespace CleanArch.Domain.Entities
{
    public sealed class Member : Entity
    {
        public Member()
        {
            
        }

        public Member(string firstName, string lastName, string gender, string email, bool? active)
        {
            ValidateDomain(firstName, lastName, gender, email, active);
        }

        [JsonConstructor]
        public Member(int id, string firstName, string lastName, string gender, string email, bool? active)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(firstName, lastName, gender, email, active);
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        public void Update(string firstName, string lastName, string gender, string email, bool? active)
        {
            ValidateDomain(firstName, lastName, gender, email, active);
        }

        private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? active)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName), "Invalid name. First Name is required.");
            DomainValidation.When(firstName.Length < 3, "Invalid name. Minimum 3 characters.");

            DomainValidation.When(string.IsNullOrEmpty(lastName), "Invalid last name. Last Name is required.");
            DomainValidation.When(lastName.Length < 3, "Invalid last name. Minimum 3 characters.");

            DomainValidation.When(email?.Length < 6, "Invalid email. Minimum 6 characters.");
            DomainValidation.When(email?.Length > 250, "Invalid email. Maximum 250 characters.");

            DomainValidation.When(string.IsNullOrEmpty(gender), "Invalid gender. Gender is required.");

            DomainValidation.When(!active.HasValue, "Must define activity.");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = active;
        }                
    }
}
