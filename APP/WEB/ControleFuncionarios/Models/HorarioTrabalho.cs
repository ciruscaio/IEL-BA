using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ControleFuncionarios.Models
{
    [Table("<horario_trabalho>")]
    public class HorarioTrabalho
    {
        [Key]
        public int Codigo { get; set; }
        public int Funcionario_codigo { get; set; }
        public int Dia_semana { get; set; }

        [DataType(DataType.Time)]
        public DateTime Hora_ini { get; set; }

        [DataType(DataType.Time)]
        public DateTime Hora_fim { get; set; }

        [DataType(DataType.Time)]
        public DateTime Tempo_descanso { get; set; }

        public int ch { get; set; }


        //[ForeignKey("Funcionario_codigo")]
        //public virtual Funcionario Funcionario { get; set; } = new Funcionario();

    }
}
