using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublishYear { get; set; }
        public decimal CoverPrice { get; set; }
        public CheckInOutStatus Status { get; set; }
        public Person PersonDetails { get; set; }
        public IList<CheckInOutHistory> History { get; set; }
    }

    public enum CheckInOutStatus
    {
        CheckIn,
        CheckOut
    }

    public class Person
    {
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public int NationalId { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
    }

    public class CheckInOutHistory
    {
        public Person PersonDetails { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
    }
}