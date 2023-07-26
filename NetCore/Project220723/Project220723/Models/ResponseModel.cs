namespace Project220723.Models
{
    public class ResponseModel
    {
        public List<RolesModel> Roles { get; set; }
        public string Message { get; set; }
        public List<ResearcherModel> GetResearcherList { get; set; }
        public ResearcherModel GetResearcher { get; set; }
        public List<ProfessorModel> GetProfessorList { get; set; }
        public ProfessorModel GetProfessor { get; set; }
        public string token { get; set; }
    }
    public class ResearcherModel
    {
        public int? RoleId { get; set; }
        public int ResId { get; set; }
        public string? RoleName { get; set; }
        public string? ResName { get; set; }
        public string? ResEmail { get; set; }
        public string? ResUserName { get; set; }
        public string? password { get; set; }
    }

    public class ProfessorModel
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int ProfId { get; set; }
        public string? ProfName { get; set; }
        public string? ProfEmail { get; set; }
        public string? ProfUserName { get; set; }
        public string? password { get; set; }
    }

}
