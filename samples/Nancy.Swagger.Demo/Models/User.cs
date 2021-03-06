﻿using Nancy.Swagger.Swagger2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nancy.Swagger.Demo.Models {
    [ModelDoc("A user of this system")]
    public class User : ModelDocProvider<User> {
        [PropertyDoc(0, "Name of the user", Required = true)]
        public string Name { get; set; }

        [PropertyDoc(1, "Age of the user", Required=false)]
        public int Age { get; set; }

        [PropertyDoc(2, "Age of the user when he graduated", Required = false)]
        public int Age2 { get; set; }

        [PropertyDoc(3, "Date of birth of the user", Required = false)]
        public DateTime DateOfBirth { get; set; }

        [PropertyDoc(4, "Address of the  user", Required = false)]
        public Address Address { get; set; }

        [PropertyDoc(5, "Test enum", Required = false, EnumValues=new string[]{"A","B","C"})]
        public Role UserRole { get; set; }
    }
}