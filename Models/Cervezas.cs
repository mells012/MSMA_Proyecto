using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMA_Proyecto.Models
{
    public class Cervezas
    {
        [Key] // Asegúrate de marcar la propiedad como clave primaria
        public int IDCerveza { get; set; }
        public string? Nombre { get; set; }
        public enum TamañoOpciones { Copa, Pinta, Litro }

        private TamañoOpciones tamaño;
        public TamañoOpciones Tamaño
        {
            get { return tamaño; }
            set
            {
                tamaño = value;
                PonerPrecio();
            }
        }

        public double Precio { get; set; }
        public double AVC { get; set; }

        private void PonerPrecio()
        {
            switch (tamaño)
            {
                case TamañoOpciones.Copa:
                    Precio = 3.50;
                    break;
                case TamañoOpciones.Pinta:
                    Precio = 5.00;
                    break;
                case TamañoOpciones.Litro:
                    Precio = 10.00;
                    break;
                default:
                    Precio = 0.00; // Valor por defecto
                    break;
            }
        }
    }
}
