using System;
using System.Text;

namespace CassandraCSharpDriver_Sample.DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public String Group { get; set; }

        public override String ToString()
        {
            return $"{nameof(this.UserId)}: {this.UserId}, {nameof(this.Name)}: {this.Name}, {nameof(this.Group)}: {this.Group}";
        }
    }
}
