using WebApplication1.Utilities.Formatters;

namespace WebApplication1.Extentions
{
    public static class IMvcBuilderExtensions
    { 
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
        
    }
}
