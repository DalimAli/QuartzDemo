// See https://aka.ms/new-console-template for more information
using QuartScheduler;
using Quartz;
using Quartz.Impl;
using Serilog;

Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.Seq("http://localhost:5341") //user : admin , password: admin
           .CreateLogger();

Log.Information("Hello, {Name}!", Environment.UserName);
Console.WriteLine("Hello, World!");

StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
IScheduler scheduler = await schedulerFactory.GetScheduler();

await scheduler.Start();
Log.Information("Starting new job");


IJobDetail job = JobBuilder.Create<HelloJob>()
                           .WithIdentity("hello job","quartzdemoapicall")
                           .Build();
IJobDetail job2 = JobBuilder.Create<HelloJob2>()
                           .WithIdentity("hello job", "quartzdemoapicall")
                           .Build();


ITrigger trigger = TriggerBuilder.Create()
                                 .WithIdentity("trigger1", "group1")
                                 .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                                 .Build();

await scheduler.ScheduleJob(job, trigger);

await Task.Delay(TimeSpan.FromSeconds(60));

// and last shut down the scheduler when you are ready to close your program
await scheduler.Shutdown();
// await
//try
//{
//    var x = Convert.ToInt32("dfsd456");
//    Console.WriteLine(x);
//}
//catch (Exception ex)
//{
//    Log.Error("Error occured on conversion, {0}", ex.Message);
//    throw;
//}
Log.Information("End job");
Console.ReadLine();


