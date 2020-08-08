using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni1_Andreja_Kolesar.Service
{
    class Service
    {
        #region get lists
        public static List<tblSector> GetSectorList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblSector> list = new List<tblSector>();
                    list = (from x in context.tblSectors select x).ToList();

                    //remove default item
                    list.RemoveAt(0);
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<tblGender> GetGenderList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblGender> list = new List<tblGender>();
                    list = (from x in context.tblGenders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<tblMarriageStatu> GetMaritalStatusList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblMarriageStatu> list = new List<tblMarriageStatu>();
                    list = (from x in context.tblMarriageStatus select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<tblPosition> GetPositionList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblPosition> list = new List<tblPosition>();
                    list = (from x in context.tblPositions select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<tblProfessionalQualification> GetQualificationList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblProfessionalQualification> list = new List<tblProfessionalQualification>();
                    list = (from x in context.tblProfessionalQualifications select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        #endregion
    }
}
