using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRazorExample.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Location 
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class OrgLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("org")]
        [Key, Column(Order = 1)]
        public int OrgId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 2)]
        [ForeignKey("loc")]
        public int LocationId { get; set; }
        public Organization org { get; set; }
        public Location loc { get; set; }
    }


    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("org")]
        public int OrgId { get; set; }
        public Organization org { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("dept")]
        public int DeptId { get; set; }
        public Department dept { get; set; }
    }

}
