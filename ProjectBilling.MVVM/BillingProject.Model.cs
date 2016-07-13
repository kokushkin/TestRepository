using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBilling.Application
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(
            string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface IProjectsModel
    {
        IEnumerable<IProject> Projects { get; set; }
        event EventHandler<ProjectEventArgs> ProjectUpdated;
        void UpdateProject(IProject updatedProject);
    }


    public class ProjectEventArgs : EventArgs
    {
        public IProject Project { get; set; }
        public ProjectEventArgs(IProject project)
        {
            Project = project;
        }
    }

    public class ProjectsModel : IProjectsModel
    {
        public IEnumerable<IProject> Projects 
        { 
            get
            {
                return _projects;
            }
            
            set
            {
                _projects = value.ToList();
            }
        }
        private List<IProject> _projects;

        public event EventHandler<ProjectEventArgs> ProjectUpdated = delegate { };

        public ProjectsModel(IDataService dataService)
        {
            _projects = new List<IProject>();
            foreach (Project project in dataService.GetProjects())
            {
                _projects.Add(project);
            }
        }

        public void UpdateProject(IProject updatedProject)
        {
            GetProject(updatedProject.ID).Update(updatedProject);
            ProjectUpdated(this,
                new ProjectEventArgs(updatedProject));
        }

        private IProject GetProject(int projectId)
        {
            return _projects.FirstOrDefault(
                project => project.ID == projectId);
        }
    }
}
