 namespace Student_App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	using System.Web.Mvc;

	[Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Student1 = new HashSet<Student>();
        }

        [Key]
        [Required(ErrorMessage = "*")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int St_Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string St_Fname { get; set; }
       
        [Required(ErrorMessage = "*")]
        [StringLength(10)]
        [Display(Name = "Last Name")]
        public string St_Lname { get; set; }

        [StringLength(100)]
        [Display(Name = "Address")]
        public string St_Address { get; set; }

        [Display(Name = "Age")]
        public int? St_Age { get; set; }
        [Range(20,60,ErrorMessage ="Age must be between 20 and 60")]
        public int? Dept_Id { get; set; }

        public int? St_super { get; set; }


        [StringLength(50)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "invalid email")]
        [Remote("check","Student",ErrorMessage ="This email already exist")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "password not match")]
        [NotMapped]  
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone")]
        public String phone { get; set; }

        [Display(Name = "Photo")]
        [StringLength(50)]
        public string photo { get; set; }

        [StringLength(150)]
        public string CV { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student1 { get; set; }

        public virtual Student Student2 { get; set; }
    }
}
