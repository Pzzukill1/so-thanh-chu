using System;

class Program
{
    static string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

    static string DocSo(int so)
    {
        if (so == 0)
            return "Không";

        string ketQua = "";

        int hangTramNghin = so / 100000;
        int hangChucNghin = (so / 10000) % 10;
        int hangNghin = (so / 1000) % 10;
        int hangTram = (so / 100) % 10;
        int hangChuc = (so / 10) % 10;
        int hangDonVi = so % 10;

        // Hàng trăm nghìn
        if (hangTramNghin > 0)
            ketQua += ChuSo[hangTramNghin] + " trăm ";

        // Hàng chục nghìn và nghìn
        if (hangChucNghin > 1)
        {
            ketQua += ChuSo[hangChucNghin] + " mươi ";
            if (hangNghin == 1)
                ketQua += "mốt ";
            else if (hangNghin == 5)
                ketQua += "lăm ";
            else if (hangNghin > 0)
                ketQua += ChuSo[hangNghin] + " ";
        }
        else if (hangChucNghin == 1)
        {
            ketQua += "mười ";
            if (hangNghin > 0)
                ketQua += ChuSo[hangNghin] + " ";
        }
        else if (hangChucNghin == 0 && hangNghin > 0)
        {
            ketQua += "lẻ " + ChuSo[hangNghin] + " ";
        }

        if (hangTramNghin > 0 || hangChucNghin > 0 || hangNghin > 0)
            ketQua += "nghìn ";

        // Hàng trăm
        if (hangTram > 0)
            ketQua += ChuSo[hangTram] + " trăm ";
        else if (hangChuc > 0 || hangDonVi > 0)
            ketQua += "không trăm ";

        // Hàng chục
        if (hangChuc > 1)
        {
            ketQua += ChuSo[hangChuc] + " mươi ";
            if (hangDonVi == 1)
                ketQua += "mốt";
            else if (hangDonVi == 5)
                ketQua += "lăm";
            else if (hangDonVi > 0)
                ketQua += ChuSo[hangDonVi];
        }
        else if (hangChuc == 1)
        {
            ketQua += "mười ";
            if (hangDonVi > 0)
                ketQua += ChuSo[hangDonVi];
        }
        else if (hangChuc == 0 && hangDonVi > 0)
        {
            ketQua += "lẻ " + ChuSo[hangDonVi];
        }

        ketQua = ketQua.Trim();
        return char.ToUpper(ketQua[0]) + ketQua.Substring(1); // Viết hoa chữ cái đầu
    }

    static void Main()
    {
        Console.Write("Nhập một số nguyên dương (tối đa 6 chữ số): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int so) && so >= 0 && so < 1000000)
        {
            string chu = DocSo(so);
            Console.WriteLine("Số thành chữ: " + chu);
        }
        else
        {
            Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số nguyên từ 0 đến 999999.");
        }
    }
}
