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

namespace ContractStore.Models
{
    public abstract class Contract
    {
        Person personA;
        Person personB;
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
            temp = Encoding.Convert(Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8, temp);
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
            
            title = new Paragraph(encodedText("A közúti közlekedési nyilvántartásba bejegyzett jármű tulajdonjogának változását igazoló teljes bizonyító erejű magánokirat"), titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph(encodedText("A jármű tulajdonjoga változásának alapjául szolgáló jogügylet jogcíme\n")+dotLine(100), regularFont));

            doc.Add(new Paragraph(encodedText("amely létrejött egyrészről\n (természetes személy esetén)"), regularFont));

            doc.Add(new Paragraph(encodedText("Családi név és utónév:")+dotLine(60) , regularFont));

            doc.Add(new Paragraph(encodedText("születési hely és idő:")+dotLine(30), regularFont));

            doc.Add(new Paragraph(encodedText("anyja születési családi és utóneve:")+dotLine(40), regularFont));

            doc.Add(new Paragraph(encodedText("állampolgársága (hontalansága):" + dotLine(40)), regularFont));

            doc.Add(new Paragraph(encodedText("lakcím:") + dotLine(50), regularFont));

            doc.Add(new Paragraph(encodedText("személyazonosságát igazoló okmány:"), regularFont));

            doc.Add(new Paragraph(encodedText("\t- típusa *: személyazonosító igazolvány/útlevél/vezetői engedély"), regularFont));

            doc.Add(new Paragraph(encodedText("\t- sorszáma:") + dotLine(40), regularFont));

            doc.Add(new Paragraph(encodedText("(jogi személy vagy jogi személyiséggel nem rendelkező szervezet esetén)"), regularFont));

            doc.Add(new Paragraph(encodedText("Jogi személy vagy jogi személyiséggel nem rendelkező szervezet megnevezése\n" + dotLine(70)), regularFont));

            doc.Add(new Paragraph(encodedText("Székhely, telephely címe:") + dotLine(60), regularFont));

            doc.Add(new Paragraph(encodedText("Cégjegyzék illetőleg nyilvántartási száma:") + dotLine(60), regularFont));

            doc.Add(new Paragraph(encodedText("Képviselője\n Családi és utóneve:") + dotLine(50), regularFont));

            doc.Add(new Paragraph(encodedText("a továbbiakbam mint Eladó,\nmásrészről\n(természetes személy esetén)"), regularFont));

            doc.Add(new Paragraph(encodedText("Családi név és utónév:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("születési hely és idő:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("anyja születési családi és utóneve:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("állampolgársága (hontalansága):") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("lakcím:") + dotLine(20), regularFont));
            
            doc.Add(new Paragraph(encodedText("személyazonosságát igazoló okmány:"), regularFont));
            
            doc.Add(new Paragraph(encodedText("\t- típusa *: személyazonosító igazolvány/útlevél/vezetői engedély"), regularFont));  
            
            doc.Add(new Paragraph(encodedText("\t- sorszáma:") + dotLine(20), regularFont));
            
            doc.Add(new Paragraph(encodedText("(jogi személy vagy jogi személyiséggel nem rendelkező szervezet esetén)"), regularFont));
            
            doc.Add(new Paragraph(encodedText("Megnevezése:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("Székhely, telephely címe:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("Cégjegyzék illetőleg nyilvántartási száma:") + dotLine(40), regularFont));
            
            doc.Add(new Paragraph(encodedText("Képviselője\n Családi és utóneve:") + dotLine(40), regularFont));

            doc.NewPage();
            doc.Add(new Paragraph(encodedText("a továbbiakban mint Vevő"), regularFont));

            doc.Add(new Paragraph(encodedText("(együttesen a továbbiakban: Felek) között az alulírott helyen és időben az alábbi feltételek szerint:"), regularFont));

            List list = new List(List.ORDERED);
            // 1
            list.Add(new ListItem(encodedText("/ Eladó kizárólagos tulajdonát képezi a ................ forgalmi rendszámú gyártmányú," +
                                                    "................. alvázszámú, ................fajtájú(pl: személygépkocsi, " +
                                                    "tehergépkocsi, pótkocsi, motorkerékpár stb) jármű.Az Eladó kijelenti, hogy a jármű per - és " +
                                                    "tehermentes, valamint annak tulajdonjogával szabadon rendelkezik.\n" +
                                                    "A járműhöz tartozó forgalmi engedély sorszáma: ................\n" +
                                                    "A járműhöz tartozó törzskönyv sorszáma: ................"), regularFont));
            // 2
            list.Add(new ListItem(encodedText("/ Eladó az 1./ pontban megjelölt járművet.........év...........hó............napon ...... óra"+
                ".......perc a Vevő birtokába, használatába adja"), regularFont));

            // 3
            regularFont = FontFactory.GetFont("Times New Roman", 13, Font.BOLD);
            list.Add(new ListItem(encodedText("/ A megjelölt jármű birtokba, használatba adásakor a kilométerszámláló műszer által" +
                "jelzett érték:.........km."), regularFont));

            // 4
            regularFont = FontFactory.GetFont("Times New Roman", 13);
            list.Add(new ListItem(encodedText("/ A tulajdonjog változás hatályba lépésének időpontja: .............év.................hónap.............nap."), regularFont));
            // 5
            list.Add(new ListItem(encodedText("/ Vevő kötelezettséget vállal arra, hogy a tulajdonosváltozást – annak a járműnyilvántartásban " +
                                                "történő átvezetése céljából – 15 napon belül bejelenti és a változás bejegyzésére irányuló " +
                                                "kérelmét jelen magánokirat egy eredeti példányának csatolásával, benyújtja az illetékes " +
                                                "közlekedési igazgatási hatósághoz.A Vevő a birtokbavétel napjától kezdődően köteles az 1. " +
                                                "pontban meghatározott járművel kapcsolatos valamennyi teher viselésére."), regularFont));

            // 6
            list.Add(new ListItem(encodedText("/ A tulajdonjog változás hatályba lépésének időpontja: .............év.................hónap.............nap."), regularFont));

            // 7
            list.Add(new ListItem(encodedText("/ A járműhöz tartozó okmányok Eladó részéről történő átadásának és Vevő részéről történő átvételének "+
                                                "dátuma: ...........év..............hó.........nap"), regularFont));

            // 8
            list.Add(new ListItem(encodedText("/ A felek kijelentik, hogy a szerződés tárgyát képező gépjármű bizalmi vagyonkezelés alapján fennálló " +
                                                "kezelt vagyonba tartozik / nem tartozik."), regularFont));

            // 9
            list.Add(new ListItem(encodedText("/ Jelen magánokirat a közlekedési igazgatási hatósági eljárásban történő felhasználás céljából, a " +
                                                "közúti közlekedési nyilvántartásról szóló 1999.évi LXXXIV törvényben(a továbbiakban:" +
                                                "Kknyt.) előírt bejelentési kötelezettség teljesítése érdekében, a közúti közlekedési" +
                                                "nyilvántartásba bejegyzett jármű tulajdonjogának, illetve üzembentartó személyének változását " +
                                                "igazoló teljes bizonyító erejű magánokiratnak a közlekedési igazgatási eljárásban történő " +
                                                "felhasználhatóságához szükséges kötelező tartalmi elemekről szóló 304 / 2009. (XII. 22.) Korm. " +
                                                "rendeletben meghatározottak szerint került elkészítésre."), regularFont));

            // 10
            list.Add(new ListItem(encodedText("/ Felek kijelentik, hogy ismerik a bejelentés nyilvántartásba történő bejegyzéshez fűződő " +
                                                "joghatásokat, valamint a bejelentés elmaradásának, illetve bejelentési kötelezettség késedelmes" +
                                                "teljesítésének jogkövetkezményeit, továbbá tisztában vannak azzal, hogy a teljes bizonyító erejű " +
                                                "magánokirat tartalmi követelményeinek meg nem felelő magánokirat a közlekedési igazgatási " +
                                                "eljárásban alkalmatlan a változás nyilvántartásba történő bejegyeztetésére."), regularFont));

            // 11
            list.Add(new ListItem(encodedText("/ Felek tudomásul veszik, hogy a Kknyt. alapján a járműnyilvántartás – a tulajdonszerző "+
                                                "bejelentéséig – tartalmazza a régi tulajdonos által teljesített bejelentés(jelen okirat) alapján a " +
                                                "tulajdonszerzőre vonatkozó, a Kknyt. 9. § (1) bekezdésében meghatározott adatokat."), regularFont));

            // 12
            list.Add(new ListItem(encodedText("/ Egyéb feltételek:\n")+ dotLine(850),regularFont));

            doc.Add(list);

            doc.Add(new Paragraph(encodedText("Felek a jelen magánokiratot – annak áttanulmányozását és értelmezését követően, mint akaratukkal" +
                                    "mindenben megegyezőt 2-2 eredeti példányban tanúk előtt jóváhagyólag aláírták."), regularFont));
            
            doc.Add(new Paragraph(encodedText("Kelt:") + dotLine(15) + encodedText("(város/község neve),") + dotLine(8)
                + encodedText("év") + dotLine(4) + encodedText("hó") +dotLine(4) + encodedText("napján."), regularFont));
            doc.Add(new Paragraph(dotLine(30) + "    " + dotLine(30) +encodedText("\n              Eladó                    Vevő"), regularFont));
            doc.Add(new Paragraph(encodedText("Előttünk mint tanúk előtt:"), regularFont));
            doc.Add(new Paragraph(encodedText("1.Családi és utónév:")+dotLine(25), regularFont));
            doc.Add(new Paragraph(encodedText("lakcím:")+dotLine(25), regularFont));
            doc.Add(new Paragraph(encodedText("2.Családi és utónév:")+dotLine(25), regularFont));
            doc.Add(new Paragraph(encodedText("lakcím:")+dotLine(25), regularFont));

            doc.Close();
        }
    }

}
