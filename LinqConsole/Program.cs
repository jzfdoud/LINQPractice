using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace LinqConsole
{
    class Program
    {
        static int[] xints = { 863, 550, 970, 341, 293, 732, 356, 699, 593, 553,
                726, 865, 646, 737, 986, 231, 288, 314, 132, 628,
                839, 465, 137, 905, 456, 204, 181, 144, 285, 409,
                970, 135, 313, 351, 701, 535, 572, 571, 813, 160,
                435, 773, 564, 344, 608, 115, 490, 965, 142, 543,
                813, 802, 274, 342, 812, 976, 184, 291, 720, 267,
                144, 200, 299, 292, 458, 294, 263, 823, 932, 375,
                631, 962, 916, 448, 622, 711, 510, 765, 474, 904,
                310, 460, 963, 934, 375, 203, 488, 894, 655, 807,
                254, 464, 565, 463, 872, 965, 733, 289, 720, 904 };

        static int[] yints = { 918, 211, 821, 528, 339, 871, 751, 446, 379, 556,
                294, 127, 390, 385, 466, 254, 811, 784, 864, 732,
                790, 347, 574, 190, 335, 694, 794, 356, 122, 505,
                678, 233, 103, 174, 439, 926, 417, 878, 900, 618,
                341, 654, 389, 763, 910, 165, 667, 630, 834, 528,
                992, 618, 407, 559, 394, 184, 745, 338, 195, 551,
                932, 935, 414, 432, 172, 438, 491, 605, 532, 905,
                767, 917, 386, 531, 180, 713, 696, 934, 953, 958,
                866, 231, 403, 100, 856, 653, 368, 799, 755, 641,
                524, 715, 522, 155, 704, 214, 174, 594, 689, 392 };

        static int[] zints = { 822, 287, 886, 897, 398, 163, 868, 800, 977, 766,
                847, 926, 644, 438, 971, 961, 638, 676, 423, 630,
                546, 680, 638, 549, 354, 310, 630, 817, 483, 459,
                648, 253, 820, 810, 237, 179, 343, 313, 553, 618,
                475, 686, 715, 676, 823, 348, 235, 231, 417, 829,
                917, 354, 515, 858, 324, 718, 297, 808, 853, 825,
                461, 701, 989, 903, 949, 373, 596, 163, 166, 983,
                407, 313, 186, 428, 254, 298, 673, 687, 396, 915,
                968, 585, 144, 888, 402, 590, 376, 470, 575, 794,
                927, 357, 911, 389, 853, 451, 927, 412, 725, 659 };



        static void ClassLinqPractice()
        {
            //print off all zints that are greater than the average of the zints
            //check this code with ken, might have different numbers, dont think i have all ints > avg
            var aboveAvgZints = from z in zints
                                where z > zints.Average()
                                select z;
            foreach(var i in aboveAvgZints)
                Console.WriteLine($"{i}");
            Console.WriteLine();


            //number that exists in both xints and zints
            var commonXandZints = from x in xints
                                   join z in zints
                                   on x equals z
                                   orderby x
                                   select x;
            Console.WriteLine("In common");
             foreach(var i in commonXandZints)
                Console.WriteLine($"{i}");


            //sum for all arrays if hundreds position is odd
            var sumOfOddHundredsX = (from x in xints
                                    where x >= 100 && x <= 199 || x >= 300 && x <= 399 || x >= 500 && x <= 599 || x >= 700 && x <= 799 || x >= 900 && x <= 999
                                    select x).Sum();
            Console.WriteLine($"Sum of Odd hundreds X = {sumOfOddHundredsX}");
            var sumOfOddHundredsY = (from y in yints
                                     where y >= 100 && y <= 199 || y >= 300 && y <= 399 || y >= 500 && y <= 599 || y >= 700 && y <= 799 || y >= 900 && y <= 999
                                     select y).Sum();
            Console.WriteLine($"Sum of Odd hundreds Y = {sumOfOddHundredsY}");
            var sumOfOddHundredsZ = (from z in zints
                                     where z >= 100 && z <= 199 || z >= 300 && z <= 399 || z >= 500 && z <= 599 || z >= 700 && z <= 799 || z >= 900 && z <= 999
                                     select z).Sum();
            Console.WriteLine($"Sum of Odd hundreds Z = {sumOfOddHundredsZ}");

            // dads easier way for sum of hundreds with odd position
            var sum2 = from i in yints
                       let h = i / 100
                       where h % 2 != 0
                       select i;

            //min and max for xints array
            var xintsMin = (from x in xints
                            select x).Min();
            var xintsMax = (from x in xints
                           select x).Max();
            Console.WriteLine($"xints min = {xintsMin} max = {xintsMax}");
            // average of all arrays
            var xIntsA = (from x in xints
                         select x).Average();
            var yIntsA = (from y in yints
                         select y).Average();
            var zIntsA = (from z in zints
                         select z).Average();
            Console.WriteLine($"Averages: xint={xIntsA} yint={yIntsA} zint={zIntsA}");
        }


        static void TestLinqQuerySyntax() 
        {
            var qresult = from i in ints
                         where i >= 300 && i <= 499
                         orderby i descending
                         select i;

            var myResult = from i in ints
                          where i >= 800 || i <= 300
                          select i;
            Console.WriteLine($"My result = {myResult.Sum()}");

            var mresult = ints.Where(i => i >= 300 && i <= 499)
                .Sum(i => i);
            Console.WriteLine($"{mresult}");
            //foreach(var i in mresult)
            //{
            //    Console.Write($"{i} ");
            //}
        }
        static int[] ints = {340,380,691,470,699,
                             447,115,837,466,592,
                             418,358,195,217,562,
                             811,647,687,846,411 };


        static void Main(string[] args)
        {
            ClassLinqPractice(); 
        }





    }
}
