using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Respostas
    {
        [Display(Name="Id")]
        public virtual Int32 Id_resp { get; set; }
        [Display(Name = "Resposta")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Resp_txt { get; set; }
        [Display(Name = "Opção Correta")]
        public virtual Boolean OpcaoCerta { get; set; }
    }
}
