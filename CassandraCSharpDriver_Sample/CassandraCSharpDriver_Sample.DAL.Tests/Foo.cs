using System;
using CassandraCSharpDriver_Sample.DAL.Interfaces;

namespace CassandraCSharpDriver_Sample.DAL.Tests
{
    public class Foo : IDataModel
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public override Boolean Equals(Object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return obj.GetType() == this.GetType() && this.Equals((Foo)obj);
        }

        public override Int32 GetHashCode()
        {
            unchecked
            {
                return (this.Id.GetHashCode() * 397) ^ (this.Name?.GetHashCode() ?? 0);
            }
        }

        private Boolean Equals(Foo foo)
        {
            return this.Id.Equals(foo.Id) && String.Equals(this.Name, foo.Name);
        }
    }
}