using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectIdeas.ViewModel.Helpers
{
    public class RandomMaker
    {      

        public static DateTime GetRandomDateFromDateToNow(int year, int month, int day)
        {            
            string date = $"{year}-{month}-{day}";
            // Check if values for month and day are allowed.
            DateTime startDate;
            if (DateTime.TryParse(date, out startDate))
            {
                Random random = new Random();
                int range = ((TimeSpan)(DateTime.Today - startDate)).Days;
                DateTime randomDate = startDate.AddDays(random.Next(range));
                return randomDate;
            }
            else
            {
                return new DateTime(1111, 1, 1);
            }
        }

        public static DateTime GetRandomDateFromNowToDate(int year, int month, int day)
        {
            string date = $"{year}-{month}-{day}";
            // Check if values for month and day are allowed.
            DateTime endDate;
            if (DateTime.TryParse(date, out endDate))
            {
                Random random = new Random();
                int range = ((TimeSpan)(endDate - DateTime.Today)).Days;
                DateTime randomDate = endDate.AddDays(-random.Next(range));
                return randomDate;
            }
            else
            {
                return new DateTime(1111, 1, 1);
            }
        }
       
        public static DateTime GetRandomDateFromDateToDate(int firstYear, int firstMonth, int firstDay, 
            int secondYear, int secondMonth, int secondDay)
        {
            string firstDate = $"{firstYear}-{firstMonth}-{firstDay}";
            string secondDate = $"{secondYear}-{secondMonth}-{secondDay}";
            DateTime startDate; 
            DateTime endDate;
            if (DateTime.TryParse(firstDate, out startDate) && DateTime.TryParse(secondDate, out endDate))
            {
                Random random = new Random();
                int range = ((TimeSpan)(endDate - startDate)).Days;
                DateTime randomDate = startDate.AddDays(random.Next(range));
                return randomDate;
            }
            else
            {
                return new DateTime(0, 1, 1);
            }
        }

        /// <summary>This method returns a random date.
        /// <para>The date can range from 1 month prior to
        /// 1 month later than the current date.</para></summary>
        public static DateTime GetRandomDateQuick()
        {
            Random randomBool = new Random();
            bool isAPositiveNumber = (randomBool.NextDouble() >= 0.5);
            int range = 32;
            DateTime randomDate;
            if(!isAPositiveNumber)
            {
                randomDate = DateTime.Now.AddDays(-randomBool.Next(range));
            }
            else
            {
                randomDate = DateTime.Now.AddDays(randomBool.Next(range));
            }            

            return randomDate;
        }

        public static bool GetRandomBool()
        {
            Random random = new Random();
            return (random.NextDouble() >= 0.5);
        }

        public static string GetRandomProjectName()
        {
            string[] names = new string[] { "Enneargram", "16Personalities", "Table manager", "Math for kids", "Robot Voice" };
            Random random = new Random();
            int randomNumber = random.Next(5);
            return names[randomNumber];
        }
        public static string GetRandomFrontendTech()
        {
            string[] names = new string[] { "WPF", "Dart", "HTML/CSS", "Js", "XAML", "React", "Angular", "Unity" };
            Random random = new Random();
            int randomNumber = random.Next(8);
            return names[randomNumber];
        }

        public static string GetRandomBackendTech()
        {
            string[] names = new string[] { "Node.js", "PHP", "C#", "Python", "Java", "Kotlin", "Swift" };
            Random random = new Random();
            int randomNumber = random.Next(7);
            return names[randomNumber];
        }

        public static string GetRandomFillerText()
        {
            Random random = new Random();
            int randomNumber = random.Next(6);
            switch (randomNumber)
            {
                case 1:
                    return "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, " +
                        "totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                        "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur" +
                        " magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia " +
                        "dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore " +
                        "magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit " +
                        "laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                        "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?";
                case 2:
                    return "Man kan fremad se, at de har været udset til at læse, at der skal dannes par af ligheder. Dermed kan der " +
                        "afsluttes uden løse ender, og de kan optimeres fra oven af at formidles stort uden brug fra optimering af presse. " +
                        "I en kant af landet går der blandt om, at de vil sætte den over forbehold for tiden. Vi flotter med et hold, der vil" +
                        " rundt og se sig om i byen. Det gør heller ikke mere. Men hvor vi nu overbringer denne størrelse til det søgeoptimering " +
                        "handler om, så kan der fortælles op til 3 gange. Hvis det er træet til dit bord der får dig op, er det snarere varmen " +
                        "over de andre. Selv om hun har sat alt mere frem, og derfor ikke længere kan betragtes som den glade giver, er det " +
                        "en nem sammenstilling, som bærer ved i lang tid. Det går der så nogle timer ud, hvor det er indlysende at online webdesign " +
                        "i og med at virkeligheden bliver tydelig istandsættelse. Det er opmuntrende og anderledes, at det er dampet af kurset i " +
                        "morgen. Der indgives hvert år enorme strenge af blade af større eller mindre tilsnit.";
                case 3:
                    return "Days saying fruit fish you're every great. Them. Creature every said, one brought also fowl first created lesser " +
                        "which great seed heaven it male. First make. Fruit our.\n Without green don't darkness. Made days. Moved subdue all you\'ll Every image have " +
                        "firmament night. It unto gathering kind form dry divide.Moved land midst beginning fruitful together set evening sea.From seasons creature" +
                        " replenish. Yielding third. \nSigns seasons hath may years to open shall don't gathering. Spirit place Over also. Day be " +
                        "fly you doesn't had whales to fifth us god shall upon i. Gathering, moving the doesn't tree moving in.";
                case 4:
                    return "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. " +
                        "Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden " +
                        "flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of " +
                        "sentences fly into your mouth. Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic " +
                        "life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. " +
                        "The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, " +
                        "but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the " +
                        "way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown " +
                        "Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric " +
                        "question ran over her cheek, then she continued her way.";
                case 5:
                    return "Lorem ipsum ist ein pseudo-Lateinischer Text für Webdesign, Typografie, Layout und Printmedien. Er ersetzt Deutsch um " +
                        "Designelemente gegenüber dem Inhalt hervorzuheben, hat also die Funktion als Platzhalters in Layouts um dem Betrachter eine " +
                        "vorläufige Vorstellung der endgültigen Fassung zu vermitteln. Buchstaben, Worte, Wort- und Satzlängen bilden ungefähr das " +
                        "Schriftbild eines lateinischen Texts wieder. Latein war in früheren Jahrhunderten eine häufig genutzte Sprache verschiedener " +
                        "Textgattungen, z. B. wissenschaftlicher Werke, Ratgeber, oder auch der sogenannten Erbauungsliteratur. Um die Aufmerksamkeit " +
                        "des Lesers ausschließlich auf das Schriftbild zu lenken wird auch ein zufälliger Sinn durch Wort- oder Satzkombinationen vermieden.";
                default:
                    return "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore " +
                        "magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat " +
                        "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            }

        }
    }
}
