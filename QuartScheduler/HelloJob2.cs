using Quartz;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartScheduler
{
    public class HelloJob2: IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information("Calling Job, greeting from Hello Job 2");
        }
    }
}
