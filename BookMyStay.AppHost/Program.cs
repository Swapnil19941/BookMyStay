var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BookMyStay_Api>("bookmystay-api");

builder.Build().Run();
