using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.Business.Entities
{
    /// <summary>
    /// The staff/crew of the Coffee shop
    /// </summary>    
    public class User
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The role of the user (CASHIER, BARISTA)
        /// </summary>
        public string Role { get; set; }
    }
}
