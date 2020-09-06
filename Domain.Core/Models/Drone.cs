using System;
using System.ComponentModel.DataAnnotations;

namespace devboost.dronedelivery.felipe.domain.core.Models
{
    public class Drone : IEquatable<Drone>
    {
        [Key]
        public int Id { get; set; }

        public int Capacidade { get; set; }

        public int Velocidade { get; set; }

        public int Autonomia { get; set; }

        public int Carga { get; set; }

        public float Perfomance { get; set; }

        public bool Equals(Drone other)
        {
            return Id == other.Id
            && Capacidade == other.Capacidade
            && Velocidade == other.Velocidade
            && Autonomia == other.Autonomia
            && Carga == other.Carga
            && Perfomance == other.Perfomance;
        }


    }
}
