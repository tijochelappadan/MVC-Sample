using MVC.Models;
using MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MVC.Controllers
{
    public class DoctorSearchController : Controller
    {
        const int RecordsPerPage = 10;
        IDoctorSearch objIDoctorSearch;
        IDepartmentMaster objDepartment;
        IHospitalMaster objHospital;
        ILocationMaster objLocation;
        ILanguageMaster objLanguage;
        IReferenceType objReferenceType;

        public DoctorSearchController()
        {
            objIDoctorSearch = new DoctorSearch();
            objDepartment = new DepartmentMaster();
            objHospital = new HospitalMaster();
            objLocation = new LocationMaster();
            objLanguage = new LanguageMaster();
            objReferenceType = new ReferenceType();
        }

        public ActionResult DoctorSearch(DoctorMasterDTOVM model, string SearchButton)
        {
            if (model.FromDate < Convert.ToDateTime("01 Jan 2018"))
            {
                model.FromDate = DateTime.Now.Date;
                model.ToDate = DateTime.Now.Date;
            }

            List<DepartmentMasterDTO> listDepartment = new List<DepartmentMasterDTO>();
            listDepartment = new List<DepartmentMasterDTO>()
            {
                new DepartmentMasterDTO { DepartmentID = 0, Department ="Select"}
            };

            foreach (var item in objDepartment.GetDepartment())
            {
                DepartmentMasterDTO sm = new DepartmentMasterDTO();
                sm.DepartmentID = item.DepartmentID;
                sm.Department = item.Department;

                listDepartment.Add(sm);
            }

            model.ListDepartment = listDepartment;

            List<HospitalMasterDTO> listHospital = new List<HospitalMasterDTO>();
            listHospital = new List<HospitalMasterDTO>()
            {
                new HospitalMasterDTO { HospitalID = 0, Hospital ="Select"}
            };

            foreach (var item in objHospital.GetHospital())
            {
                HospitalMasterDTO sm = new HospitalMasterDTO();
                sm.HospitalID = item.HospitalID;
                sm.Hospital = item.Hospital;

                listHospital.Add(sm);
            }

            model.ListHospital = listHospital;

            List<LocationMasterDTO> listLocation = new List<LocationMasterDTO>();
            listLocation = new List<LocationMasterDTO>()
            {
                new LocationMasterDTO { LocationID = 0, Location ="Select"}
            };

            foreach (var item in objLocation.GetLocation())
            {
                LocationMasterDTO sm = new LocationMasterDTO();
                sm.LocationID = item.LocationID;
                sm.Location = item.Location;

                listLocation.Add(sm);
            }

            model.ListLocation = listLocation;

            List<LanguageMasterDTO> listLanguage = new List<LanguageMasterDTO>();
            listLanguage = new List<LanguageMasterDTO>()
            {
                new LanguageMasterDTO { LanguageID = 0, Language ="Select"}
            };

            foreach (var item in objLanguage.GetLanguage())
            {
                LanguageMasterDTO sm = new LanguageMasterDTO();
                sm.LanguageID = item.LanguageID;
                sm.Language = item.Language;

                listLanguage.Add(sm);
            }

            model.ListLanguage = listLanguage;

            List<ReferenceTypeDTO> listReferenceType = new List<ReferenceTypeDTO>();
            listReferenceType = new List<ReferenceTypeDTO>()
            {
                new ReferenceTypeDTO { ReferenceTypeID = 0, ReferenceTypeName ="Select"}
            };

            foreach (var item in objReferenceType.GetReferenceType())
            {
                ReferenceTypeDTO sm = new ReferenceTypeDTO();
                sm.ReferenceTypeID = item.ReferenceTypeID;
                sm.ReferenceTypeName = item.ReferenceTypeName;

                listReferenceType.Add(sm);
            }

            model.ListReferenceType = listReferenceType;

            if (!string.IsNullOrEmpty(model.SearchButton))
            {
                var ListDoctors = objIDoctorSearch.GetDoctorSearch(Convert.ToString(model.Location), Convert.ToInt32(model.ReferenceTypeID),
                        Convert.ToString(model.ReferenceName), Convert.ToDateTime(model.FromDate).Date, Convert.ToDateTime(model.ToDate).Date, 
                        Convert.ToInt32(model.LanguageID));
                var ListDoctorsCH = objIDoctorSearch.GetDoctorSearchConsultationHours(Convert.ToString(model.Location), Convert.ToInt32(model.ReferenceTypeID),
                        Convert.ToString(model.ReferenceName), Convert.ToDateTime(model.FromDate).Date, Convert.ToDateTime(model.ToDate).Date, 
                        Convert.ToInt32(model.LanguageID));
                var pageIndex = model.Page ?? 1;
                model.SearchResults = ListDoctors.ToPagedList(pageIndex, RecordsPerPage);
                model.SearchResultsConsultHours = ListDoctorsCH;
            }

            return View(model);
        }

        public ActionResult Search(DoctorMasterDTOVM model, string SearchButton)
        {
            if (model.FromDate < Convert.ToDateTime("01 Jan 2018"))
            {
                model.FromDate = DateTime.Now.Date;
                model.ToDate = DateTime.Now.Date;
            }

            List<DepartmentMasterDTO> listDepartment = new List<DepartmentMasterDTO>();
            listDepartment = new List<DepartmentMasterDTO>()
            {
                new DepartmentMasterDTO { DepartmentID = 0, Department ="Select"}
            };

            foreach (var item in objDepartment.GetDepartment())
            {
                DepartmentMasterDTO sm = new DepartmentMasterDTO();
                sm.DepartmentID = item.DepartmentID;
                sm.Department = item.Department;

                listDepartment.Add(sm);
            }

            model.ListDepartment = listDepartment;

            List<HospitalMasterDTO> listHospital = new List<HospitalMasterDTO>();
            listHospital = new List<HospitalMasterDTO>()
            {
                new HospitalMasterDTO { HospitalID = 0, Hospital ="Select"}
            };

            foreach (var item in objHospital.GetHospital())
            {
                HospitalMasterDTO sm = new HospitalMasterDTO();
                sm.HospitalID = item.HospitalID;
                sm.Hospital = item.Hospital;

                listHospital.Add(sm);
            }

            model.ListHospital = listHospital;

            List<LocationMasterDTO> listLocation = new List<LocationMasterDTO>();
            listLocation = new List<LocationMasterDTO>()
            {
                new LocationMasterDTO { LocationID = 0, Location ="Select"}
            };

            foreach (var item in objLocation.GetLocation())
            {
                LocationMasterDTO sm = new LocationMasterDTO();
                sm.LocationID = item.LocationID;
                sm.Location = item.Location;

                listLocation.Add(sm);
            }

            model.ListLocation = listLocation;

            List<LanguageMasterDTO> listLanguage = new List<LanguageMasterDTO>();
            listLanguage = new List<LanguageMasterDTO>()
            {
                new LanguageMasterDTO { LanguageID = 0, Language ="Select"}
            };

            foreach (var item in objLanguage.GetLanguage())
            {
                LanguageMasterDTO sm = new LanguageMasterDTO();
                sm.LanguageID = item.LanguageID;
                sm.Language = item.Language;

                listLanguage.Add(sm);
            }

            model.ListLanguage = listLanguage;

            List<ReferenceTypeDTO> listReferenceType = new List<ReferenceTypeDTO>();
            listReferenceType = new List<ReferenceTypeDTO>()
            {
                new ReferenceTypeDTO { ReferenceTypeID = 0, ReferenceTypeName ="Select"}
            };

            foreach (var item in objReferenceType.GetReferenceType())
            {
                ReferenceTypeDTO sm = new ReferenceTypeDTO();
                sm.ReferenceTypeID = item.ReferenceTypeID;
                sm.ReferenceTypeName = item.ReferenceTypeName;

                listReferenceType.Add(sm);
            }

            model.ListReferenceType = listReferenceType;

            if (!string.IsNullOrEmpty(model.SearchButton))
            {
                var ListDoctors = objIDoctorSearch.GetDoctorSearch(Convert.ToString(model.DoctorName), Convert.ToInt32(model.ReferenceTypeID),
                        Convert.ToString(model.ReferenceName), Convert.ToDateTime(model.FromDate), Convert.ToDateTime(model.ToDate), Convert.ToInt32(model.LanguageID));
                var ListDoctorsCH = objIDoctorSearch.GetDoctorSearchConsultationHours(Convert.ToString(model.DoctorName), Convert.ToInt32(model.ReferenceTypeID),
                        Convert.ToString(model.ReferenceName), Convert.ToDateTime(model.FromDate), Convert.ToDateTime(model.ToDate), Convert.ToInt32(model.LanguageID));
                var pageIndex = model.Page ?? 1;
                model.SearchResults = ListDoctors.ToPagedList(pageIndex, RecordsPerPage);
                model.SearchResultsConsultHours = ListDoctorsCH;
            }

            return View(model);
        }

        public JsonResult GetDatabyDoctorName(string term)
        {
            var list = objIDoctorSearch.DoctorAutoComplete(term);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetReference(string term)
        {
            var list = objIDoctorSearch.ReferenceAutoComplete(0, term);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}