using Project220723.Models;

namespace Project220723.Repository
{
    public interface InterfaceProfResearcher
    {
        public ResponseModel GetResearcherList();
        public ResponseModel GetProfessorList();
        public ResponseModel PostResearcherData(ResearcherModel data);
        public ResponseModel PostProfessorData(ResearcherModel data);

        public ResponseModel DeleteResearcher(int id);
        public ResponseModel DeleteProfessor(int id);
        public ResponseModel GetResearcherById(int id);
        public ResponseModel GetProfessorById(int id);
    }
}
