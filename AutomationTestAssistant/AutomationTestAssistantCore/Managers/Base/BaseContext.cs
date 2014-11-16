using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class ContextManager : IDisposable
    {
        private ATAEntities context;
        public ATAEntities Context 
        {
            get
            {
                if (context == null)
                {
                    context = new ATAEntities();
                }
                return context;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
