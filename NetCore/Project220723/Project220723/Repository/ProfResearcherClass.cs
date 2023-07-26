using Project220723.Models;

namespace Project220723.Repository
{
    public class ProfResearcherClass:InterfaceProfResearcher
    {
        public readonly sdirectdbContext dbContext;
        public ProfResearcherClass(sdirectdbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get for researcher
        public ResponseModel GetResearcherList()
        {
            ResponseModel responseModel = new ResponseModel();

            var data = (from e in dbContext.PraveenResearchers 
                        join a in dbContext.PraveenLoginCredentials on e.ResUserName equals a.UserName
                        join role in dbContext.PraveenUserRoleMappers on a.UserId equals role.UserId
                        join roles in dbContext.PraveenRoles on role.RoleId equals roles.RoleId
                        where e.IsDeleted == false
                        select new ResearcherModel
                        {
             
                            RoleId = role.RoleId,
                            ResId=e.ResId,
                            RoleName=roles.RolesName,
                            ResName=e.ResName,
                            ResEmail=e.ResEmail,
                            ResUserName=e.ResUserName,
                            password=a.Password
                        }).ToList();
            responseModel.GetResearcherList = data;
            return responseModel;
        }

        //post and update for researcher
        public ResponseModel PostResearcherData(ResearcherModel data)
        {
            ResponseModel responseModel = new ResponseModel();
            PraveenLoginCredential loginCredential = new PraveenLoginCredential();
            PraveenResearcher praveenResearcher = new PraveenResearcher();
            PraveenUserRoleMapper mapper = new PraveenUserRoleMapper();
            try
            {
                if (data.ResId == 0)
                {
                    var userName = dbContext.PraveenResearchers.Where(i => i.ResUserName == data.ResUserName).FirstOrDefault();
                    if (userName == null)
                    {
                        //saving credenetials
                        loginCredential.UserName = data.ResUserName;
                        loginCredential.Password = data.password;
                        dbContext.PraveenLoginCredentials.Add(loginCredential);
                        dbContext.SaveChanges();
                        //mapping saved credential with role
                        var ResId = dbContext.PraveenLoginCredentials.Where(i => i.UserName == data.ResUserName).FirstOrDefault();
                        mapper.UserId = ResId.UserId;
                        mapper.RoleId = 2;
                        dbContext.PraveenUserRoleMappers.Add(mapper);
                        dbContext.SaveChanges();
                        //saving other data to researcher table
                        praveenResearcher.CreatedOn = DateTime.Now;
                        praveenResearcher.ResEmail = data.ResEmail;
                        praveenResearcher.ResUserName = data.ResUserName;
                        praveenResearcher.ResName = data.ResName;
                        dbContext.PraveenResearchers.Add(praveenResearcher);
                        dbContext.SaveChanges();
                        responseModel.Message = "Added Successfully";
                    }
                    else
                    {
                        responseModel.Message = "Username already exist";
                    }
                }
                else if(data.ResId>0)
                {
                    var data1=dbContext.PraveenResearchers.Where(i=>i.ResId==data.ResId).FirstOrDefault();

                    data1.ResEmail = data.ResEmail;
                    data1.ResName = data.ResName;
                    dbContext.SaveChanges();
                    responseModel.Message = "Updated Successfully";
                }
            }
            catch(Exception ex)
            {
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }
        //get for professor
        public ResponseModel GetProfessorList()
        {
            ResponseModel responseModel = new ResponseModel();

            var data = (from e in dbContext.PraveenProfessors
                        join a in dbContext.PraveenLoginCredentials on e.ProfUserName equals a.UserName
                        join role in dbContext.PraveenUserRoleMappers on a.UserId equals role.UserId
                        join roles in dbContext.PraveenRoles on role.RoleId equals roles.RoleId where e.IsDeleted==false
                        select new ProfessorModel
                        {
                            RoleId = role.RoleId,
                            ProfId = e.ProfId,
                            RoleName = roles.RolesName,
                            ProfName = e.ProfName,
                            ProfEmail = e.ProfEmail,
                            ProfUserName = e.ProfUserName,
                            password = a.Password
                        }).ToList();
            responseModel.GetProfessorList = data;
            return responseModel;
        }
        //post and update for professor
        public ResponseModel PostProfessorData(ResearcherModel data)
        {
            ResponseModel responseModel = new ResponseModel();
            PraveenLoginCredential loginCredential = new PraveenLoginCredential();
            PraveenProfessor praveenProfessor = new PraveenProfessor();
            PraveenUserRoleMapper mapper = new PraveenUserRoleMapper();
            try
            {
                if (data.ResId == 0)
                {
                    var userName = dbContext.PraveenResearchers.Where(i => i.ResUserName == data.ResUserName).FirstOrDefault();
                    if (userName == null)
                    {
                        //saving credenetials
                        loginCredential.UserName = data.ResUserName;
                        loginCredential.Password = data.password;
                        dbContext.PraveenLoginCredentials.Add(loginCredential);
                        dbContext.SaveChanges();
                        //mapping saved credential with role
                        var ResId = dbContext.PraveenLoginCredentials.Where(i => i.UserName == data.ResUserName).FirstOrDefault();
                        mapper.UserId = ResId.UserId;
                        mapper.RoleId = 1;
                        dbContext.PraveenUserRoleMappers.Add(mapper);
                        dbContext.SaveChanges();
                        //saving other data to professor table
                        praveenProfessor.CreatedOn = DateTime.Now;
                        praveenProfessor.ProfEmail = data.ResEmail;
                        praveenProfessor.ProfUserName = data.ResUserName;
                        praveenProfessor.ProfName = data.ResName;
                        dbContext.PraveenProfessors.Add(praveenProfessor);
                        dbContext.SaveChanges();
                        responseModel.Message = "Added Successfully";
                    }
                    else
                    {
                        responseModel.Message = "Username already exist";
                    }
                }
                else if (data.ResId > 0)
                {
                    var data1 = dbContext.PraveenProfessors.Where(i => i.ProfId == data.ResId).FirstOrDefault();

                    data1.ProfEmail = data.ResEmail;
                    data1.ProfName = data.ResName;
                    dbContext.SaveChanges();
                    responseModel.Message = "Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                responseModel.Message = ex.Message;
            }
            return responseModel;
        }

        //deleting from reseracher

        public ResponseModel DeleteResearcher(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            PraveenLoginCredential praveenLoginCredential = new PraveenLoginCredential();
            try
            {
                if(id > 0)
                {
                    var data2 = dbContext.PraveenResearchers.Where(i=>i.ResId == id).FirstOrDefault(); 
                    if (data2 != null)
                    {
                        data2.IsDeleted = true;
                        dbContext.SaveChanges();
                        var username = dbContext.PraveenResearchers.Where(i => i.ResId == id).FirstOrDefault();
                        if (username != null)
                        {
                            var data3 = dbContext.PraveenLoginCredentials.Where(i => i.UserName == username.ResUserName).FirstOrDefault();
                            if (data3 != null)
                            {
                                data3.IsDeleted = true;
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                responseModel.Message = "Username doesn't exist on login table";
                            }
                        }
                        responseModel.Message = "Deleted Succesfully";
                    }
                    else
                    {
                        responseModel.Message = "User not found";
                    }
                }
            }
            catch (Exception e)
            {
                responseModel.Message = e.Message;
            }
            return responseModel;
        }

        //deleting ffrom professor

        public ResponseModel DeleteProfessor(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            PraveenLoginCredential praveenLoginCredential = new PraveenLoginCredential();
            try
            {
                if (id > 0)
                {
                    var data2 = dbContext.PraveenProfessors.Where(i => i.ProfId == id).FirstOrDefault();
                    
                    if (data2 != null)
                    {
                        data2.IsDeleted = true;
                        dbContext.SaveChanges();
                        var username=dbContext.PraveenProfessors.Where(i=>i.ProfId==id).FirstOrDefault();
                        if (username != null)
                        {
                            var data3 = dbContext.PraveenLoginCredentials.Where(i => i.UserName == username.ProfUserName).FirstOrDefault();
                            if (data3 != null)
                            {
                                data3.IsDeleted = true;
                                dbContext.SaveChanges();
                            }
                            else
                            {
                                responseModel.Message = "Username doesn't exist on login table";
                            }
                        }
                        responseModel.Message = "Deleted Succesfully";
                    }
                    else
                    {
                        responseModel.Message = "User not found";
                    }
                }
            }
            catch (Exception e)
            {
                responseModel.Message = e.Message;
            }
            return responseModel;
        }

        public ResponseModel GetResearcherById(int id)
        {
            ResponseModel responseModel = new ResponseModel();

            var data = (from e in dbContext.PraveenResearchers
                        join a in dbContext.PraveenLoginCredentials on e.ResUserName equals a.UserName
                        join role in dbContext.PraveenUserRoleMappers on a.UserId equals role.UserId
                        join roles in dbContext.PraveenRoles on role.RoleId equals roles.RoleId
                        where e.IsDeleted == false && e.ResId==id
                        select new ResearcherModel
                        {

                            RoleId = role.RoleId,
                            ResId = e.ResId,
                            RoleName = roles.RolesName,
                            ResName = e.ResName,
                            ResEmail = e.ResEmail,
                            ResUserName = e.ResUserName,
                            password = a.Password
                        }).FirstOrDefault();
            responseModel.GetResearcher = data;
            return responseModel;
        }
        public ResponseModel GetProfessorById(int id)
        {
            ResponseModel responseModel = new ResponseModel();

            var data = (from e in dbContext.PraveenProfessors
                        join a in dbContext.PraveenLoginCredentials on e.ProfUserName equals a.UserName
                        join role in dbContext.PraveenUserRoleMappers on a.UserId equals role.UserId
                        join roles in dbContext.PraveenRoles on role.RoleId equals roles.RoleId
                        where e.IsDeleted == false && e.ProfId==id
                        select new ProfessorModel
                        {
                            RoleId = role.RoleId,
                            ProfId = e.ProfId,
                            RoleName = roles.RolesName,
                            ProfName = e.ProfName,
                            ProfEmail = e.ProfEmail,
                            ProfUserName = e.ProfUserName,
                            password = a.Password
                        }).FirstOrDefault();
            responseModel.GetProfessor = data;
            return responseModel;
        }
    }

}
