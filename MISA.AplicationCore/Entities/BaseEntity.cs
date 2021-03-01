using MISA.AplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string Name { get; set; }
        public DisplayName(string name = null)
        {
            this.Name = name;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute { 

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Value { get; set; }
        public string ErroMsg { get; set; }
        public MaxLength(int length, string erroMsg = null)
        {
            this.Value = length;
            this.ErroMsg = erroMsg;
        }
    }
    public class BaseEntity
    {
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
