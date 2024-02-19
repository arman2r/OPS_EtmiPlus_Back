using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OPSEtmiPlus.Controllers;
using OPSEtmiPlus.Controllers.Chagas;
using OPSEtmiPlus.Controllers.HepatitisB;
using OPSEtmiPlus.Controllers.Sifilis;
using OPSEtmiPlus.Controllers.VIH;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    string secret = builder.Configuration!.GetValue<string>("Authorization:secret")!;
    string issuer = builder.Configuration!.GetValue<string>("Authorization:issuer")!;
    string audience = builder.Configuration!.GetValue<string>("Authorization:audience")!;
    // Settings provider token JWT
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Logger.LogInformation("The API started");

#region Initialize class
AuthController.Initialize(builder.Configuration);
UsuarioController.Initialize(builder.Configuration);
ParametricaController.Initialize(builder.Configuration);
GestanteController.Initialize(builder.Configuration);
GestanteControlController.Initialize(builder.Configuration);
ReporteBinomioController.Initialize(builder.Configuration);
ReporteEAPBController.Initialize(builder.Configuration);

//VIH
Reporte1Controller.Initialize(builder.Configuration);
Reporte2Controller.Initialize(builder.Configuration);
Reporte3Controller.Initialize(builder.Configuration);
Reporte4Controller.Initialize(builder.Configuration);
Reporte5Controller.Initialize(builder.Configuration);
ParaclinicoMadreController.Initialize(builder.Configuration);
ParaclinicoNinoController.Initialize(builder.Configuration);

//Hepatitis B
ClasificacionNinoExpuestoController.Initialize(builder.Configuration);
DiagnosticoGestanteController.Initialize(builder.Configuration);
SeguimientoNinoExpuestoController.Initialize(builder.Configuration);
TratamientoSeguimientoGestanteController.Initialize(builder.Configuration);
VacunacionController.Initialize(builder.Configuration);

//Sifilis
AplicacionPenicilinaBenzatinicaController.Initialize(builder.Configuration);
DiagnosticoEIntervencionNinoController.Initialize(builder.Configuration);
DiagnosticoMaternoController.Initialize(builder.Configuration);
RetratamientoMaternoGestacionalController.Initialize(builder.Configuration);
SeguimientoContactoSexualController.Initialize(builder.Configuration);
SeguimientoNinoPrimerAnioController.Initialize(builder.Configuration);
SeguimientoSerologicoGestanteController.Initialize(builder.Configuration);
SituacionGestanteEmbarazoActualController.Initialize(builder.Configuration);
TratamientoMaternoEstadioClinicoController.Initialize(builder.Configuration);

//Chagas
AlgoritmoController.Initialize(builder.Configuration);
DiagnosticoEnfermedadGestanteController.Initialize(builder.Configuration);
DiagnosticoNinoExpuestoController.Initialize(builder.Configuration);
SeguimientoNinoExpuestoChagasController.Initialize(builder.Configuration);
TratamientoMaternoController.Initialize(builder.Configuration);
TratamientoSeguimientoNinoController.Initialize(builder.Configuration);
#endregion

app.UseAuthorization();

app.MapControllers();


#region Conf CORS
app.UseCors(x =>
{
    if (builder.Environment.IsDevelopment())
    {
        x.AllowAnyHeader()
        //.AllowAnyMethod()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .WithMethods("GET", "POST", "PUT")
        .AllowCredentials();
    }
    else
    {
        x.AllowAnyHeader()
        .WithOrigins("") //Specify url
        .WithMethods("GET", "POST", "PUT")
        .AllowCredentials();
    }
});
#endregion

app.Run();
