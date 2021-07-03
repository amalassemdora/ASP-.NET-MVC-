using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Day4Task.Models
{
	public class Student
	{

		public int Id { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		public int? Age { get; set; }
		[ForeignKey("Departments")]
		public int? dept_id { get; set; }
		public virtual Department Departments { get; set; }
	}
}