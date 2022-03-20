using System;
using SQLite;

namespace AppReclama.Models
{
   public class Reclamacao
    { 
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Descricao { get; set; }
            public string Endereco { get; set; }
            public string Imagem { get; set; }
    }
    }
