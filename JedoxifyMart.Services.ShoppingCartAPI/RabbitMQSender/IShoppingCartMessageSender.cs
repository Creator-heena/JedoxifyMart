using JedoxifyMart.MessageBus;

namespace JedoxifyMart.Services.ShoppingCartAPI.RabbitMQSender
{
    public interface IShoppingCartMessageSender
    {

        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
