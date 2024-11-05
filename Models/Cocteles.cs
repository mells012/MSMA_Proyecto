using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSMA_Proyecto.Models
{
    public class Cocteles
    {
        [Key]
        public int IDCocteles { get; set; }
        public enum CoctelOpciones { Mojito, Cuba_libre, Gin_Tonic, Gin_Beer, Vino, Tequila_Shot }

        private CoctelOpciones coctel;
        public CoctelOpciones Coctel
        {
            get { return coctel; }
            set
            {
                coctel = value;
                PonerPrecio_Coctel();
            }
        }

        public string? Descripción { get; set; }
        public double Precio_Coctel { get; set; }

        private void PonerPrecio_Coctel()
        {
            switch (coctel)
            {
                case CoctelOpciones.Mojito:
                    Precio_Coctel = 6.00;
                    break;
                case CoctelOpciones.Cuba_libre:
                    Precio_Coctel = 6.00;
                    break;
                case CoctelOpciones.Gin_Tonic:
                    Precio_Coctel = 7.00;
                    break;
                case CoctelOpciones.Gin_Beer:
                    Precio_Coctel = 8.00;
                    break;
                case CoctelOpciones.Vino:
                    Precio_Coctel = 4.50;
                    break;
                case CoctelOpciones.Tequila_Shot:
                    Precio_Coctel = 2.50;
                    break;
                default:
                    Precio_Coctel = 0.00;
                    break;
            }
        }
    }
}
