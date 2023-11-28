
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurando nossa camada de persistencia
builder.Services.ConfigurePersistenceApp(builder.Configuration);
// Registrar os serviços relacionado a camada de aplicação
// auto mapper, mediator, fluent id
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Esse método precisamos criar na mão para subir nosso BD a nossa aplicação
BD.CreateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.MapControllers();
app.Run();

