# Buoi02_DanhSach

- Họ tên: Vũ Văn Long
- MSV: 10125201
- Lớp: 124251

## Bài đã làm

### chương4

| Bài | Nội dung                                                                                                                                                    |
| --- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1   | Nhập mảng n số nguyên dương, hiển thị danh sách và chèn phần tử x vào vị trí k                                                                              |
| 2   | Quản lý danh sách nhân viên: tính tổng thực lĩnh, tìm lương CB thấp nhất, đếm thưởng >= 1.200.000, sắp xếp (phòng ban tăng, mã NV giảm) và tăng lương CB 5% |
| 3   | Nhập ma trận vuông cấp n: tính tổng các phần tử, tìm số dương nhỏ nhất, tính tổng đường chéo phụ và kiểm tra đường chéo chính tăng dần                      |
| 4   | Danh sách liên kết đơn số nguyên dương (pHead): đếm số bằng x, tìm số dương nhỏ nhất và xóa phần tử x đầu tiên                                              |
| 5   | Danh sách liên kết đơn số nguyên l: tìm số lớn nhất, tính tổng, đếm số nguyên tố, đếm số âm/0/dương, đếm số bằng x và tìm số dương nhỏ nhất                 |

## Lệnh chạy

### chương4

```bash
dotnet run 1
dotnet run 2
dotnet run 3
dotnet run 4
dotnet run 5
```

## Kết quả chạy

### chương4

### bài1

```csharp
using System;

namespace Buoi02_DanhSach
{
    static class B1C4
    {
        public static void Run()
        {
            Console.WriteLine("--- BÀI TẬP 1: MẢNG SỐ NGUYÊN DƯƠNG ---");

            int n = hamhotro.DocSo("Nhap so phan tu n", 5);
            if (n <= 0) return;

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = hamhotro.DocSo("Nhap a[" + i + "]", (i + 1) * 3);
            }

            Console.Write("Danh sach phan tu: ");
            hamhotro.InMang(a);

            int x = hamhotro.DocSo("Nhap phan tu x can chen", 99);
            int k = hamhotro.DocSo("Nhap vi tri k can chen", 2);

            if (k < 0 || k > n)
            {
                Console.WriteLine("Vi tri chen khong hop le!");
                return;
            }

            int[] tmp = new int[n + 1];
            for (int i = 0; i < k; i++)
                tmp[i] = a[i];

            tmp[k] = x;

            for (int i = k; i < n; i++)
                tmp[i + 1] = a[i];

            a = tmp;

            Console.Write("Mang sau khi chen: ");
            hamhotro.InMang(a);
        }
    }
}
```

#### kết quả

```text
Chọn bài: 1
--- BÀI TẬP 1: MẢNG SỐ NGUYÊN DƯƠNG ---
Nhap so phan tu n (Enter = 5):
Nhap a[0] (Enter = 3):
Nhap a[1] (Enter = 6):
Nhap a[2] (Enter = 9):
Nhap a[3] (Enter = 12):
Nhap a[4] (Enter = 15):
Danh sach phan tu: 3 6 9 12 15
Nhap phan tu x can chen (Enter = 99):
Nhap vi tri k can chen (Enter = 2):
Mang sau khi chen: 3 6 99 9 12 15
```

### bài2

```csharp
using System;

namespace Buoi02_DanhSach
{
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
        public int ThucLinh;

        public NhanVien(string ma, string ten, int nam, string phong, int luong, int thuong)
        {
            MaNV = ma;
            Hoten = ten;
            Namsinh = nam;
            Phongban = phong;
            LuongCB = luong;
            Thuong = thuong;
            ThucLinh = luong + thuong;
        }
    }

    static class B2C4
    {
        static void InDS(NhanVien[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine(ds[i].MaNV + " | " + ds[i].Hoten + " | " + ds[i].Phongban + " | LuongCB: " + ds[i].LuongCB + " | Thuong: " + ds[i].Thuong + " | ThucLinh: " + ds[i].ThucLinh);
            }
        }

        public static void Run()
        {
            Console.WriteLine("--- BÀI TẬP 2: DANH SÁCH NHÂN VIÊN ---");
            NhanVien[] ds = new NhanVien[3];
            ds[0] = new NhanVien("NV03", "Tran Van B", 1995, "Ke toan", 8000000, 1500000);
            ds[1] = new NhanVien("NV01", "Nguyen Van A", 1998, "Kinh doanh", 7500000, 1000000);
            ds[2] = new NhanVien("NV02", "Le Van C", 1993, "Ke toan", 7500000, 2000000);

            Console.WriteLine("Danh sach nhan vien ban dau:");
            InDS(ds);

            long tongThucLinh = 0;
            int minLuong = ds[0].LuongCB;
            int demThuong = 0;

            for (int i = 0; i < ds.Length; i++)
            {
                tongThucLinh += ds[i].ThucLinh;
                if (ds[i].LuongCB < minLuong)
                    minLuong = ds[i].LuongCB;
                if (ds[i].Thuong >= 1200000)
                    demThuong++;
            }

            Console.WriteLine("\na. Tong thuc linh: " + tongThucLinh);

            Console.WriteLine("\nb. Nhan vien co luong CB thap nhat (" + minLuong + "):");
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i].LuongCB == minLuong)
                    Console.WriteLine("   " + ds[i].MaNV + " - " + ds[i].Hoten);
            }

            Console.WriteLine("\nc. So nhan vien co thuong >= 1200000: " + demThuong);

            for (int i = 0; i < ds.Length - 1; i++)
            {
                for (int j = i + 1; j < ds.Length; j++)
                {
                    int ssPhong = string.Compare(ds[i].Phongban, ds[j].Phongban);
                    if (ssPhong > 0 || (ssPhong == 0 && string.Compare(ds[i].MaNV, ds[j].MaNV) < 0))
                    {
                        NhanVien tam = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tam;
                    }
                }
            }

            Console.WriteLine("\nd. Danh sach sau khi sap xep:");
            InDS(ds);

            for (int i = 0; i < ds.Length; i++)
            {
                ds[i].LuongCB = (int)(ds[i].LuongCB * 1.05);
                ds[i].ThucLinh = ds[i].LuongCB + ds[i].Thuong;
            }

            Console.WriteLine("\ne. Danh sach sau khi tang luong 5%:");
            InDS(ds);
        }
    }
}
```

#### kết quả

```text
Chọn bài: 2
--- BÀI TẬP 2: DANH SÁCH NHÂN VIÊN ---
Danh sach nhan vien ban dau:
NV03 | Tran Van B | Ke toan | LuongCB: 8000000 | Thuong: 1500000 | ThucLinh: 9500000
NV01 | Nguyen Van A | Kinh doanh | LuongCB: 7500000 | Thuong: 1000000 | ThucLinh: 8500000
NV02 | Le Van C | Ke toan | LuongCB: 7500000 | Thuong: 2000000 | ThucLinh: 9500000

a. Tong thuc linh: 27500000

b. Nhan vien co luong CB thap nhat (7500000):
   NV01 - Nguyen Van A
   NV02 - Le Van C

c. So nhan vien co thuong >= 1200000: 2

d. Danh sach sau khi sap xep:
NV03 | Tran Van B | Ke toan | LuongCB: 8000000 | Thuong: 1500000 | ThucLinh: 9500000
NV02 | Le Van C | Ke toan | LuongCB: 7500000 | Thuong: 2000000 | ThucLinh: 9500000
NV01 | Nguyen Van A | Kinh doanh | LuongCB: 7500000 | Thuong: 1000000 | ThucLinh: 8500000

e. Danh sach sau khi tang luong 5%:
NV03 | Tran Van B | Ke toan | LuongCB: 8400000 | Thuong: 1500000 | ThucLinh: 9900000
NV02 | Le Van C | Ke toan | LuongCB: 7875000 | Thuong: 2000000 | ThucLinh: 9875000
NV01 | Nguyen Van A | Kinh doanh | LuongCB: 7875000 | Thuong: 1000000 | ThucLinh: 8875000
```

### bài3

```csharp
using System;

namespace Buoi02_DanhSach
{
    static class B3C4
    {
        public static void Run()
        {
            Console.WriteLine("--- BÀI TẬP 3: MA TRẬN VUÔNG ---");
            int n = hamhotro.DocSo("Nhap cap ma tran vuong n", 3);
            if (n <= 0) return;

            int[,] a = new int[n, n];
            int dem = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = hamhotro.DocSo("Nhap a[" + i + "," + j + "]", dem++);
                }
            }

            Console.WriteLine("\nMa tran vua nhap:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int tong = 0;
            int minDuong = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tong += a[i, j];
                    if (a[i, j] > 0 && a[i, j] < minDuong)
                        minDuong = a[i, j];
                }
            }

            Console.WriteLine("\na. Tong cac phan tu: " + tong);
            if (minDuong == int.MaxValue)
                Console.WriteLine("b. Khong co so duong!");
            else
                Console.WriteLine("b. Gia tri duong nho nhat: " + minDuong);

            int tongCheoPhu = 0;
            for (int i = 0; i < n; i++)
            {
                tongCheoPhu += a[i, n - 1 - i];
            }
            Console.WriteLine("c. Tong duong cheo phu: " + tongCheoPhu);

            bool tangDan = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i, i] >= a[i + 1, i + 1])
                {
                    tangDan = false;
                    break;
                }
            }

            if (tangDan)
                Console.WriteLine("d. Duong cheo chinh tang dan");
            else
                Console.WriteLine("d. Duong cheo chinh khong tang dan");
        }
    }
}
```

#### kết quả

```text
Chọn bài: 3
--- BÀI TẬP 3: MA TRẬN VUÔNG ---
Nhap cap ma tran vuong n (Enter = 3):
Nhap a[0,0] (Enter = 1):
Nhap a[0,1] (Enter = 2):
Nhap a[0,2] (Enter = 3):
Nhap a[1,0] (Enter = 4):
Nhap a[1,1] (Enter = 5):
Nhap a[1,2] (Enter = 6):
Nhap a[2,0] (Enter = 7):
Nhap a[2,1] (Enter = 8):
Nhap a[2,2] (Enter = 9):

Ma tran vua nhap:
1	2	3
4	5	6
7	8	9

a. Tong cac phan tu: 45
b. Gia tri duong nho nhat: 1
c. Tong duong cheo phu: 15
d. Duong cheo chinh tang dan
```

### bài4

```csharp
using System;

namespace Buoi02_DanhSach
{
    static class B4C4
    {
        public static void Run()
        {
            Console.WriteLine("--- BÀI TẬP 4: DSLKD SỐ NGUYÊN DƯƠNG ---");
            Node pHead = null;
            int[] mau = { 5, 12, 5, 3, 9 };
            int n = hamhotro.DocSo("Nhap so phan tu DSLKD", 5);

            for (int i = 0; i < n; i++)
            {
                int gtMacDinh = i < mau.Length ? mau[i] : i + 1;
                int val = hamhotro.DocSo("Nhap phan tu thu " + (i + 1), gtMacDinh);
                pHead = hamhotro.ThemCuoi(pHead, val);
            }

            Console.Write("Danh sach lien ket don: ");
            hamhotro.InDSLK(pHead);

            int x = hamhotro.DocSo("a. Nhap x can dem", 5);
            int demX = 0;
            int minDuong = int.MaxValue;

            Node p = pHead;
            while (p != null)
            {
                if (p.Data == x)
                    demX++;
                if (p.Data > 0 && p.Data < minDuong)
                    minDuong = p.Data;
                p = p.Next;
            }

            Console.WriteLine("-> So phan tu bang " + x + ": " + demX);
            if (minDuong == int.MaxValue)
                Console.WriteLine("b. Khong co so duong!");
            else
                Console.WriteLine("b. Phan tu duong nho nhat: " + minDuong);

            int xXoa = hamhotro.DocSo("c. Nhap x can xoa dau tien", 5);
            pHead = hamhotro.XoaDauTien(pHead, xXoa);

            Console.Write("Danh sach sau khi xoa: ");
            hamhotro.InDSLK(pHead);
        }
    }
}
```

#### kết quả

```text
Chọn bài: 4
--- BÀI TẬP 4: DSLKD SỐ NGUYÊN DƯƠNG ---
Nhap so phan tu DSLKD (Enter = 5):
Nhap phan tu thu 1 (Enter = 5):
Nhap phan tu thu 2 (Enter = 12):
Nhap phan tu thu 3 (Enter = 5):
Nhap phan tu thu 4 (Enter = 3):
Nhap phan tu thu 5 (Enter = 9):
Danh sach lien ket don: 5 -> 12 -> 5 -> 3 -> 9
a. Nhap x can dem (Enter = 5):
-> So phan tu bang 5: 2
b. Phan tu duong nho nhat: 3
c. Nhap x can xoa dau tien (Enter = 5):
Danh sach sau khi xoa: 12 -> 5 -> 3 -> 9
```

### bài5

```csharp
using System;

namespace Buoi02_DanhSach
{
    static class B5C4
    {
        public static void Run()
        {
            Console.WriteLine("--- BÀI TẬP 5: DSLKD SỐ NGUYÊN l ---");
            Node l = null;
            int[] mau = { -2, 7, 0, 11, -5, 7 };
            int n = hamhotro.DocSo("Nhap so phan tu danh sach l", 6);

            for (int i = 0; i < n; i++)
            {
                int gtMacDinh = i < mau.Length ? mau[i] : i;
                int val = hamhotro.DocSo("Nhap l[" + i + "]", gtMacDinh);
                l = hamhotro.ThemCuoi(l, val);
            }

            Console.Write("Danh sach l: ");
            hamhotro.InDSLK(l);

            if (l == null) return;

            int max = l.Data;
            int tong = 0;
            int demSNT = 0;
            int demAm = 0, dem0 = 0, demDuong = 0;
            int minDuong = int.MaxValue;

            Node p = l;
            while (p != null)
            {
                if (p.Data > max) max = p.Data;
                tong += p.Data;
                if (hamhotro.KiemTraNguyenTo(p.Data)) demSNT++;

                if (p.Data < 0) demAm++;
                else if (p.Data == 0) dem0++;
                else demDuong++;

                if (p.Data > 0 && p.Data < minDuong)
                    minDuong = p.Data;

                p = p.Next;
            }

            Console.WriteLine("\na. Phan tu lon nhat: " + max);
            Console.WriteLine("b. Tong cac phan tu: " + tong);
            Console.WriteLine("c. So luong so nguyen to: " + demSNT);
            Console.WriteLine("d. So am: " + demAm + ", So bang 0: " + dem0 + ", So duong: " + demDuong);

            int x = hamhotro.DocSo("e. Nhap x can tim", 7);
            int demX = 0;
            p = l;
            while (p != null)
            {
                if (p.Data == x) demX++;
                p = p.Next;
            }
            Console.WriteLine("-> So phan tu bang " + x + ": " + demX);

            if (minDuong == int.MaxValue)
                Console.WriteLine("f. Khong co so duong!");
            else
                Console.WriteLine("f. Phan tu duong nho nhat: " + minDuong);
        }
    }
}
```

#### kết quả

```text
Chọn bài: 5
--- BÀI TẬP 5: DSLKD SỐ NGUYÊN l ---
Nhap so phan tu danh sach l (Enter = 6):
Nhap l[0] (Enter = -2):
Nhap l[1] (Enter = 7):
Nhap l[2] (Enter = 0):
Nhap l[3] (Enter = 11):
Nhap l[4] (Enter = -5):
Nhap l[5] (Enter = 7):
Danh sach l: -2 -> 7 -> 0 -> 11 -> -5 -> 7

a. Phan tu lon nhat: 11
b. Tong cac phan tu: 18
c. So luong so nguyen to: 3
d. So am: 2, So bang 0: 1, So duong: 3
e. Nhap x can tim (Enter = 7):
-> So phan tu bang 7: 2
f. Phan tu duong nho nhat: 7
```
