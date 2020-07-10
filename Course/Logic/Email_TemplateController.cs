﻿
using Data.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using iText.IO.Font;
using iText.IO.Source;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;

using Document = iText.Layout.Document;
using Paragraph = DocumentFormat.OpenXml.Drawing.Paragraph;

namespace Logic
{
    public class Email_TemplateController : MainController
    {
        private DocumentController documentController = new DocumentController();
        private PersonController personController = new PersonController();
        public List<Communication> FillDocuments(EmailTemplate emailTemplate)

        {
            List<Communication> communications = new List<Communication>();

            for (int i = 0; i < emailTemplate.PersonIds.Length; i++)
            {
                {
                    string fileName = "text";
                    Person person = personController.FindOne(emailTemplate.PersonIds[i]);
                    string sourcePath = @"C:\DcvDokumente";
                    string targetPath = @"C:\DcvDokumente\CopiedVersion";

                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = System.IO.Path.Combine(templateMainPath, "Diploma.pdf");
                    string destFile = String.Format("C:\\DcvDokumente\\CopiedVersion\\{0}.pdf", person.FirstName);
                    //    string n = $"{targetPath}"+"\\" +$"{ person.FirstName}" + ".pdf";

                    //    System.IO.File.Copy(sourceFile, destFile, false);
                    //         PdfReader reader = new PdfReader(sourceFile);

        //            PdfReader reader = new PdfReader(sourceFile);

        //            PdfDocument pdf = new PdfDocument(reader);
        //            Document doc = new Document(pdf);
        ////          doc.Add(new Element("hallöle",Header));


        //             PdfWriter writer = new PdfWriter(destFile);

               



                    //  PdfMerger merger = new PdfMerger(pdf);
                    //Document doc =new Document(pdf);
                    //   doc.Add(Paragraph("hallöle"));
                    //   doc.Close();
              //      PdfDocument pdf = new PdfDocument();

              //      PdfWriter pdfWriter = new PdfWriter("gugi.pdf",pdf);
                    


                    Communication communication = documentController.CreateDocumentFromTemplate(emailTemplate, person, null, null, null);
                    communications.Add(communication);
                    //                    14 // Add ListItem objects
                    // list.add(new ListItem("Never gonna give you up"))
                    //add(new ListItem("Never gonna let you down"))
                    //add(new ListItem("Never gonna run around and desert you"))
                    //add(new ListItem("Never gonna make you cry"))
                    //add(new ListItem("Never gonna say goodbye"))
                    //add(new ListItem("Never gonna tell a lie and hurt you"));
                    //                    21 // Add the list
                    // document.add(list);
                    //                    23 document.close();


                }
            }
            return communications;
        }

        private AreaBreak Paragraph(string v)
        {
            throw new NotImplementedException();
        }
    }
}