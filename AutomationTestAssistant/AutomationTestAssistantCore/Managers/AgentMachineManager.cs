using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class AgentMachineManager
    {
        public List<ATADataModel.AgentMachine> GetAllAgentMachinesByTeamId(ATAEntities context, int teamId)
        {
            var team = context.Teams.Where(t => t.TeamId.Equals(teamId)).FirstOrDefault();
            var agentMachines = team.AgentMachines;
            return agentMachines.ToList();
        }

        public List<ATADataModel.AgentMachine> GetAll(ATAEntities context)
        {
            return context.AgentMachines.ToList();
        }

        public ATADataModel.AgentMachine GetByName(ATAEntities context, string name)
        {
            return context.AgentMachines.Where(p => p.Name.Equals(name)).FirstOrDefault();
        }

        public void AddNew(ATAEntities context, string agentMachineName, string ip, string workingDir)
        {
            //try
            //{
                AgentMachine am = new AgentMachine()
                {
                    Name = agentMachineName,
                    Ip = ip,
                    WorkingDirPath = workingDir
                };
                context.AgentMachines.Add(am);
                context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        StreamWriter sw = new StreamWriter("validationErros.txt");
            //        sw.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            sw.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //        sw.Close();
            //    }
            //    throw;
            //}
        }
    }
}
