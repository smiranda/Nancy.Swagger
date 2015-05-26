using Nancy.Swagger.Swagger2;
namespace Nancy.Swagger.Demo.Models
{
    [ModelDoc("An address")]    
    public class Address : ModelDocProvider<Address>
    {

        [PropertyDoc(0, "First address line", Required = true)]
        public string Address1 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }
    }
}