using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dakon
{
    class Program
    {
        //Referensi : https://www.youtube.com/watch?v=zAGYhT05AIc
        //Kondisi-kondisi permainan dakon :
        //Ronde 1
        // 1. berjalan secara berputar searah jarum jam
        // 2. deposit biji pada store house (lubang besar) milik sendiri bukan milik musuh
        // 3. jika biji di tangan habis pada lubang yang terdapat biji, maka perputaran dilanjutkan dengan mengambil seluruh biji pada lubang tersebut
        // 4. jika biji di tangan habis pada store house (lubang besar) milik sendiri, maka player tersebut mendapat jatah giliran lagi
        // 5. jika biji di tangan habis pada lubang kosong milik musuh, maka giliran pemain tersebut berakhir
        // 6. jika biji di tangan habis pada lubang kosong milik sendiri, maka ambil seluruh biji pada lubang milik musuh yang berseberangan
        // 
        //Ronde 2
        //1. sama seperti ronde 1, hanya saja sebagai permulaan, seluruh isi storehouse didistribusikan ke masing2 lubang, 
        //   jika tidak cukup untuk memenuhi 1 lubang, maka sisanya dibiarkan di storehouse
        //2. jika ada lubang yang kosong/tidak terisi, maka lubang tersebut dinyatakan burnt/tidak bisa digunakan

        static void Main(string[] args)
        {
            PapanDakon papanDakon1 = PapanDakon.GetInstance();
            PointerTangan tangan = new PointerTangan();

            //Round 1
            //Print Kondisi awal Papan Dakon pada Round 1 
            papanDakon1.printPapanDakon();

            //Permainan dimulai oleh Player 1
            tangan.playerInTurn = "Player 1";
            Console.Write("\nGiliran "+tangan.playerInTurn+", Silahkan pilih posisi (1-7) : ");
            
            //Player 1 memilih house yang akan digunakan sebagai titik awal giliran
            tangan.indexPosisi = getHousePilihanUser(tangan.playerInTurn);

            //Ambil seluruh marbles pada lubang/house tersebut
            tangan.marblesDiTangan = papanDakon1.listLubang[tangan.indexPosisi].marblesCount;
            papanDakon1.listLubang[tangan.indexPosisi].marblesCount = 0;

            Console.WriteLine(tangan.playerInTurn +" memilih posisi : " + tangan.indexPosisi + " dengan jumlah marbles " + tangan.marblesDiTangan);
            papanDakon1.printPapanDakon();

            Console.ReadLine();
        }

        public static int getHousePilihanUser(string playerInThisTurn)
        {
            bool isValidInput = false;
            int houseNum=-1;
            bool isNumeric;
            string input;
            while (!isValidInput)
            {
                input = Console.ReadLine();
                isNumeric = int.TryParse(input, out houseNum);

                if (isNumeric && houseNum >= 0 && houseNum < 8)
                    isValidInput = true;
                else
                {
                    Console.WriteLine("Input tidak valid!");
                }
            }

            if (playerInThisTurn == "Player 1")
                return houseNum;
            else
                return houseNum + 8;
        }
    }
}
