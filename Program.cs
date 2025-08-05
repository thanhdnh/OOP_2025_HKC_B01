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
    *********************************************
    >> Lab 01:
    Viết chương trình mô phỏng cho việc quản lý mua bán
    hàng hoá tại siêu thị nói trên với các chức năng:
    - Cho phép người dùng thêm các mặt hàng vào giỏ hàng
    (với số lượng cho phép, tức nhỏ hơn số lượng hàng còn
    trong siêu thị). Giỏ hàng có thể chứa nhiều mặt hàng.
    - Cho phép thực thi thao tác thanh toán: tính tổng giá
    cần phải chi trả cho tất cả các mặt hàng trong giỏ, đồng
    thời, sau khi thanh toán, số lượng hàng trong siêu thị
    cũng sẽ giảm đi tương ứng với số lượng hàng đã mua.
    - Cho phép siêu thị bổ sung thêm hàng hoá vào kho (thay
    đổi lại số lượng hàng có trong kho).
    - Giả sử, khi mua hàng, sẽ có voucher khuyến mãi (dưới
    dạng một mã REDUCE10, REDUCE20, ...), cho phép
    giảm giá tổng số tiền thanh toán tương ứng với phần trăm
    giảm giá. Ví dụ, mã REDUCE10 sẽ giảm 10% tổng số tiền
    thanh toán, REDUCE20 sẽ giảm 20% tổng số tiền thanh toán.
    Hãy tạo ra một phiên bản thanh toán khác (cùng tên với
    phương thức thanh toán ban đầu nhưng khác tham số cho phép
    thêm mã giảm giá để tính toán tổng số tiền thanh toán
    sau khi giảm giá).
*/

using System.Security.Cryptography.X509Certificates;

public class Program
{
    public struct Product
    {
        public string name;
        public decimal price;
        public int quantity;
    }
    public static Product[] products = new Product[3];
    public static void InputProduct(ref Product x, string name,
                                decimal price, int quantity)
    {
        x.name = name;
        x.price = price;
        x.quantity = quantity;
    }
    public static Product InputProduct(string name,
                            decimal price, int quantity)
    {
        Product x;
        x.name = name;
        x.price = price;
        x.quantity = quantity;
        return x;
    }

    public static string ToString(Product x)
    {
        return $"Name: {x.name}, Price: {x.price}, Quantity: {x.quantity} ";
    }
    public static void PrintAllProducts()
    {
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine(ToString(products[i]));
        }
    }
    public static void PrintAListOfProducts(List<Product> prd)
    {
        for (int i = 0; i < prd.Count; i++)
        {
            Console.WriteLine(ToString(prd[i]));
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
            if (product.price >= minPrice && product.price <= maxPrice)
            {
                result.Add(product);
            }
        }
        return result;
    }

    public static void SortByPrice()
    {
        for (int i = 0; i < products.Length - 1; i++)
        {
            for (int j = 0; j < products.Length - 1 - i; j++)
            {
                if (products[j].price > products[j + 1].price)
                {
                    // Swap
                    Product temp = products[j];
                    products[j] = products[j + 1];
                    products[j + 1] = temp;
                }
            }
        }
    }
    /* Bài 2
    ##################
    
    */
    public struct Point
    {
        public float x;
        public float y;
    }
    public struct Coords
    {
        public float x;
        public float y;
    }
    public struct Vector
    {
        public Point start;
        public Point end;
    }

    public static Coords GetCoordinates(Vector v)
    {
        Coords coordinates;
        coordinates.x = v.end.x - v.start.x;
        coordinates.y = v.end.y - v.start.y;
        return coordinates;
    }

    public static Coords AddVectors(Vector v1, Vector v2)
    {
        Coords coords1 = GetCoordinates(v1);
        Coords coords2 = GetCoordinates(v2);

        Coords result;
        result.x = coords1.x + coords2.x;
        result.y = coords1.y + coords2.y;
        return result;
    }
    public static float ScalarProduct(Vector v1, Vector v2)
    { 
        Coords A = GetCoordinates (v1);
        Coords B = GetCoordinates(v2);
        return (A.x * B.x) + (A.y * B.y);
     }


    public static void Main(string[] args)
    {
        Console.Clear();
        /*InputProduct(ref products[0], "Gạo", 15000, 5);
        products[1] = InputProduct("Thịt", 100000, 2);
        products[2] = InputProduct("Rau", 5000, 1);
        //Console.WriteLine(ToString(products[0]));
        PrintAllProducts();
        Console.WriteLine("--------Searching---------");
        PrintAListOfProducts(SearchByName("Gạo"));
        PrintAListOfProducts(SearchByPriceRange(10000, 20000));

        Console.WriteLine("--------Sorting---------");
        SortByPrice();
        PrintAllProducts();*/

        Point[] points = new Point[3];
        points[0] = new Point { x = 1, y = 2 };
        points[1] = new Point { x = 3, y = 4 };
        points[2] = new Point { x = 5, y = 6 };

        Vector[] vectors = new Vector[3];
        vectors[0] = new Vector { start = points[0], end = points[1] };
        vectors[1] = new Vector { start = points[1], end = points[2] };
        vectors[2] = new Vector { start = points[0], end = points[2] };
        
        Coords c = AddVectors(vectors[0], vectors[1]);
        Console.WriteLine($"Toạ độ của vector tổng: ({c.x}, {c.y})");

        float scalarProduct = ScalarProduct(vectors[0], vectors[1]);
        Console.WriteLine($"Tích vô hướng của 2 vector: {scalarProduct}");
    }
}

/** Bài tập 2 **/
/*
    Một struct Point mô tả cho một điểm trong hệ toạ độ
    Descartes 2 chiều với hai thuộc tính toạ độ x, y.
    1/ Khai báo struct Point nói trên.
    2/ Một vector sẽ được hình thành dựa trên 2 Point. Hãy
    khai báo một struct Vector2 với hai Point nói trên.
    3/ Xác định toạ độ của một vector.
    4/ Xác định vector tổng của 2 vector.
    5/ Xác định tích vô hướng của 2 vector.
    Trong hàm main, tạo một List chứa 3 Point và sau đó
    tạo các tổ hợp các cặp Point để tạo thành các vector
    tương ứng (3 vector). Sau đó, dựa trên 3 vector để kiểm tra
    các kết quả của các câu 3-5.

*/