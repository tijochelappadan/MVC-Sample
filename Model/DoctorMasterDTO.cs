using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using PagedList;

namespace MVC.Models
{
    public class DoctorMasterDTO
    {
        [Key]
        public int DoctorID { get; set; }
        [Remote("DoctornameExists", "Doctor", ErrorMessage = "Doctor Name Already Exists ")]
        [Required(ErrorMessage = "Enter Doctor Name")]
        public string DoctorName { get; set; }

        [Display(Name = "Department")]
        [ValidateDepartment_Doctor(ErrorMessage = "Select Department")]
        public int DepartmentID { get; set; }

        [Display(Name = "Hospital")]
        [ValidateHospital_Doctor(ErrorMessage = "Select Hospital")]
        public int HospitalID { get; set; }

        [Display(Name = "Location")]
        [ValidateLocation_Doctor(ErrorMessage = "Select Location")]
        public int LocationID { get; set; }

        [Display(Name = "Language")]
        [ValidateLanguage_Doctor(ErrorMessage = "Select Language")]
        public int LanguageID { get; set; }

        public string ConsultationHours { get; set; }
        public string Department { get; set; }
        public string Hospital { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public int UserID { get; set; }

        public IEnumerable<DepartmentMasterDTO> ListDepartment { get; set; }
        public IEnumerable<HospitalMasterDTO> ListHospital { get; set; }
        public IEnumerable<LocationMasterDTO> ListLocation { get; set; }
        public IEnumerable<LanguageMasterDTO> ListLanguage { get; set; }        
    }

    public class ValidateDepartment_Doctor : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == null)
                return false;
            else
                return true;
        }
    }

    public class ValidateHospital_Doctor : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == null)
                return false;
            else
                return true;
        }
    }

    public class ValidateLocation_Doctor : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == null)
                return false;
            else
                return true;
        }
    }

    public class ValidateLanguage_Doctor : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == null)
                return false;
            else
                return true;
        }
    }

    public class DoctorAutocompDTO
    {
        public string DoctorName { get; set; }
        public int MainDoctorID { get; set; }
        public string Name { get; set; }
    }

    public class ReferenceAutoCompleteDTO
    {
        public string ReferenceName { get; set; }
        public int MainReferenceID { get; set; }
        public string Name { get; set; }
    }

    public class DoctorMasterDTOVM
    {
        public int? Page { get; set; }
        public IPagedList<DoctorMasterDTO> SearchResults { get; set; }
        public IEnumerable<DoctorMasterDTOVMConsultHours> SearchResultsConsultHours { get; set; }
        public string SearchButton { get; set; }
        public string DoctorSearch { get; set; }
        public string DoctorName { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        [Display(Name = "Hospital")]
        public int? HospitalID { get; set; }
        [Display(Name = "Location")]
        public int? LocationID { get; set; }
        [Display(Name = "Select Language")]

        public int? LanguageID { get; set; }
        public string Department { get; set; }
        public string Hospital { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }

        public IEnumerable<DepartmentMasterDTO> ListDepartment { get; set; }
        public IEnumerable<HospitalMasterDTO> ListHospital { get; set; }
        public IEnumerable<LocationMasterDTO> ListLocation { get; set; }
        public IEnumerable<LanguageMasterDTO> ListLanguage { get; set; }
        public IEnumerable<ReferenceTypeDTO> ListReferenceType { get; set; }

        public int? ReferenceTypeID { get; set; }
        public string ReferenceTypeName { get; set; }
        public string ReferenceName { get; set; }
        
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Select From Date")]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
    }

    public class DoctorMasterDTOVMConsultHours
    {
        public int DoctorID { get; set; }
        public DateTime ConsultingDate { get; set; }
        public string ConsultingTime { get; set; }
        public int StatusID { get; set; }
    }
}