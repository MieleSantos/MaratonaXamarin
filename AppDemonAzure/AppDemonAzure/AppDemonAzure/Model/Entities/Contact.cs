﻿using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;


namespace AppDemonAzure.Model.Entities
{
    [DataTable("Contacts")]
    public class Contact
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
