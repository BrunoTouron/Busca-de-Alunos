using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Busca_de_Alunos2.Models
{
    public class Pesquisa
    {
        [Key]
        public int Id { get; set; }

        public int? Aluno_Id { get; set; }
        [ForeignKey("Aluno_Id")]

        public virtual Aluno Aluno { get; set; }
    }

}