using System.ComponentModel.DataAnnotations;

namespace devboost.dronedelivery.felipe.DTO.Models
{
    public class Drone
    {
        [Key]
        public int Id { get; set; }

        public int Capacidade { get; set; }

        public int Velocidade { get; set; }

        public int Autonomia { get; set; }

        public int Carga { get; set; }

        public float Perfomance { get; set; }

        public override bool Equals(object obj)
        {
            return Id == ((Drone)obj).Id
            && Capacidade == ((Drone)obj).Capacidade
            && Velocidade == ((Drone)obj).Velocidade
            && Autonomia == ((Drone)obj).Autonomia
            && Carga == ((Drone)obj).Carga
            && Perfomance == ((Drone)obj).Perfomance;

        }
    }
}
