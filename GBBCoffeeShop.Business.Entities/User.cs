using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        /// <summary>
        /// The login name of the user
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// The hash of the user's password
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// The salt of the password hash
        /// </summary>
        public string PasswordSalt { get; set; }
    }
}
