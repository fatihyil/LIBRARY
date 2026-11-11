using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public  class Author :BaseEntity
    {
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;

        private readonly List<Book> _books = new List<Book>();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();
        private Author()
        {

        }
        public Author(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName.Trim()))
            {
                throw new DomainException("Author name is required");
            }

            if (string.IsNullOrWhiteSpace(lastName.Trim()))
            {
                throw new DomainException("Author lastname is required");
            }

            FirstName = firstName;
            LastName = lastName;
        }
      
    }
}
