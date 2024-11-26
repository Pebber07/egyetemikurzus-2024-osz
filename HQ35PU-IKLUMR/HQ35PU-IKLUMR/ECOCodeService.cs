
namespace HQ35PUIKLUMR
{
    public class ECOCodeService
    {
        public static string GetOpeningName(string eco)
        {

            if (string.IsNullOrEmpty(eco))
            {
                return "Hiba"; 
            }

            char category = eco[0];
            
            int number = int.Parse(eco.Substring(1));

            if(!(category >= 'A' && category <= 'E') || !(number >= 0 &&  number <= 99))
            {
                return "Hiba";
            }

            switch (category)
            {
                case 'A':
                    if (number == 0)
                        return "Egyéb";
                    if (number == 1)
                        return "Larsen";
                    if ((number == 2) || (number == 3))
                        return "Bird";
                    if (number >= 4 && number <= 9)
                        return "Réti";
                    if (number >= 10 && number <= 39)
                        return "Angol";
                    if (number == 40)
                        return "e6b6f5";
                    if (number == 41)
                        return "Wade";
                    if (number == 42)
                        return "Modern";
                    if (number == 43 || number == 44 || number == 56 || (number >= 60 && number <= 79))
                        return "Benoni";
                    if (number == 45 || number == 46)
                        return "Trompovsky";
                    if (number == 47)
                        return "Vezérindiai";
                    if (number == 48)
                        return "Sötét_kettős_fianchetto";
                    if (number == 49)
                        return "Világos_kettős_fianchetto";
                    if (number == 50)
                        return "Sötét_kettős_fianchetto";
                    if (number == 51 | number == 52)
                        return "Budapestcsel";
                    if (number >= 53 && number <= 55)
                        return "Óindiai";
                    if (number >= 57 && number <= 59)
                        return "Benko";
                    if (number >= 80 && number <= 99)
                        return "Holland";
                    break;

                case 'B':
                    if (number == 0)
                        return "Királygyalog";
                    if (number == 1)
                        return "Skandináv";
                    if (number >= 2 && number <= 5)
                        return "Aljechin";
                    if (number == 6)
                        return "Modern";
                    if (number >= 7 && number <= 9)
                        return "Pirc";
                    if (number >= 10 && number <= 19)
                        return "CaroKann";
                    if (number == 20 || number == 21 || number == 27 || number == 28 || number == 29 || number == 50 || number == 53 || number == 54)
                        return "Szicíliai mellékvarik";
                    if (number == 22)
                        return "Alapin";
                    if (number == 23)
                        return "Grand Prix";
                    if (number >= 24 || number <= 26)
                        return "Zárt szicíliai";
                    if (number == 30 || number == 31)
                        return "Rossolimo";
                    if (number == 32)
                        return "Kalasnyikov";
                    if (number == 33)
                        return "Svesnyikov";
                    if (number >= 34 && number <= 39)
                        return "SzicíliaiGyorsítottFianchetto";
                    if (number == 40 || number == 44)
                        return "Paulsen";
                    if (number >= 41 && number <= 43)
                        return "KanPaulsen";
                    if (number >= 45 && number <= 49)
                        return "Taimanov";
                    if (number == 51 || number == 52)
                        return "Moszkvai";
                    if (number == 55 || number == 56 || (number >= 90 && number <= 99))
                        return "Najdorf";
                    if (number >= 57 && number <= 69)
                        return "KlasszikusSzicíliai";
                    if (number >= 70 && number <= 79)
                        return "Sárkány";
                    if (number >= 80 && number <= 89)
                        return "Scheveningeni";
                    break;

                case 'C':
                    if (number >= 0 && number <= 19)
                        return "Francia";
                    if (number == 20 || number == 40 || number == 44)
                        return "Királygyalog";
                    if (number == 21)
                        return "Dáncsel";
                    if (number == 22)
                        return "Középcsel";
                    if (number >= 23 && number <= 29)
                        return "Bécsi";
                    if (number >= 30 && number <= 39)
                        return "Királycsel";
                    if (number == 41)
                        return "Philidor";
                    if (number == 42 || number == 43)
                        return "Orosz";
                    if (number == 45 || number == 46)
                        return "Skót";
                    if (number >= 47 && number <= 49)
                        return "Négyeshuszár";
                    if (number == 50 || (number >= 53 && number <= 59))
                        return "Olasz";
                    if (number == 51 || number == 52)
                        return "Evanscsel";
                    if (number >= 60 && number <= 99)
                        return "Spanyol";
                    break;

                case 'D':
                    if (number == 0 || number == 1)
                        return "JobavaLondon";
                    if (number == 2)
                        return "London";
                    if (number == 3)
                        return "Torre";
                    if (number == 4 | number == 6)
                        return "Vezérgyalog";
                    if (number == 5)
                        return "Colle";
                    if (number == 7)
                        return "Csigorin";
                    if (number == 8 || number == 9)
                        return "Albin";
                    if ((number >= 10 && number <= 19) || (number >= 43 && number<= 51))
                        return "Szláv";
                    if (number >= 20 && number <= 29)
                        return "QGA";
                    if (number == 30 || number == 31 || number == 37 || (number >= 52 && number <= 69))
                        return "QGD";
                    if ((number >= 32 && number <= 36) || (number >= 40 || number <= 42))
                        return "Tarrasch";
                    if (number == 38 || number == 39)
                        return "Ragozin";
                    if (number >= 70 && number <= 99)
                        return "Grünfeld";
                    break;

                case 'E':
                    if (number == 0 || number == 10)
                        return "Vezérgyalog";
                    if (number >= 1 && number <= 9)
                        return "Katalán";
                    if (number == 11)
                        return "Bogoindiai";
                    if (number >= 12 && number <= 19)
                        return "Vezérindiai";
                    if (number >= 20 && number <= 59)
                        return "Nimzoindiai";
                    if (number >= 60 && number <= 99)
                        return "Királyindiai";
                    break;

                default:
                    return "Hiba";
                    
            } 

            return "Hiba";
        }
    }
}