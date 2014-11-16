
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class TestManager
    {
        public List<Test> GetAllTestsByProjectName(ATAEntities context, string projectName)
        {
            ATADataModel.Project p = ATACore.Managers.ProjectManager.GetByName(context, projectName);
            List<Test> tests = p.Tests.Where(t => t.DeletionDate.Equals(DateTime.MinValue)).ToList();

            return tests;
        }

        public void AddNewTest(ATAEntities context, int projectId, Test testToAdd)
        {
            ATADataModel.Project p = ATACore.Managers.ProjectManager.GetById(context, projectId);
            testToAdd.AdditionDate = DateTime.Now;
            p.Tests.Add(testToAdd);
            context.SaveChanges();
        }

        public Test GetTestByMethodId(ATAEntities context, string methodId)
        {
            Test test = context.Tests.Where(t => t.MethodId.Equals(methodId)).FirstOrDefault();

            return test;
        }

        public Test GetTestByTestId(ATAEntities context, int testId)
        {
            Test test = context.Tests.Where(t => t.TestId.Equals(testId)).FirstOrDefault();

            return test;
        }

        public void RemoveTest(ATAEntities context, int projectId, Test testToRemove)
        {
            ATADataModel.Project p = ATACore.Managers.ProjectManager.GetById(context, projectId);
            testToRemove.DeletionDate = DateTime.Now;
            context.SaveChanges();
        }
    }
}
