using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNotebookDataModel;

namespace TreeNotebookCore.Managers
{
    /// <summary>
    /// Retriev Project entities from DB
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public List<Project> GetAll(TreeNotebookEntities context)
        {
            return context.Projects.ToList();
        }

        /// <summary>
        /// Gets the name of the by.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Project GetByName(TreeNotebookEntities context, string name)
        {
            return context.Projects.Where(p => p.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectId">The project unique identifier.</param>
        /// <returns></returns>
        public Project GetById(TreeNotebookEntities context, int projectId)
        {
            return context.Projects.Where(p => p.ProjectId.Equals(projectId)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the main node by project unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectId">The project unique identifier.</param>
        /// <returns>the found main node</returns>
        public Node GetMainNodeByProjectId(TreeNotebookEntities context, int projectId)
        {
            ProjectsNode currentProjectNode = context.ProjectsNodes.Where(p => p.ProjectId == projectId).FirstOrDefault();
            Node resultNode = context.Nodes.Where(p => p.NodeId == currentProjectNode.NodeId).FirstOrDefault();
            return resultNode;
        }

        /// <summary>
        /// Adds the new.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectName">Name of the project.</param>
        public void AddNew(TreeNotebookEntities context, string projectName)
        {
            Project project = new Project()
            {
                Name = projectName,
            };

            context.Projects.Add(project);
            context.SaveChanges();
        }

        /// <summary>
        /// Removes the project by unique identifier.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="projectId">The project unique identifier.</param>
        public void RemoveProjectById(TreeNotebookEntities context, int projectId)
        {
            Project projectForRemove = GetById(context, projectId);
            context.Projects.Remove(projectForRemove);

            context.SaveChanges();
        }
    }
}
