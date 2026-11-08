using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public class Book :BaseEntity
    {
        private Book()
        {

        }
        public Book(string title, string isbn, int totalCopies)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new DomainException("Title is required");
            }
            if (string.IsNullOrEmpty(isbn))
            {
                throw new DomainException("Isbn is required");
            }
            if (totalCopies < 1)
            {
                throw new DomainException("TotalCopies can not be less than 1");
            }
            Title = title.Trim();
            Isbn = isbn.Trim();
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
        }

        public void Borrow()
        {
            if (AvailableCopies < 1)
            {
                throw new DomainException("No available copies to burrow");
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

        public void IsAvaliable()
        {

        }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public string PublicationYear { get;  private set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int TotalCopies { get; private set; }
        public int AvailableCopies { get; private set; }
    }
}
