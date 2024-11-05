using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMA_Proyecto.Models
{
    public class Comida
    {
        [Key]
        public int IDPlato { get; set; }
        public enum PlatoOpciones { Papas_Fritas, Papas_Rancheras, Santos_Nachos, Picadita_Parrillera, Alitas_Dragón, Ribeye, Picaña, Royal_con_Queso }

        private PlatoOpciones plato;
        public PlatoOpciones Plato
        {
            get { return plato; }
            set
            {
                plato = value;
                PonerPrecio_Comida();
            }
        }

        public string? Descripción { get; set; }
        public double Precio_Comida { get; set; }

        private void PonerPrecio_Comida()
        {
            switch (plato)
            {
                case PlatoOpciones.Papas_Fritas:
                    Precio_Comida = 3.00;
                    break;
                case PlatoOpciones.Papas_Rancheras:
                    Precio_Comida = 5.50;
                    break;
                case PlatoOpciones.Santos_Nachos:
                    Precio_Comida = 5.50;
                    break;
                case PlatoOpciones.Picadita_Parrillera:
                    Precio_Comida = 12.00;
                    break;
                case PlatoOpciones.Alitas_Dragón:
                    Precio_Comida = 6.00;
                    break;
                case PlatoOpciones.Ribeye:
                    Precio_Comida = 9.00;
                    break;
                case PlatoOpciones.Picaña:
                    Precio_Comida = 12.00;
                    break;
                case PlatoOpciones.Royal_con_Queso:
                    Precio_Comida = 6.00;
                    break;
                default:
                    Precio_Comida = 0.00;
                    break;
            }
        }
    }
}
