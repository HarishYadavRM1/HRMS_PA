using HrAppApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ? Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ? Register repositories as singletons (in-memory stores)
builder.Services.AddSingleton<GoalRepository>();
builder.Services.AddSingleton<FeedbackRepository>();
builder.Services.AddSingleton<AppraisalCycleRepository>();
builder.Services.AddSingleton<TrainingRepository>();
builder.Services.AddSingleton<PromotionRepository>();

var app = builder.Build();

// ? Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR App API V1");
    c.RoutePrefix = "swagger"; // optional
});

// Allow CORS for frontend
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Use controllers
app.MapControllers();

// Run app
app.Run();
