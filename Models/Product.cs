using System.ComponentModel;

namespace Medical_Manager.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string date { get; set; }

        [DisplayName("Désignation")]
        public string designation { get; set; }

        [DisplayName("Quantitité Utilisé")]
        public int stockUtilise { get; set; }

        [DisplayName("Forme Médicamenteuse")]
        public string forme { get; set; }

    }
}
