using CodeAssgnment.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeAssignment.Web.Models
{
    public class UserModel
    {
        public UserModel()
        { }

        public UserModel(UserEntity model)
        {
            this.ForeNames = model.ForeNames;
            this.SurName = model.SurName;
            this.Gender = model.Gender;
            this.CreatedOn = model.CreatedOn;
            this.UpdatedOn = model.UpdatedOn;
            this.MobileNo = model.MobileNo;
            this.Id = model.Id;
            this.Dob = model.Dob;
            this.HomeNo = model.HomeNo;
            this.WorkNo = model.WorkNo;
        }

        public int Id { get; set; }

        [Required]
        [Range(3, 50, ErrorMessage = "Enter number between 3 to 50")]
        public string ForeNames { get; set; }

        [Required]
        [Range(2, 50, ErrorMessage = "Enter number between 2 to 50")]
        public string SurName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]        
        public DateTime? Dob { get; set; }

        [Required]
        public bool Gender { get; set; }

        public string HomeNo { get; set; }
        public string WorkNo { get; set; }
        public string MobileNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public UserEntity ConvertToEntity(UserModel model)
        {
            UserEntity obj = new UserEntity();
            obj.ForeNames = model.ForeNames;
            obj.SurName = model.SurName;
            obj.Gender = model.Gender;
            obj.CreatedOn = model.CreatedOn;
            obj.UpdatedOn = model.UpdatedOn;
            obj.MobileNo = model.MobileNo;
            obj.Id = model.Id;
            obj.Dob = model.Dob;
            obj.HomeNo = model.HomeNo;
            obj.WorkNo = model.WorkNo;
            return obj;
        }

    }
}