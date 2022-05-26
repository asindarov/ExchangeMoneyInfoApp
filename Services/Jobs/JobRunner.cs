﻿using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Services.Jobs
{
    [DisallowConcurrentExecution]
    public class JobRunner : IJob
    {
        private readonly IServiceProvider _serviceProvider;
        public JobRunner(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var job = scope.ServiceProvider.GetRequiredService(context.JobDetail.JobType) as IJob;

                await job.Execute(context);
            }
        }
    }
}
