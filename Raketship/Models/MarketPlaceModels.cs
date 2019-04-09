using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace Raketship.Models
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Table> Table { get; set; }
    }

    [Table("Table")]
    public class Table
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string CompanyName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal Amount { get; set; }
        public string Term { get; set; }
        public string Rating { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal AmountFunded { get; set; }
    }
}
