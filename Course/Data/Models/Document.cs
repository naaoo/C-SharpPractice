﻿using Data.Attributes;
using PersonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Data.Models
{
    /// <summary>
    /// contains information to a certain document
    /// </summary>

    [Table("documents")]
    public class Document : BaseClassCreatedModify
    {
        public Document()
        {
            DocumentClasses = new List<RelDocumentClass>();
        }

        /// <summary>
        /// the filePath where the document is placed
        /// </summary>
        [Column("url", TypeName = "varchar(1000)")]
        public string Url { get; set; }

        /// <summary>
        /// the name of the document
        /// </summary>
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        /// <summary>
        /// an open comment concerning the document
        /// </summary>
        [Column("comment", TypeName = "varchar(500)")]
        public string? Comment { get; set; }

        /// <summary>
        /// contains the id of a belonging reminder (Reminders not implemented yet)
        /// </summary>
        [Column("reminder_id")]
        public int? ReminderId { get; set; }

        /// <summary>
        /// the documents' type
        /// </summary>
        [Column("type", TypeName = "varchar(50)")]
        public EDocumentType Type { get; set; }

        /// <summary>
        /// needed for creating link
        /// </summary>
        [NotMapped]
        public Absence Absence { get; set; }

        /// <summary>
        /// temporarily needed for building the right relationships in RelDocumentClass
        /// </summary>
        [NotMapped]
        [Document(typeof(Course))]
        public int? CourseId { get; set; }

        /// <summary>
        /// temporarily needed for building the right relationships in RelDocumentClass
        /// </summary>
        [NotMapped]
        [Document(typeof(Person))]
        public int? PersonId { get; set; }

        /// <summary>
        /// contains relations to "classes" (e.g. Persons or Courses)
        /// </summary>
        [NotMapped]
        public List<RelDocumentClass> DocumentClasses { get; set; }

        public void CreateRelation()
        {
            var properties = this.GetType().GetProperties().Where(c => c.GetCustomAttribute<DocumentAttribute>() != null);

            foreach (var property in properties)
            {
                CreateRelation(property);
            }
        }

        private void CreateRelation(PropertyInfo prop)
        {
            var documentAttr = prop.GetCustomAttribute<DocumentAttribute>();

            if (prop != null)
            {
                var id = prop.GetValue(this) as int?;
                if (id.HasValue)
                {
                    RelDocumentClass relDocumentClass = new RelDocumentClass();
                    relDocumentClass.Document = this;
                    relDocumentClass.Class = documentAttr.ClassName;
                    relDocumentClass.ClassId = id.Value;
                    this.DocumentClasses.Add(relDocumentClass);
                }
            }
        }
    }
}