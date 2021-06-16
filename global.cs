﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpanpinjam
{
    class global
    {
        public static string username;
        public static string userid;
    }

    public static class Rupiah
    {
        public static string ToRupiah(this int angka)
        {
            return String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", angka);
        }
        /**
         * // Usage example: //
         * int angka = 10000000;
         * System.Console.WriteLine(angka.ToRupiah()); // -> Rp. 10.000.000
         */

        public static int ToAngka(this string rupiah)
        {
            return int.Parse(System.Text.RegularExpressions.Regex.Replace(rupiah, @",.*|\D", ""));
        }
        /**
         * // Usage example: //
         * string rupiah = "Rp 10.000.123,00";
         * System.Console.WriteLine(rupiah.ToAngka()); // -> 10000123
         */
    }
}
