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
            : base("RaketShipConnection")
        {
        }

        public DbSet<MarketPlace> MarketPlace { get; set; }
    }

    [Table("MarketPlace")]
    public class MarketPlace
	{
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InvId { get; set; }
		public Guid EOLInvId { get; set; }
		public string InvNumber { get; set; }
		public Guid InvOwner { get; set; }
		[NotMapped]
		public string CompanyName { get; set; }
		[NotMapped]
		[DisplayFormat(DataFormatString = "{0:N}")]
        public decimal Amount { get; set; }
        public int PaymentTerm { get; set; }
		[NotMapped]
		public string Term {
			get
			{
				return  String.Concat(PaymentTerm.ToString()," ","days");
			}
		}
		[NotMapped]
        public string Rating { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal CurrentFund { get; set; }
    }
}
