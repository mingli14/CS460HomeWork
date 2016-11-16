using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestCollection
    {
        public List<Request> Requests;

        public RequestCollection()
        {
            Requests = new List<Request>
            {
                new Request { FirstName = "John", LastName = "Doe", DOB = new DateTime(1890,10,31), PhoneNumber = "5031112345", Advisor = "Tom", CatalogYear = new DateTime(2014,9,28), Email = "Johnd@gmail.com", Major  = "CS", Minor = "Math", VNumber = "00031654" }
            };
        }
    }
}