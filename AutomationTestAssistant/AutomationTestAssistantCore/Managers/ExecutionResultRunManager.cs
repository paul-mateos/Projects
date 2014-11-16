using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class ExecutionResultRunManager
    {
        public void Save(ATAEntities context, ExecutionResultRun executionResultRun)
        {
            context.ExecutionResultRuns.Add(executionResultRun);
            context.SaveChanges();
        }

        public ExecutionResultRun GetByExecutionResultRun(ATAEntities context, string executionResultRunId)
        {
            ExecutionResultRun executionResultRun = context.ExecutionResultRuns.Where(e => e.ExecutionResultRunId.Equals(executionResultRunId)).FirstOrDefault();
            return executionResultRun;
        }

        public List<ExecutionResultRun> GetAllByTeams(ATAEntities context, List<Team> teams)
        {
            List<ExecutionResultRun> executionResultRuns = new List<ExecutionResultRun>();
            foreach (Team cTeam in teams)
	        {
		       var allExecutionResultRunsForTeam = context.ExecutionResultRuns.Where(e => e.Member.Teams.Where(t => t.TeamId.Equals(cTeam.TeamId)).Count() > 0);
               executionResultRuns.AddRange(allExecutionResultRunsForTeam.ToList());
	        }

            return executionResultRuns;
        }   
    }
}
