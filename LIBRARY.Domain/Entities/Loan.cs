using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public  class Loan : BaseEntity
    {

        public int BookId { get; private set; }
        public Book Book { get; private set; } =  null!;
        public int MemberId { get; private set; }
        public Member Member { get; private set; } = null!;
        public DateTime LoanDate { get; private set; } // LoanDate is the date when the book was borrowed
        public DateTime DueDate { get; private set; }// DueDate is the date when the book is due to be returned
        public DateTime? ReturnDate { get; private set; } // ReturnDate is the date when the book was returned, it can be null if the book has not been returned yet

        private Loan()
        {
        }
        public Loan(int bookId,int memberId,DateTime loanDate ,DateTime dueDate) 
        {
            if (dueDate < loanDate)
            {
                throw new DomainException("Due date cannot be earlier than loan date");
            }
            if (BookId <= 0)
            {
                throw new DomainException("BookId must be greater than 0");
            }
            if (memberId <= 0)
            {
                throw new DomainException("memberId must be greater than 0");

            }
            DueDate = dueDate;
            LoanDate = loanDate;
            BookId = bookId;
            MemberId = memberId;
        }

        public bool IsReturned() => ReturnDate != null;
     
        public void MarkAsReturned(DateTime returnDate)
        {
            if (ReturnDate != null)
            {
                throw new DomainException("Allready returned");
                
            }
            ReturnDate = returnDate;
            
        }

        public bool IsOverDue(DateTime currentDate) => currentDate > DueDate && ReturnDate == null;
      




       

    }
}
