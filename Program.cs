using System;
using System.Text;

namespace Buoi02_DanhSach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (args.Length > 0)
            {
                string chonNhanh = args[0];
                Console.WriteLine("Chọn bài: " + chonNhanh);
                switch (chonNhanh)
                {
                    case "1": B1C4.Run(); break;
                    case "2": B2C4.Run(); break;
                    case "3": B3C4.Run(); break;
                    case "4": B4C4.Run(); break;
                    case "5": B5C4.Run(); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
                return;
            }

            
            while (true)
            {
                Console.WriteLine("\n========== BÀI TẬP ==========");
                Console.WriteLine("1. Bài 1 Chương 4 - Nhập mảng, hiển thị và chèn phần tử x vào vị trí k");
                Console.WriteLine("2. Bài 2 Chương 4 - Quản lý danh sách nhân viên (Thực lĩnh, Lương CB, Sắp xếp)");
                Console.WriteLine("3. Bài 3 Chương 4 - Ma trận vuông (Tổng, Dương nhỏ nhất, Chéo phụ, Chéo chính)");
                Console.WriteLine("4. Bài 4 Chương 4 - DSLK đơn số nguyên dương (Đếm x, Dương nhỏ nhất, Xóa x)");
                Console.WriteLine("5. Bài 5 Chương 4 - DSLK đơn l (Max, Tổng, SNT, Âm/0/Dương, Đếm x, Dương nhỏ nhất)");

                Console.WriteLine("0. Thoát");
                Console.Write("Chọn bài: ");

                string chon = Console.ReadLine();

                Console.WriteLine();

                switch (chon)
                {
                    case "1": B1C4.Run(); break;
                    case "2": B2C4.Run(); break;
                    case "3": B3C4.Run(); break;
                    case "4": B4C4.Run(); break;
                    case "5": B5C4.Run(); break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
