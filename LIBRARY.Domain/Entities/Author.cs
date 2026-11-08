using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public  class Author :BaseEntity
    {
        private Author()
        {

        }
        public Author(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new DomainException("Author name is required");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new DomainException("Author lastname is required");
            }

            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
