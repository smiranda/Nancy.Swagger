using Nancy.Swagger.Swagger2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nancy.Swagger.Demo.Models {
    [ModelDoc("A user of this system")]
    public class User : ModelDocProvider<User> {
        [PropertyDoc("Name of the user", Required = true)]
        public string Name { get; set; }

        [PropertyDoc("Age of the user", Required=false)]
        public int Age { get; set; }

        [PropertyDoc("Age of the user when he graduated", Required = false)]
        public int Age2 { get; set; }

        [PropertyDoc("Date of birth of the user", Required = false)]
        public DateTime DateOfBirth { get; set; }

        [PropertyDoc("Address of the  user", Required = false)]
        public Address Address { get; set; }
    }
}