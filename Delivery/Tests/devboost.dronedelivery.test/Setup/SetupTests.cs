﻿using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.core.Models;
using devboost.dronedelivery.domain.Entites;
using System;
using System.Collections.Generic;

namespace devboost.dronedelivery.test
{
    public static class SetupTests
    {

        public static DroneStatusDto GetDroneStatusDto()
        {
            return new DroneStatusDto()
            {
                Drone = GetDrone(),
                SomaDistancia = 5,
                SomaPeso = 10
            };
        }
        public static PedidoDrone GetPedidoDrone(StatusEnvio statusEnvio)
        {
            return new PedidoDrone()
            {
                DataHoraFinalizacao = new DateTime(2020, 8, 20, 22, 00, 00),
                Distancia = 5,
                StatusEnvio = (int)statusEnvio,
                Pedido = GetPedido(),
                Drone = GetDrone(),
                DroneId = GetDrone().Id,
                PedidoId = GetPedido().Id
            };
        }

        public static List<PedidoDrone> GetPedidoDrones(StatusEnvio statusEnvio)
        {
            return new List<PedidoDrone>()
            {
                GetPedidoDrone(statusEnvio)
            };
        }

        public static Pedido GetPedido()
        {
            return new Pedido()
            {
                Cliente = new Cliente()
                {
                    Nome = "Felipe",
                    Id = 1,
                    Latitude = -19.9539424,
                    Longitude = -43.9750544,
                    Password = "",
                    UserId = ""
                },
                ClienteId = 1,
                Peso = 50,
                Situacao = (int)StatusPedido.AGUARDANDO

            };

        }
        public static List<Pedido> GetPedidosList()
        {
            return new List<Pedido>() {
                GetPedido()
            };
        }

        public static LoginDTO GetLogin()
        {
            return new LoginDTO()
            {
                Password = "teste",
                UserId = "teste"

            };
        }

        public static Cliente GetCliente()
        {
            return new Cliente()
            {
                Nome = "Felipe",
                Id = 1,
                Latitude = -19.9539424,
                Longitude = -43.9750544,
                Password = "",
                UserId = "teste"

            };
        }

        public static List<Cliente> GetClientes()
        {
            return new List<Cliente>()
            {
                GetCliente()
            };
        }

        public static List<StatusDroneDto> GetDroneStatus()
        {
            List<StatusDroneDto> statusDroneDtos = new List<StatusDroneDto>();

            var statusDroneDto = new StatusDroneDto
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Situacao = true,
                PedidoId = 0,
                Nome = string.Empty
            };

            statusDroneDtos.Add(statusDroneDto);

            var statusDroneDto2 = new StatusDroneDto
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Situacao = false,
                PedidoId = 1,
                Nome = "João da Silva"
            };

            statusDroneDtos.Add(statusDroneDto2);

            return statusDroneDtos;
        }

        public static List<Drone> GetDrones()
        {
            return new List<Drone>()
            {
                GetDrone()
            };
        }

        public static StatusDroneDto GetStatusDroneDto()
        {
            return new StatusDroneDto()
            {
                ClienteId = 1,
                DroneId = 1,
                Latitude = 1.0,
                Longitude = 1.0,
                Nome = "Felipe",
                PedidoId = 1,
                Situacao = false
            };
        }

        public static DroneStatusResult GetDroneStatusResult()
        {
            return new DroneStatusResult
            {
                Autonomia = 100,
                Capacidade = 100,
                Carga = 100,
                Id = 1,
                Perfomance = 1000,
                SomaDistancia = 100,
                SomaPeso = 100,
                Velocidade = 100
            };
        }

        public static List<DroneStatusResult> GetDroneStatusResults()
        {
            return new List<DroneStatusResult>() { GetDroneStatusResult() };
        }
        public static List<StatusDroneDto> GetListStatusDroneDto()
        {
            return new List<StatusDroneDto>()
            {
                GetStatusDroneDto()
            };
        }
        public static Drone GetDrone()
        {
            return new Drone()
            {
                Id = 1,
                Autonomia = 100,
                Capacidade = 100,
                Carga = 100,
                Perfomance = (100 / 60.0f) * 100,
                Velocidade = 100
            };
        }

        public static DroneDto GetDroneDto()
        {
            return new DroneDto(new DroneStatusDto(GetDrone()), 100);
        }
    }
}
