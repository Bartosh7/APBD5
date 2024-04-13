using projekt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IAnimalsDb, AnimalsDb>();
builder.Services.AddSingleton<IVisitsDB, VisitsDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IAnimalsDb animalsDb) =>
{
    return Results.Ok(animalsDb.GetAll());
});

app.MapGet("/animals/{id:int}", (IAnimalsDb animalsDb, int id) =>
{
    var animal= animalsDb.GetById(id);

    if (animal == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(animal);
});

app.MapPost("/animals", (IAnimalsDb mockDb, Animal animal) =>
{
    mockDb.Add(animal);
    return Results.Created();
});

app.MapPut("/animals/{id:int}", (IAnimalsDb animalsDb, Animal animalData, int id) =>
{
    var animal= animalsDb.GetById(id);

    if (animal == null)
    {
        return Results.NotFound();
    }
    animalsDb.Update(animal, animalData);
    return Results.NoContent();
});

app.MapDelete("/animals/{id:int}", (IAnimalsDb animalsDb, int id) =>
{
    var animal= animalsDb.GetById(id);

    if (animal == null)
    {
        return Results.NotFound();
    }
    animalsDb.Delete(animal);
    return Results.NoContent();
});

app.MapGet("/visits/{id:int}", (IVisitsDB visitsDb, int id) =>
{
    var list = visitsDb.GetAllAnimalVisits(id);
    if (list.Count == 0)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(list);
    }
});

app.MapPost("/visits", (IVisitsDB visitsDb, Visit visit) =>
{
    visitsDb.Add(visit);
    return Results.Created();

});




app.MapControllers();
app.Run();
