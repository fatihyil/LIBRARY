using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public class Book :BaseEntity
    {
        public string Title { get; private set; } = null!;
        public string Isbn { get; private set; } = null!;
        public int PublicationYear { get; private set; }
        public int AuthorId { get; private set; }
        public Author Author { get; private set; } = null!;
        public int TotalCopies { get; private set; }
        public int AvailableCopies { get; private set; }
        private Book()
        {

        }
        public Book(string title, string isbn, int totalCopies,int publicationYear,int authorId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Title is required");
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new DomainException("Isbn is required");
            }
            if (totalCopies < 1)
            {
                throw new DomainException("TotalCopies can not be less than 1");
            }
            if (publicationYear <= 0)
            {
                throw new DomainException("PublicationYear must be greater than 0");
            }
            if (authorId <= 0)
            {
                throw new DomainException("AuthorId can not be less than or equal to 0");
            }
            Title = title.Trim();
            Isbn = isbn.Trim();
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
            PublicationYear = publicationYear;
            AuthorId = authorId;
        }

        public void Borrow()
        {
            if (AvailableCopies < 1)
            {
                throw new DomainException("No available copies to borrow");
            }
            AvailableCopies--;
        }
        public void Return()
        {
            if (AvailableCopies >= TotalCopies)
            {
                throw new DomainException("All copies are already returned");
            }
            AvailableCopies++;
        }

        public bool IsAvailable() => AvailableCopies > 0;

        
    }
}
