using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Busca_de_Alunos2.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Ra { get; set; }
        public string Nome { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

}