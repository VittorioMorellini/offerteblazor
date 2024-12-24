var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.OfferteWeb>("offerteweb");

builder.Build().Run();
