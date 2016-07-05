using ProjectBilling.Business;
using ProjectBilling.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectBilling.UI.MVP
{
    public class ProjectsPresenter
    {
        #region Initialization

        private IProjectsView view = null;
        private IProjectsModel model = null;


        public ProjectsPresenter(IProjectsView projectsView,
    IProjectsModel projectsModel)
        {
            view = projectsView;
            view.ProjectUpdated += view_ProjectUpdated;
            view.SelectionChanged
                += view_SelectionChanged;
            view.DetailsUpdated += view_DetailsUpdated;
            model = projectsModel;
            model.ProjectUpdated += model_ProjectUpdated;
            view.LoadProjects(
                model.GetProjects());
        }

        #endregion Initialization

        #region Event handlers

        private void view_DetailsUpdated(object sender,
     ProjectEventArgs e)
        {
            SetEstimatedColor(e.Project);
        }


        private void view_SelectionChanged(object sender,
    EventArgs e)
        {
            int selectedId = view.SelectedProjectId;
            if (selectedId > view.NONE_SELECTED)
            {
                Project project =
                    model.GetProject(selectedId);
                view.EnableControls(true);
                view.UpdateDetails(project);
                SetEstimatedColor(project);
            }
            else
            {
                view.EnableControls(false);
            }
        }

        private void model_ProjectUpdated(object sender,
    ProjectEventArgs e)
        {
            view.UpdateProject(e.Project);
        }

        private void view_ProjectUpdated(object sender,
     ProjectEventArgs e)
        {
            model.UpdateProject(e.Project);
            SetEstimatedColor(e.Project);
        }

        #endregion Event handlers

        #region Helpers

        private void SetEstimatedColor(Project project)
        {
            if (project.ID == view.SelectedProjectId)
            {
                if (project.Actual <= 0)
                {
                    view.SetEstimatedColor(null);
                }
                else if (project.Actual 
                         > project.Estimate)
                {
                    view.SetEstimatedColor(Colors.Red);
                }
                else
                {
                    view.SetEstimatedColor(Colors.Green);
                }
            }
        }

        #endregion Helpers
    }
}
