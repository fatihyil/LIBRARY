using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public class Member : BaseEntity
    {
        private Member()
        {

        }
        public Member(string firstName, string lastName, string email)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new DomainException("First Name is required !");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new DomainException("Last Name is Required !");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new DomainException("Email is Required !");
            }
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim();
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public int MembershipType { get; set; }
        public DateTime RegisteredAt { get; set; }

       
    }
}
