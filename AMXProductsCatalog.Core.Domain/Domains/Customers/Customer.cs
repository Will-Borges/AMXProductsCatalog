using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Domains.Customers
{
    [DataContract]
    public class Customer //setar no login
    {
        [DataMember]
        public int Id { get; }

        [DataMember]
        public string Name { get; }

        [DataMember]
        public string Email { get; }

        //senha
    }
}
