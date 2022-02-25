using JedoxifyMart.Services.OrderAPI.Messages;
using JedoxifyMart.Services.OrderAPI.Models;
using JedoxifyMart.Services.OrderAPI.Repository;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace JedoxifyMart.Services.OrderAPI.Messaging
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrderRepo _orderRepository;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQCheckoutConsumer(OrderRepo orderRepository)
        {
            _orderRepository = orderRepository;
          
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, eventarg) =>
            {
                var content = Encoding.UTF8.GetString(eventarg.Body.ToArray());
                CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(content);
                HandleMessage(checkoutHeaderDto).GetAwaiter().GetResult();

                _channel.BasicAck(eventarg.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CheckoutHeaderDto checkoutHeaderDto)
        {
            OrderHeader orderHeader = new()
            {
                UserId = checkoutHeaderDto.UserId,
                FirstName = checkoutHeaderDto.FirstName,
                LastName = checkoutHeaderDto.LastName,
                OrderDetails = new List<OrderDetail>(),
                OrderTime = DateTime.Now,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                PaymentStatus = false,
           
            };
            foreach (var detailList in checkoutHeaderDto.CartDetails)
            {
                OrderDetail orderDetails = new()
                {
                    ProductId = detailList.ProductId,
                    ProductName = detailList.Product.ProductName,
                    Price = detailList.Product.Price,
                    Count = detailList.ProductCount
                };
                orderHeader.CartTotalItems += detailList.ProductCount;
                orderHeader.OrderDetails.Add(orderDetails);
            }

            await _orderRepository.AddOrder(orderHeader);


        }
    }
}
