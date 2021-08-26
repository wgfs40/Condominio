﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Condominio.Applications.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public decimal PaymentsAmount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
