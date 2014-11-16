using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AntaresFramework.Core.Managers;
using FirstFloor.ModernUI.Windows.Controls;
using TreeNotebookCore.ViewModels;

namespace TreeNotebook
{
    /// <summary>
    /// Interaction logic for ProjectEditView.xaml
    /// </summary>
    public partial class ProjectEditView : UserControl
    {
           /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
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

        /// <summary>
        /// Adds the test plan.
        /// </summary>
        /// <param name="name">The name.</param>
        public void AddTestPlan(string name)
        {
            //TestPlan testPlanToBeAdded = TestPlanManager.CreateTestPlan(name);
            //this.ObservableTestPlans.Add(testPlanToBeAdded);
        }
        public ProjectEditView()
        {
            InitializeComponent();
        }

          /// <summary>
        /// Indicates if the view model is already initialized
        /// </summary>
        private static bool isInitialized;


        public ProjectEditViewModel ProjectEditViewModel { get; set; }

        /// <summary>
        /// Called when navigation to a content fragment begins.
        /// </summary>
        /// <param name="e">An object that contains the navigation data.</param>
        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {   
        }

        /// <summary>
        /// Called when this instance is no longer the active content in a frame.
        /// </summary>
        /// <param name="e">An object that contains the navigation data.</param>
        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// Called when a this instance becomes the active content in a frame.
        /// </summary>
        /// <param name="e">An object that contains the navigation data.</param>
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            isInitialized = false;
        }

        /// <summary>
        /// Called just before this instance is no longer the active content in a frame.
        /// </summary>
        /// <param name="e">An object that contains the navigation data.</param>
        /// <remarks>
        /// The method is also invoked when parent frames are about to navigate.
        /// </remarks>
        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }

        /// <summary>
        /// Handles the Loaded event of the TestCaseExecutionArrangmentView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TestCaseExecutionArrangmentView_Loaded(object sender, RoutedEventArgs e)
        {
            if (isInitialized)
            {
                return;
            }
            this.ShowProgressBar();
            Task t = Task.Factory.StartNew(() =>
            {
                this.ProjectEditViewModel = new ProjectEditViewModel();
            });
            t.ContinueWith(antecedent =>
            {
                this.DataContext = this.ProjectEditViewModel;          
                this.HideProgressBar();
                isInitialized = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        private void HideProgressBar()
        {
            progressBar.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.Visibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// Shows the progress bar.
        /// </summary>
        private void ShowProgressBar()
        {
            progressBar.Visibility = System.Windows.Visibility.Visible;
            mainGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Displays the non selection warning.
        /// </summary>
        private void DisplayNonSelectionWarning()
        {
            ModernDialog.ShowMessage("No selected test plan.", "Warning", MessageBoxButton.OK);
        }

        /// <summary>
        /// Handles the Click event of the btnAddTestPlan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddTestPlan_Click(object sender, RoutedEventArgs e)
        {
                 RegistryManager.WriteTitleTitlePromtDialog(string.Empty);
            var dialog = new PrompDialogWindow();
            dialog.ShowDialog();

            bool isCanceled;
            string newTitle;
            Task t = Task.Factory.StartNew(() =>
            {
                isCanceled = RegistryManager.GetIsCanceledPromtDialog();
                newTitle = RegistryManager.GetContentPromtDialog();
                while (string.IsNullOrEmpty(newTitle) && !isCanceled)
                {
                }
            });
            t.Wait();
            isCanceled = RegistryManager.GetIsCanceledPromtDialog();
            newTitle = RegistryManager.GetContentPromtDialog();

            if (!isCanceled)
            {
                log.InfoFormat("Add New Test Plan with Name=\"{0}\"", newTitle);
                //this.ProjectEditViewModel.AddTestPlan(newTitle);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteTestPlan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeleteTestPlan_Click(object sender, RoutedEventArgs e)
        {
            //if (dgTestPlans.SelectedItems.Count == 0)
            //{
            //    this.DisplayNonSelectionWarning();
            //    return;
            //}
            //List<TestPlan> testPlansToBeDeleted = new List<TestPlan>();
            //foreach (TestPlan currentTestPlan in dgTestPlans.SelectedItems)
            //{
            //    testPlansToBeDeleted.Add(currentTestPlan);               
            //}
            //foreach (TestPlan currentTestPlan in testPlansToBeDeleted)
            //{
            //    log.InfoFormat("Delete Test Plan with Name=\"{0}\" Id = \"{1}\"", currentTestPlan.Name, currentTestPlan.Id);
            //    this.TestPlansEditViewModel.DeleteTestPlan(currentTestPlan);
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnFinish control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            //log.Info("Navigate to ProjectSelectionView");
            //this.NavigateToProjectSelection();
        }

        private void btnAddTestProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProject_Click(object sender, RoutedEventArgs e)
        {

        }   
    }
}
