/*
    Một siêu thị kinh doanh các mặt hàng: gạo, thịt, rau.
    Mỗi mặt hàng có các thuộc tính: tên, giá, số lượng.
    a) Khai báo struct đối tượng hàng hoá với các thông tin
    đã cho.
    b) Khai báo một mảng/danh sách các mặt hàng.
    c) Viết hàm nhập thông tin cho một mặt hàng.
    d) Viết hàm xuất thông tin của một mặt hàng.
    e) Viết hàm xuất thông tin của tất cả các mặt hàng 
    trong mảng/danh sách.
    f) Viết hàm tìm kiếm mặt hàng theo tên.
    g) Viết hàm tìm kiếm mặt hàng theo khoảng giá.
    h) Viết hàm sắp xếp các mặt hàng theo giá.
    Bổ sung hàm main để thực thi kết quả.
*/
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public class Program{
    public struct Product{
        public string name;
        public decimal price;
        public int quantity;
    }
    public static Product[] products = new Product[3];
    public static void InputProduct(ref Product x, string name,
                                decimal price, int quantity){
        x.name = name;
        x.price = price;
        x.quantity = quantity;
    }
    public static Product InputProduct(string name,
                            decimal price, int quantity){
        Product x;
        x.name = name;
        x.price = price;
        x.quantity = quantity;
        return x;
    }

    public static string ToString(Product x)
    {
        return $"Name: {x.name}, Price: {x.price}, Quantity: { x.quantity} ";
    }
    public static void PrintAllProducts()
    {
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine(ToString(products[i]));
        }
    }
    public static List<Product> SearchByName(string kw)
    {
        List<Product> result = new List<Product>();
        foreach (Product product in products)
        {
            if (product.name.Contains(kw))
            {
                result.Add(product);
            } 
        }
        return result;
    }
    public static List<Product> SearchByPriceRange(
                        decimal minPrice, decimal maxPrice)
    {
        List<Product> result = new List<Product>();
        foreach (Product product in products)
        {
            if (product.price>=minPrice && product.price<=maxPrice)
            {
                result.Add(product);
            } 
        }
        return result;
    }

    public static void Main(string[] args)
    {
        Console.Clear();
        InputProduct(ref products[0], "Gạo", 15000, 5);
        products[1] = InputProduct("Thịt", 100000, 2);
        products[2] = InputProduct("Rau", 5000, 1);
        //Console.WriteLine(ToString(products[0]));
        PrintAllProducts();
    }
}