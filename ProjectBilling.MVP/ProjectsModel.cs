using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBilling.Business
{
    #region ProjectsEventArgs

    public class ProjectEventArgs : EventArgs
    {
        public Project Project { get; set; }
        public ProjectEventArgs(Project project)
        {
            Project = project;
        }
    }

    #endregion ProjectsEventArgs

    public interface IProjectsModel
    {
        void UpdateProject(Project project);
        IEnumerable<Project> GetProjects();
        Project GetProject(int Id);
        event EventHandler<ProjectEventArgs> ProjectUpdated;
    }

    public class ProjectsModel : IProjectsModel
    {
        private IEnumerable<Project> projects = null;

        public event EventHandler<ProjectEventArgs>
            ProjectUpdated = delegate { };

        public ProjectsModel()
        {
            projects = new DataServiceStub().GetProjects();
        }

        public void UpdateProject(Project project)
        {
            ProjectUpdated(this,
                new ProjectEventArgs(project));
        }

        public IEnumerable<Project> GetProjects()
        {
            return projects;
        }


        public Project GetProject(int Id)
        {
            return projects.Where(p => p.ID == Id)
                .First() as Project;
        }
    }

}
