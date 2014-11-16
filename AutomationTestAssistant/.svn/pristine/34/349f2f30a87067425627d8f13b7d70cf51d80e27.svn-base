using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class AdditionalPathManager
    {
        public List<ATADataModel.AdditionalPath> GetAllAdditionalPathsByProjectId(ATAEntities context, int projectId)
        {
            IQueryable<ATADataModel.Project> projects = context.Projects.Where(p => p.ProjectId.Equals(projectId));
            var additionalPaths = projects.FirstOrDefault().AdditionalPaths;
            return additionalPaths.ToList();
        }

        public List<AdditionalPath> GetAll(ATAEntities context)
        {
            return context.AdditionalPaths.ToList();
        }

        public AdditionalPath GetByName(ATAEntities context, string tfsPath)
        {
            return context.AdditionalPaths.Where(a => a.TfsPath.Equals(tfsPath)).FirstOrDefault();
        }

        public void AddNew(ATAEntities context, string tfsPath, string tfsUrl)
        {
            AdditionalPath ap = new AdditionalPath()
            {
                TfsPath = tfsPath,
                TfsUrl = tfsUrl
            };
            context.AdditionalPaths.Add(ap);
            context.SaveChanges();
        }
    }
}
