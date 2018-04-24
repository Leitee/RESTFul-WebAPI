﻿using Pandora.BackEnd.Model.AppEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.BackEnd.Model.Users
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserId { get; set; }

        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

        public override string ToString()
        {
            return $"{User.FirstName} {User.LastName}";
        }
    }
}
