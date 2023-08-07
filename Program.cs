using ApiList.Data;
using ApiList.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("v1/atividade", (AppDbContext context) =>
{
    var atividade = context.Atividade.ToList();
    return Results.Ok(atividade);
}).Produces<Atividades>();

app.MapPost("v1/atividade", (
    AppDbContext context,
    CreateAtividadeViewModels model) =>
{
        var atividades = model.MapTo();
        if (!model.IsValid)
            return Results.BadRequest(model.Notifications);

        context.Atividade.Add(atividades);
        context.SaveChanges();

        return Results.Created($"/v1/atividade/{atividades.Id}", atividades); 
});

app.Run();
