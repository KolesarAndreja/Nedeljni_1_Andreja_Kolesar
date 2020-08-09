using Nedeljni1_Andreja_Kolesar.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nedeljni1_Andreja_Kolesar.Service
{
    class Service
    {
        #region get lists
        public static List<vwAdministrator> GetVwAdministratorList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<vwAdministrator> list = new List<vwAdministrator>();
                    list = (from x in context.vwAdministrators select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<vwManager> GetVwManagerList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<vwEmployee> GetVwEmployeeList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

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

        public static List<tblManager> GetManagerList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblManager> list = new List<tblManager>();
                    list = (from x in context.tblManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static List<tblAdminType> GetTypeAdminList()
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblAdminType> list = new List<tblAdminType>();
                    list = (from x in context.tblAdminTypes select x).ToList();
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

        #region VALIDATION
        public static bool UsedJmbg(string jmbg)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    bool b = (from x in context.tblUsers where x.jmbg == jmbg select x).Any();
                    return b;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return true;
            }
        }

        public static bool UsedUsername(string username)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    bool b = (from x in context.tblUsers where x.username == username select x).Any();
                    return b;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return true;
            }
        }

        public static bool UsedEmail(string mail)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    bool b = (from x in context.tblManagers where x.email == mail select x).Any();
                    return b;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return true;
            }
        }

        public static List<tblEmployee> UsedSector(tblSector sector)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    List<tblEmployee> list = (from x in context.tblEmployees where x.sectorId == sector.sectorId select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD USER
        public static tblUser AddUser(tblUser user)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    if (user.userId == 0)
                    {
                        //add 
                        tblUser newUser = new tblUser();
                        newUser.username = user.username;
                        newUser.password = user.password;
                        newUser.jmbg = user.jmbg;
                        newUser.genderId = user.genderId;
                        newUser.residence = user.residence;
                        newUser.marriageStatusId = user.marriageStatusId;
                        newUser.firstname = user.firstname;
                        newUser.lastname = user.lastname;
                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        user.userId = newUser.userId;
                        return user;
                    }
                    else
                    {
                        tblUser userToEdit = (from x in context.tblUsers where x.userId == user.userId select x).FirstOrDefault();
                        userToEdit.username = user.username;
                        userToEdit.lastname = user.lastname;
                        userToEdit.firstname = user.username;
                        userToEdit.residence = user.residence;
                        userToEdit.password = user.password;
                        userToEdit.marriageStatusId = user.marriageStatusId;
                        userToEdit.genderId = user.genderId;
                        userToEdit.jmbg = user.jmbg;
                        context.SaveChanges();
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD MANAGER

        public static tblManager AddManager(tblManager manager)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    if (manager.managerId == 0)
                    {
                        //add 
                        tblManager newManager = new tblManager();
                        newManager.officeNumber = manager.officeNumber;
                        newManager.successfulProjects = manager.successfulProjects;
                        newManager.email = manager.email;
                        newManager.backupPassword = manager.backupPassword;
                        newManager.userId = manager.userId;
                        context.tblManagers.Add(newManager);
                        context.SaveChanges();
                        manager.managerId = newManager.managerId;
                        return manager;
                    }
                    else
                    {
                        tblManager managerToEdit = (from x in context.tblManagers where  x.managerId== manager.managerId select x).FirstOrDefault();
                        managerToEdit.officeNumber = manager.officeNumber;
                        managerToEdit.levelOfResponsibility = manager.levelOfResponsibility;
                        managerToEdit.salary = manager.salary;
                        managerToEdit.successfulProjects = manager.successfulProjects;
                        managerToEdit.backupPassword = manager.backupPassword;
                        managerToEdit.email = manager.email;
                        managerToEdit.userId = manager.userId;
                        context.SaveChanges();
                        return manager;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD SECTOR

        public static tblSector AddSector(tblSector sector)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    if (sector.sectorId == 0)
                    {
                        //add 
                        tblSector newSector = new tblSector();
                        newSector.name = sector.name;
                        newSector.description = sector.description;
                        context.tblSectors.Add(newSector);
                        context.SaveChanges();
                        sector.sectorId = newSector.sectorId;
                    }
                    return sector;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD EMPLOYEE
        public static tblEmployee AddEmployee(tblEmployee employee)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    if (employee.employeeId == 0)
                    {
                        //add 
                        tblEmployee newEmployee = new tblEmployee();
                        newEmployee.qualificationsId = employee.qualificationsId;
                        newEmployee.sectorId = employee.sectorId;
                        if (employee.positionID!=0)
                        {
                            newEmployee.positionID = employee.positionID;
                        }
                        newEmployee.yearsOfService = employee.yearsOfService;
                        newEmployee.managerId = employee.managerId;
                        newEmployee.userID = employee.userID;
                        context.tblEmployees.Add(newEmployee);
                        context.SaveChanges();
                        employee.employeeId = newEmployee.employeeId;
                        return employee;
                    }
                    else
                    {
                        tblEmployee employeeToEdit = (from x in context.tblEmployees where x.employeeId == employee.employeeId select x).FirstOrDefault();
                        employeeToEdit.Salary = employee.Salary;
                        employeeToEdit.positionID = employee.positionID;
                        employeeToEdit.sectorId = employee.sectorId;
                        employeeToEdit.managerId = employee.managerId;
                        employeeToEdit.yearsOfService = employee.yearsOfService;
                        employeeToEdit.qualificationsId = employee.qualificationsId;
                        employeeToEdit.userID = employee.userID;
                        context.SaveChanges();
                        return employee;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region ADD ADMINISTRATOR
        public static tblAdministrator AddAdministrator(tblAdministrator admin)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    if (admin.administratorId == 0)
                    {
                        //add 
                        tblAdministrator newAdmin = new tblAdministrator();
                        newAdmin.adminTypeId = admin.adminTypeId;
                        //exipry date +7days
                        DateTime d = DateTime.Now;
                        d = d.AddDays(7);
                        newAdmin.expiryDate = d.Date;
                        newAdmin.userId = admin.userId;
                        context.tblAdministrators.Add(newAdmin);
                        context.SaveChanges();
                        admin.administratorId = newAdmin.administratorId;
                        return admin;
                    }
                    else
                    {
                        tblAdministrator adminToEdit = (from x in context.tblAdministrators where x.administratorId == admin.administratorId select x).FirstOrDefault();
                        adminToEdit.expiryDate = admin.expiryDate;
                        adminToEdit.adminTypeId = admin.adminTypeId;
                        adminToEdit.userId = admin.userId;
                        context.SaveChanges();
                        return admin;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }
            #endregion

        #region Get user,manager, employee, administrator

            public static tblUser GetUser(string username, string password)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblUser result = (from x in context.tblUsers where x.username == username && x.password == password select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        //null or manager
        public static tblManager isManager(tblUser e)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblManager result = (from x in context.tblManagers where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        //null or return employee
        public static tblEmployee isEmployee(tblUser e)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblEmployee result = (from x in context.tblEmployees where x.userID == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        //null or return administrator
        public static tblAdministrator isAdministrator(tblUser e)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblAdministrator result = (from x in context.tblAdministrators where x.userId == e.userId select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region Get type of admin, get admin by id
        public static string TypeOfAdmin(tblAdministrator a)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblAdminType result = (from x in context.tblAdminTypes where x.adminTypeId == a.adminTypeId select x).FirstOrDefault();
                    return result.name;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        public static tblAdministrator GetAdminById(int id)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblAdministrator result = (from x in context.tblAdministrators where x.administratorId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        public static tblManager GetManagerById(int id)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblManager result = (from x in context.tblManagers where x.managerId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        public static tblEmployee GetEmployeeById(int id)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblEmployee result = (from x in context.tblEmployees where x.employeeId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }
        #endregion

        #region delete sector
        public static void DeleteSector(tblSector sector)
        {
            try
            {
                using (dbFirmEntities context = new dbFirmEntities())
                {
                    tblSector sectorToDelete = (from u in context.tblSectors where u.sectorId == sector.sectorId select u).First();
                    //check if some employee uses this sector. Get list of all employees with this sectorId
                    List<tblEmployee> list = UsedSector(sector);
                    //if list is not empty, update users with default sector
                    if (list.Count > 0)
                    {
                        tblEmployee employeeToEdit;
                        for(int i=0; i<list.Count; i++)
                        {
                            employeeToEdit = list[i];
                            employeeToEdit.sectorId = 1;
                            AddEmployee(employeeToEdit);
                        }
                    }
                    context.tblSectors.Remove(sectorToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        #endregion
    }
}
