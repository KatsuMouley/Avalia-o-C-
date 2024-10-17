var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/funcionario/cadastrar", ([FromBody]PessoaCDTO pessoa_C_DTO)=>{
    if (String.IsNullOrEmpty(pessoa_C_DTO.Name))
    //Uma opção para realizar DTOs mais rapidamente de maneira mais facilmente legivel seriam automappers. estarei pulando esta parte devido a falta de internet para instalação das ferramentas necessárias
    //nesta parte eu tbm pulei validadores devido ao uso de uma ferramenta online Nuget, como no momento estou sem acesso
    //O exemplo do endpoint assincrono funcionaria melhor caso eu presenciasse o uso das ferramentas mencionada acima, porém como foram etapas q eu pulei, nesta etapa não estaremos utilizando tanto async
    //sempre tratar as coisas com excessão
    {
        return Results.BadRequest("Invalid Id or pessoas Name");
    }
    if (Pessoas.pessoas.FirstOrDefault(u => u.Name.ToLower() == pessoa_C_DTO.Name.ToLower()) != null)
    {
        return Results.BadRequest("Esta pessoa já existe");
    }
    Person pessoa = new(){
        Name = pessoa_C_DTO.Name,
        born = pessoa_C_DTO.born
    };
    pessoa.Id= Pessoas.pessoas.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
    Pessoas.pessoas.Add(pessoa);
    
    PessoaDTO pessoaDTO = new(){
        Id = pessoa.Id,
        Name = pessoa.Name,
        born = pessoa.born
    };
    //Retorna um getid da pessoa
    return Results.CreatedAtRoute("GetPessoa", new {Id=pessoa.Id},pessoa);
    // return Results.Created($"/Api/pessoas/{pessoa.Id}",pessoa);
});


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
