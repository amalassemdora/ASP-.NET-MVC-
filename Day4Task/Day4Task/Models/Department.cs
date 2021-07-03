using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day4Task.Models
{
	public class Department
	{
		public Department()
		{
			student = new List<Student>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Dept_id { get; set; }
		public string Dept_name { get; set; }
		public string location { get; set; }

		public virtual List<Student> student { get; set; }
	}
}