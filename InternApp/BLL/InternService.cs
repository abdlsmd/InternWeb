using InternApp.DAL;
using InternApp.Models;

namespace InternApp.BLL
{
    public class InternService
    {
        private readonly InternRepository _repository;

        public InternService(InternRepository repository)
        {
            _repository = repository;
        }

        public List<Intern> GetInterns()
        {
            return _repository.GetInterns();
        }

        public Intern GetInternById(int id)
        {
            return _repository.GetInternById(id);
        }

        public void AddIntern(Intern intern)
        {
            _repository.AddIntern(intern);
        }

        public void UpdateIntern(Intern intern)
        {
            _repository.UpdateIntern(intern);
        }

        public void DeleteIntern(int id)
        {
            _repository.DeleteIntern(id);
        }
    }
}
