using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNotebookCore.ViewModels
{
    public class ProjectEditViewModel
    {
        //public ProjectEditViewModel()
        //{
        //    this.ObservableTestPlans = new ObservableCollection<TestPlan>();
        //    ITestPlanCollection testPlanCores = TestPlanManager.GetAllTestPlans(ExecutionContext.TestManagementTeamProject);
        //    testPlanCores.ToList().ForEach(t => this.ObservableTestPlans.Add(new TestPlan(t)));
        //}

        ///// <summary>
        ///// Gets or sets the observable test plans.
        ///// </summary>
        ///// <value>
        ///// The observable test plans.
        ///// </value>
        //public ObservableCollection<TestPlan> ObservableTestPlans { get; set; }

        ///// <summary>
        ///// Deletes the test plan.
        ///// </summary>
        ///// <param name="testPlanToBeDeleted">The test plan automatic be deleted.</param>
        //public void DeleteTestPlan(TestPlan testPlanToBeDeleted)
        //{
        //    TestPlanManager.RemoveTestPlan(testPlanToBeDeleted.Id);
        //    this.ObservableTestPlans.Remove(testPlanToBeDeleted);
        //}

        ///// <summary>
        ///// Adds the test plan.
        ///// </summary>
        ///// <param name="name">The name.</param>
        //public void AddTestPlan(string name)
        //{
        //    TestPlan testPlanToBeAdded = TestPlanManager.CreateTestPlan(name);
        //    this.ObservableTestPlans.Add(testPlanToBeAdded);
        //}
    }
}
