using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Node
    {
        //creates node for the circular nexted list
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }

        /*Checks whether th specified node is present in the list or not*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() //Traverses the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty.\n");

            else
            {
                Console.WriteLine("\nThe records in the list are : \n");
                Node currentNode;
                for (currentNode = LAST; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "   " + LAST.next.name);
        }
        public void addNode()/*Adds a Node in the list*/
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            /*If the node to be inserted is the first node*/
            if (LAST == null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo == LAST.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }

                newnode.next = LAST;
                LAST = newnode;
                return;
            }
        }
        public bool delNode(int rollNo)/*Deletes the specified node from the list*/

        {
            Node previous, current;
            previous = current = null;
            /*Check if the specified node is present in the list or not*/
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                /*try catch to catch an error*/
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list"); 
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. View all the records in the list");
                    Console.WriteLine("5. Delete a record from the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    //Switch case untuk melihat apakah yang dipilih benar atau salah
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("Record found");
                                    Console.WriteLine("\nStudent Number: " + curr.rollNumber);
                                    Console.WriteLine("\nStudent Name: " + curr.name);
                                }

                            }
                            break;

                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;

                        case '4':
                            {
                                obj.traverse();

                            }
                            break;

                        case '5':
                            if (obj.listEmpty())
                            {
                                Console.WriteLine("\nList is empty");
                                break;
                            }
                            Console.Write("\nEnter the roll number of the student whose record is to be deleted : ");
                            int rollNo = Convert.ToInt32(Console.ReadLine());
                            if (obj.delNode(rollNo) == false)
                                Console.WriteLine("\nRecord not found.");
                            else
                                Console.WriteLine("Record with roll number " + rollNo + " deleted ");
                            break;


                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

/* Jawaban Esai
1.-Array adalah struktur data yang berisi kumpulan elemen data tipe serupa sedangkan daftar Linked dianggap
   sebagai struktur data non-primitif berisi kumpulan elemen tertaut yang tidak berurutan yang dikenal sebagai node.

2.-Single Linked List merupakan suatu linked list yang hanya memiliki satu variabel pointer saja. 
   Dimana pointer tersebut menunjuk ke node selanjutnya, biasanya field pada tail menunjuk ke NULL.
  -Double Linked List merupakan suatu linked list yang memiliki dua variabel pointer yaitu pointer
   yang menunjuk ke node selanjutnya dan pointer yang menunjuk ke node sebelumnya. Setiap head dan tailnya juga menunjuk ke NULL.
  -Circular Linked List merupakan suatu linked list dimana tail (node terakhir) menunjuk ke head (node pertama). 
   Jadi tidak ada pointer yang menunjuk NULL.

3. Contoh aplikasi yang mengimplementasikan :
* Single linked list : Contohnya aplikasi yang bisa memutarkan musik, dimana lagu di pemutar musik bisa ditautkan ke lagu sebelumnya
dan juga bisa memutar lagu dari awal sampe akhir
* Double linked list : Contohnya digunakan oleh browser untuk menerapkan navigasi mundur dan maju dari halaman web yang dikunjungi yaitu tombol mundur dan maju.
* Circular linked list : Contohnya adalah game Multiplayer. Semua Pemain disimpan dalam Daftar Tertaut Melingkar 
*dan penunjuk terus bergerak maju saat kesempatan pemain berakhir.


 
4.Keuntungan menggunakan dynamic struktur data :
   -Hanya menggunakan ruang yang dibutuhkan setiap saat. 
   -Membuat penggunaan memori secara efisien. 
   -Penyimpanan yang tidak lagi membutuhkan dapat dikembalikan untuk sistem untuk penggunaan lain

5.Proses memasukkan data
* Single Linked List
  1.Alokasikan memori untuk node baru.
  2.Tetapkan nilai ke bidang data node baru.
  3 if START adalah NULL, maka:
    b. Buat titik MULAI ke simpul baru.
    c. Pergi ke langkah 6.
  4.Temukan node terakhir dalam daftar, dan tandai sebagai currentNode. Untuk menemukan node terakhir dalam daftar, jalankan langkah-langkah berikut:
    a.Tandai node pertama sebagai currentNode.
    b.Ulangi langkah c hingga penerus currentNode menjadi NULL.
    c.Buat currentNode menunjuk ke node berikutnya secara berurutan.
  5.Buat bidang berikutnya dari currentNode menunjuk ke node baru.
  6.Buat bidang berikutnya dari titik simpul baru ke NULL.

* Double Linked List
  A. Inserting a Node at the Beginning of the List 
     1.Alokasikan memori untuk node baru.
     2.Tetapkan nilai ke bidang data node baru.
     3.Buat bidang berikutnya dari simpul baru menunjuk ke simpul pertama dalam daftar.
     4.Buat bidang sebelumnya dari START menunjuk ke simpul baru.
     5.Buat bidang sebelumnya dari titik simpul baru ke NULL.
     6.Buat MULAI, arahkan ke simpul baru.
   B.Inserting a Node Between Two Nodes in the List 
     1.Identifikasi node di mana node baru akan disisipkan. Tandai masing-masing sebagai sebelumnya dan saat ini. Untuk menemukan sebelumnya dan saat ini, jalankan langkah-langkah berikut:
        a.Buat titik saat ini ke simpul pertama.
        b.Buat poin sebelumnya ke NULL.
        c.Ulangi langkah d dan e hingga current.info > newnode.info atau current = NULL.
        d.Buat poin sebelumnya menjadi saat ini.
        e.Buat titik saat ini ke node berikutnya secara berurutan.
     2.Alokasikan memori untuk node baru.
     3.Tetapkan nilai ke bidang data node baru.
     4.Buat bidang berikutnya dari titik simpul baru ke saat ini.
     5.Jadikan bidang sebelumnya dari titik simpul baru ke sebelumnya.
     6.Buat bidang sebelumnya dari titik saat ini ke simpul baru.
     7.Buat bidang berikutnya dari titik sebelumnya ke simpul baru.
   C.Inserting a Node at the end of the List
     1.Alokasikan memori untuk node baru.
     2.Tetapkan nilai ke bidang data node baru.
     3.Jadikan bidang berikutnya dari simpul yang ditandai sebagai titik TERAKHIR ke simpul baru.
     4.Buat bidang sebelumnya dari titik simpul baru ke simpul bertanda TERAKHIR.
     5.Buat bidang berikutnya dari titik simpul baru ke NULL.
     6.Tandai simpul baru sebagai TERAKHIR

* Circular Linked List 
  A.Inserting a Node at the Beginning of the List 
     1.Alokasikan memori untuk node baru.
     2.Tetapkan nilai ke bidang data node baru.
     3.Buat bidang berikutnya dari titik simpul baru ke penerus LAST.
     4.Buat bidang LAST berikutnya menunjuk ke simpul baru.
  B.Inserting a Node Between Two Nodes in the List 
     1.Buat titik saat ini ke simpul pertama.
     2.Buat poin sebelumnya ke NULL.
     3.Ulangi langkah 4 dan 5 hingga current.info > newnode.info atau sebelumnya = TERAKHIR.
     4.Buat poin sebelumnya menjadi saat ini.
     5.Buat titik saat ini ke node berikutnya secara berurutan.
  C.Inserting a Node at the End of the List 
     1.Alokasikan memori untuk node baru.
     2.Tetapkan nilai ke bidang data node baru.
     3.Buat bidang berikutnya dari titik simpul baru ke penerus LAST.
     4.Buat bidang LAST berikutnya menunjuk ke simpul baru.
     5.Tandai titik LAST ke simpul baru.

6. Proses menghapus data
* Single linked list
  A.Deleting a Node From the Beginning of the List 
     1.Tandai node pertama dalam daftar sebagai saat ini.
     2.Buatlah titik MULAI ke simpul berikutnya dalam urutannya.
     3.Lepaskan memori untuk node yang ditandai sebagai arus.
  B.Deleting a Node Between two Nodes in the List 
     1.Cari node yang akan dihapus. Tandai node yang akan dihapus sebagai saat ini dan pendahulunya seperti sebelumnya. Untuk menemukan saat ini dan sebelumnya, jalankan langkah-langkah berikut:
        a.Setel sebelumnya = MULAI
        b.Setel arus = MULAI
        c.Ulangi langkah d dan e hingga node ditemukan atau arus menjadi NULL.
        d.Buat poin sebelumnya menjadi saat ini.
        e.Buat titik saat ini ke node berikutnya secara berurutan.
     2.Buat bidang berikutnya dari titik sebelumnya ke penerus saat ini.
     3.Lepaskan memori untuk node yang ditandai sebagai saat ini.
* Double linked list
  A.Deleting a Node From the Beginning of the List 
     - Dengan cara tandai node pertama dalam daftar sebagai saat ini.
    - Membuat titik MULAI ke simpul berikutnya secara berurutan.
    - Jika START bukan NULL: / * jika node yang akan dihapus bukan satusatunya node dalam daftar * / lalu tetapkan NULL ke bidang prev dari node yang ditandai sebagai START.
    - Lalu lepaskan memori untuk node yang ditandai sebagai arus.
  B.Deleting a Node Between Two Nodes in the List
     1.Dengan cara tandai node yang akan dihapus sebagai saat ini dan pendahulunya seperti sebelumnya.
         a.Membuat poin sebelumnya menjadi NULL. // Atur sebelumnya = NULL
         b.Membuatuat titik saat ini ke node pertama dalam daftar tertaut. // Set saat ini = MULAI
         c.Ulangi langkah d dan e hingga node ditemukan atau saat ini menjadi NULL.
         d.Membuat poin sebelumnya menjadi saat ini.
         eMembuat titik saat ini ke node berikutnya secara berurutan.
      2.Membuat bidang berikutnya dari titik sebelumnya ke penerus arus.
      3.Membuat bidang prev penerus titik saat ini ke sebelumnya.
      4.Lalu lepaskan memori untuk node yang ditandai sebagai arus.
* Circular linked list
  A. Deleting a Node From the Beginning of the List 
      1.Jika node yang akan dihapus adalah satusatunya node dalam daftar: // Jika LAST menunjuk ke dirinya sendiri.
         a.Tandai LAST sebagai NULL.
         b.Keluar.
      2.Membuat poin saat ini ke penerus terakhir.
      3.Membuat bidang berikutnya dari titik terakhir ke penerus arus.
      4.Lepaskan memori untuk node yang ditandai sebagai arus.
  B. Deleting a Node Between Two Nodes in the List
      1.Membuat poin sebelumnya ke penerus terakhir.
      2.Membuat poin saat ini ke penerus terakhir.
      3.Ulangi langkah 4 dan 5 hingga node ditemukan, atau sebelumnya = LAST.
      4.Membuat titik sebelumnya menjadi saat ini.
      5.Membuat titik saat ini ke node berikutnya secara berurutan.
  C. Deleting a Node From the End of the List 
      1.Membuat titik saat ini ke terakhir.
      2.Tandai pendahulu terakhir seperti sebelumnya. Untuk menemukan pendahulu LAST, lakukan langkahlangkah berikut:
         a.Membuat poin sebelumnya ke penerus terakhir.
         b.Ulangi langkah c hingga penerus sebelumnya menjadi terakhir.
         c.Membuat titik sebelumnya ke simpul berikutnya dalam urutannya.
      3.Membuat bidang berikutnya dari titik sebelumnya ke penerus terakhir.
      4.Tandai sebelumnya sebagai terakhir.
      5.Lepaskan memori untuk node yang ditandai sebagai arus

7.Proses mencari data
* Single linked list 
     1.Dimulai dari node (set ke Head of list), dan node terakhir (setel ke NULL awalnya) diberikan. 
     2.Tengah dihitung menggunakan pendekatan dua petunjuk. 
     3.If data tengah cocok dengan nilai pencarian yang diperlukan, kembalikan. 
     4.Else if jika data tengah <nilai, pindah ke upper half(pengaturan mulai ke tengah berikutnya). 
     5.Else pergi ke lower half(pengaturan terakhir ke tengah).
* Double linked list 
     1.Dimulai dari node (set ke Head of list), dan node terakhir (setel ke NULL awalnya) diberikan. 
     2.Tengah dihitung menggunakan pendekatan dua petunjuk. 
     3.If data tengah cocok dengan nilai pencarian yang diperlukan, kembalikan. 
     4.Else if jika data tengah <nilai, pindah ke upper half(pengaturan mulai ke tengah berikutnya). 
     5.Else pergi ke lower half(pengaturan terakhir ke tengah).
* Circular linked list 
     1.Dimulai dari node (set ke Head of list), dan node terakhir (setel ke NULL awalnya) diberikan. 
     2.Tengah dihitung menggunakan pendekatan dua petunjuk. 
     3.If data tengah cocok dengan nilai pencarian yang diperlukan, kembalikan. 
     4.Else if jika data tengah <nilai, pindah ke upper half(pengaturan mulai ke tengah berikutnya). 
     5.Else pergi ke lower half(pengaturan terakhir ke tengah).


8.Proses menampilkan data
* Single linked list
    1.Periksa apakah daftar Kosong (head == NULL).
    2.Jika kosong maka, tampilkan "List is Empty" dan hentikan fungsinya.
    3.Jika tidak kosong, tentukan "temp" penunjuk node dan inisialisasi dengan head.
    4.Tetap tampilkan temp, data dengan tanda panah (->) hingga temp mencapai node terakhir.
    5.Terakhir menampilkan temp, data dengan panah menunjuk ke NULL (temp -> data - > NULL).

* Double linked list
    1.Periksa apakah daftar Kosong (head == NULL).
    2.Jika Kosong, maka tampilkan 'List is Empty' dan hentikan fungsinya.
    3.Jika Tidak Kosong, tentukan penunjuk Node 'temp' dan inisialisasi dengan head.
    4.Tetap tampilkan temp -> data dengan panah (--->) sampai temp mencapai node terakhir.
    5.Akhirnya menampilkan temp -> data dengan panah menunjuk ke head → data.

* Circular linked list
    1.Periksa apakah daftar Kosong (head == NULL)
    2.Jika Kosong, maka tampilkan 'List is Empty' dan hentikan fungsinya.
    3.Jika Tidak Kosong, tentukan penunjuk Node 'temp' dan inisialisasi dengan head
    4.Tetap tampilkan temp -> data dengan panah (--->) sampai temp mencapai node terakhir
    5.Akhirnya menampilkan temp Periksa apakah daftar Kosong (head == NULL)
    6.Jika Kosong, maka tampilkan 'List is Empty' dan hentikan fungsinya.
    7.Jika tidak Kosong, maka tentukan 'temp' penunjuk Node dan inisialisasi dengan head.
    8.Tampilkan 'NULL <---'.
    9.Tetap tampilkan temp → data dengan panah (<===>) sampai temp mencapai node terakhir
    10.Terakhir, tampilkan temp → data dengan panah menunjuk ke NULL (temp → data ---> NULL).-> data dengan panah menunjuk ke head → data.


 
 */
