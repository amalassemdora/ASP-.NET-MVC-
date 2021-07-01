namespace MVC_Edit_Design.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Stud_Course = new HashSet<Stud_Course>();
            Student1 = new HashSet<Student>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="ID")]
        [Required(ErrorMessage ="*")]
        public int St_Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        public string St_Fname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(10)]
        [Required(ErrorMessage = "*")]
        public string St_Lname { get; set; }

        [Display(Name = "Address")]
        [StringLength(100)]
        public string St_Address { get; set; }

        [Display(Name = "Age")]
        public int? St_Age { get; set; }

        [Display(Name = "Department")]
        public int? Dept_Id { get; set; }

        public string photo { get; set; }
        public string CV { get; set; }
        public int? St_super { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stud_Course> Stud_Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student1 { get; set; }

        public virtual Student Student2 { get; set; }
    }
}
