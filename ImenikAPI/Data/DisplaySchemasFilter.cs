using ImenikAPI.Models;
using ImenikAPI.ViewModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

internal class DisplaySchemasFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        context.SchemaGenerator.GenerateSchema(typeof(CountryViewModel), context.SchemaRepository);
        context.SchemaGenerator.GenerateSchema(typeof(CountyViewModel), context.SchemaRepository);

    }
}