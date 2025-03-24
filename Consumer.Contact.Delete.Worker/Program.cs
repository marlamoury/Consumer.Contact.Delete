using Consumer.Contact.Delete.Infrastructure.Persistence;
using Consumer.Contact.Delete.Worker;
using Consumer.Delete.Contact.Application.Services;
using Consumer.Delete.Contact.Infrastructure.Messaging;
using Consumer.Delete.Contact.Infrastructure.Persistence;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        // Carrega o arquivo appsettings.json
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Carrega as configurações do RabbitMQ do appsettings.json
        var rabbitMqSettings = context.Configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
        services.AddSingleton(rabbitMqSettings);

        // Registrando serviços e repositórios
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IContatoService, ContatoService>();

        // Registrando o RabbitMQConsumer como Singleton e o Worker como HostedService
        services.AddSingleton<RabbitMQConsumer>();
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build();

await host.RunAsync();

