namespace Medical_Manager.Models
{
    public class Consult
    {
        public int id { get; set; }
        public string date { get; set; }
        public string emploi { get; set; }
        public string entreprise { get; set; }

        public string sexe { get; set; }

        public string dignostique { get; set; }

        public string commentaire { get; set; }
    }
}
