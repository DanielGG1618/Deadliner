var builder = WebApplication.CreateBuilder(args);
{
    var services = builder.Services;
    
    services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure();

    services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    
    app.MapIdentityApi<Infrastructure.Common.DbUser>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.Run();
}
