using eCommerce.eCommerce.API.middleware;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers();

//Build th web application
var app = builder.Build();

//Add middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
