﻿using JedoxifyMart.MessageBus;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace JedoxifyMart.Services.ShoppingCartAPI.RabbitMQSender
{
    public class ShoppingCartMessageSender : IShoppingCartMessageSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;

        public ShoppingCartMessageSender()
        {
            _hostname = "localhost";
            _password = "guest";
            _username = "guest";
        }
        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                var json = JsonConvert.SerializeObject(baseMessage);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
        }
        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                //log exception
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }
            CreateConnection();
            return _connection != null;
        }
    }
}
