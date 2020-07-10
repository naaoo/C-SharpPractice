﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonData
{
    public class BaseClassCreatedModify
    {
        /// <summary>
        /// id in DB (is assigned by DB as autoIncrement)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// the date the document was created at
        /// </summary>
        [Column("created@")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// the date the document was modified at
        /// </summary>
        [Column("modified@")]
        public DateTime? ModifiedAt { get; set; }

        [NotMapped]
        public DateTime ModifyDate { get; set; }
    }
}