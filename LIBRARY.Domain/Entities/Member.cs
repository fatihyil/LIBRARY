using LIBRARY.Domain.Common;
using LIBRARY.Domain.Enums;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        public MembershipType MembershipType { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        private Member()
        {

        }
        public Member(string firstName, string lastName, string email, MembershipType membershipType,DateTime registeredAt)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException("First Name is required !");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException("Last Name is Required !");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email is Required !");
            }
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim();
            MembershipType = membershipType;
            RegisteredAt = registeredAt;
        }
      

       
    }
}
