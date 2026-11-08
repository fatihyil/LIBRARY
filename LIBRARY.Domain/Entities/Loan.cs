using LIBRARY.Domain.Common;
using LIBRARY.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIBRARY.Domain.Entities
{
    public  class Loan : BaseEntity
    {
        public Loan(DateTime dueDate ,DateTime loanDate) 
        {
            if (dueDate < loanDate)
            {
                throw new DomainException("LoanDate Error !");
            }
        }

        public void  IsReturned()
        {
        }
        public void MarkAsReturned(DateTime returnDate)
        {
            if (ReturnDate != null)
            {
                throw new DomainException("Allready Returned");
            }
            ReturnDate = returnDate;
        }

        public void IsOverDue()
        {
            if (DueDate < DateTime.Now)
            {
                throw new DomainException("Over DueDate !");
            }
        }




        public int BookId { get; set; }
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; } 

    }
}
