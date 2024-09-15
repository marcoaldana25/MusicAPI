var builder = DistributedApplication.CreateBuilder(args);

var musicApi = builder.AddProject<Projects.MusicAPI>("musicapi")
    .WithExternalHttpEndpoints();

builder.AddNpmApp("angular", "..\\1. Clients\\angular-showcase")
    .WithReference(musicApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile(); ;

builder.Build().Run();
