using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*CREATE TABLE Produs (
ProdusId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
NumeProdus varchar(200), 
Categorie varchar(200),
Producator varchar(200),
Pret int,
Stoc int
);*/


namespace backEnd.Models
{
    public class Produs
    {
        public int ProdusId { get; set; }
        //[Required]
        public string NumeProdus { get; set; }
        public string Categorie { get; set; }
        public string Producator { get; set; }
        public float Pret { get; set; }
        public int Stoc { get; set; }

    }
}
