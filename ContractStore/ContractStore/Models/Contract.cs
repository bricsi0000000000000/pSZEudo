using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ContractStore.Models.People;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ContractStore.Models
{
    public abstract class Contract
    {
        public Person personA;
        public Person personB;
        public Contract(Person personA, Person personB)
        {
            this.personA = personA;
            this.personB = personB;
        }

        public abstract void createPdf();
    }


    public class VehicleContract : Contract
    {
        public VehicleContract(Person personA, Person personB) : base(personA, personB)
        {
            createPdf();
        }

        public string encodedText(string text)
        {
            byte[] temp;
            temp = Encoding.GetEncoding("Windows-1250").GetBytes(text);
            temp = Encoding.Convert(Encoding.GetEncoding("ISO-8859-2"), Encoding.UTF8, temp);
            return Encoding.UTF8.GetString(temp);
        }

        public string dotLine(int length)
        {
            string result = "";
            for (int i=0; i<length; i++){
                result += ".";
            }
            return result;
        }

        public override void createPdf()
        {
            string file = "Models/Vehicle_Contract.json";
            using var reader = new StreamReader(file, Encoding.Default);
            try
            {
                dynamic groupsJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                int pageNumber = 1;
                Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("vehicleContract.pdf", FileMode.Create));
                doc.Open();

                System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
                Encoding.RegisterProvider(ppp);

                FontFactory.Register("c:/Windows/Fonts/times.ttf", "Times New Roman");

                Font titleFont = FontFactory.GetFont("Times New Roman", 13, Font.BOLD);
                Font regularFont = FontFactory.GetFont("Times New Roman", 13);

                Paragraph title;
                string text = groupsJSON.title;

                title = new Paragraph(text, titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                text = groupsJSON.rightsTitle;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.nextLine;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerName;
                text = text.Replace("[$buyerName]", personA.LastName + " " + personA.FirstName);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerBirthplace;
                text = text.Replace("[$buyerBirthplace]", personA.BirthPlace);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerMother;
                text = text.Replace("[$buyerMother]", personA.MotherName);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerNationality;
                text = text.Replace("[$buyerNationality]", personA.Nationality);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerAddress;
                text = text.Replace("[$buyerAddress]", personA.PostCode + ", " + personA.City + " " + personA.Street + " " + personA.HouseNumber);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerID;
                text = text.Replace("[$buyerID]", personA.PersonalID.ToString());
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerIDType;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerNumber;
                doc.Add(new Paragraph(text + dotLine(40), regularFont));

                text = groupsJSON.buyerOrganisation;
                doc.Add(new Paragraph(text + dotLine(70), regularFont));

                text = groupsJSON.buyerSiteAddress;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.buyerRegistrationNumber;
                doc.Add(new Paragraph(text + dotLine(60), regularFont));

                text = groupsJSON.buyerRepresenter;
                doc.Add(new Paragraph(text + dotLine(50), regularFont));

                text = groupsJSON.sellTitle;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerName;
                text = text.Replace("[$sellerName]", personB.LastName + " " + personB.FirstName);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerBirthPlace;
                text = text.Replace("[$sellerBirthPlace]", personB.BirthPlace);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerMother;
                text = text.Replace("[$sellerMother]", personB.MotherName);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerNationality;
                text = text.Replace("[$sellerNationality]", personB.Nationality);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerAddress;
                text = text.Replace("[$sellerAddress]", personB.PostCode + ", " + personB.City + " " + personB.Street + " " + personB.HouseNumber);
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerID;
                text = text.Replace("[$sellerID]", personB.PersonalID.ToString());
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerIDType;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerNumber;
                doc.Add(new Paragraph(text, regularFont));

                text = groupsJSON.sellerOrganisation;
                doc.Add(new Paragraph(text + dotLine(40), regularFont));

                text = groupsJSON.sellerOrganisationSiteAddress;
                doc.Add(new Paragraph(text + dotLine(40), regularFont));

                text = groupsJSON.sellerOrganisationRegistrationNumber;
                doc.Add(new Paragraph(text + dotLine(40), regularFont));

                text = groupsJSON.sellerOrganisationRepresenterName;
                doc.Add(new Paragraph(text + dotLine(40), regularFont));

                doc.NewPage();
                doc.Add(new Paragraph(encodedText("a továbbiakban mint Vevő"), regularFont));

                doc.Add(new Paragraph(encodedText("(együttesen a továbbiakban: Felek) között az alulírott helyen és időben az alábbi feltételek szerint:"), regularFont));


                
                List list = new List(List.ORDERED);
                
                for(int i=1; i <groupsJSON.Conditions.Count; i++)
				{
                    text = groupsJSON.Conditions[i].text;
                    list.Add(new ListItem(text, regularFont));
				}
                
                doc.Add(list);


                text = groupsJSON.twoCopies;
                doc.Add(new Paragraph(text, regularFont));

                System.DateTime moment = DateTime.Today;

                text = text.Replace("[$City]", personB.City).Replace("[$year]", moment.Year.ToString()).Replace("[$month]", moment.Month.ToString()).Replace("[$day]", moment.Day.ToString());
                doc.Add(new Paragraph(text, regularFont));
                doc.Add(new Paragraph(dotLine(30) + "    " + dotLine(30) + encodedText("\n              Eladó                    Vevő"), regularFont));
                doc.Add(new Paragraph(encodedText("Előttünk mint tanúk előtt:"), regularFont));
                doc.Add(new Paragraph(encodedText("1.Családi és utónév:") + dotLine(25), regularFont));
                doc.Add(new Paragraph(encodedText("lakcím:") + dotLine(25), regularFont));
                doc.Add(new Paragraph(encodedText("2.Családi és utónév:") + dotLine(25), regularFont));
                doc.Add(new Paragraph(encodedText("lakcím:") + dotLine(25), regularFont));

                doc.Close();

            }
            catch (Exception e)
            { }            
        }
    }

}
