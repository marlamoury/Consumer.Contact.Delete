using Consumer.Delete.Contact.Infrastructure.Messaging;

namespace Consumer.Contact.Delete.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly RabbitMQConsumer _consumer;

    public Worker(ILogger<Worker> logger, RabbitMQConsumer consumer)
    {
        _logger = logger;
        _consumer = consumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker iniciado...");
        return _consumer.StartAsync(stoppingToken); // Chama o StartAsync do RabbitMQConsumer
    }
}
