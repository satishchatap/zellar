using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public interface IProduct
    {
        int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        string Supplier { get; set; }

        [Column(TypeName = "varchar(50)")]
        string Name { get; set; }
        float Rate { get; set; }
        float DailyStandingCharge { get; set; }
        int ContractLength { get; set; }
        int Renewable { get; set; }

        [Column(TypeName = "varchar(10)")]
        string Status { get; set; }
        byte[] RowVersion { get; }
    }
}
