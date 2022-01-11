using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Person
    {
        int id;
        string name;
        string lastname;
        string address;
        string phone;

        public Person(int id,string name, string lastname, string address, string phone)
        {
            this.Id = id; 
            this.Name = name;
            this.LastName = lastname;
            this.Address = address;
            this.Phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastname; set => lastname = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}