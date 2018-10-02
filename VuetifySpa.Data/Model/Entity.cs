using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VuetifySpa.Data.Model
{
    public abstract class Entity
    {


        public Entity() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            if (entity == null)
                return false;

            return Id== entity.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }


}
