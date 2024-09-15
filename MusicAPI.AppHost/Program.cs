var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MusicAPI>("musicapi");

builder.Build().Run();
