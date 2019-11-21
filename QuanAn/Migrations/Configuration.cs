namespace QuanAn.Migrations
{
    using QuanAn.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreContext context)
        {

            IList<Account> accounts = new List<Account>();

            accounts.Add(new Account() { Username = "admin", Password = "admin1234", IsAdmin = true, Name = "Trần Nguyên Tài", DOB = Convert.ToDateTime("7/10/1999") });
            accounts.Add(new Account() { Username = "minhtam", Password = "1234567890", IsAdmin = false, Name = "Minh Tâm", DOB = Convert.ToDateTime("12/10/1999"), Sex = "Nam" });
            accounts.Add(new Account() { Username = "vanlong", Password = "1234567890", IsAdmin = false, Name = "Văn Long", DOB = Convert.ToDateTime("12/10/1999"), Sex = "Nam" });
            accounts.Add(new Account() { Username = "nguyentai", Password = "1234567890", IsAdmin = false, Name = "Nguyên Tài", DOB = Convert.ToDateTime("10/27/1999"), Sex = "Nam" });


            context.Accounts.AddRange(accounts);

            List<Customer> TempCustomer = new List<Customer>()
            {
                new Customer{ID=1, Name="Trần Văn A",Address="Quận 5", DOB = Convert.ToDateTime("05/29/1999"), Phone="0765002122", Sex="Nam", Image="", Wallet =100000},
                new Customer{ID=2, Name="Trương Bảo Thủ",Address="Quận 8", DOB = Convert.ToDateTime("05/29/1999"), Phone="0769455678", Sex="Nam", Image="", Wallet =200000},
                new Customer{ID=3, Name="Nguyễn Ngọc Mia",Address="Quận 7", DOB =Convert.ToDateTime("05/29/1999"), Phone="06969391248", Sex="Nữ", Image="", Wallet =200000},
                new Customer{ID=4, Name="Đoàn Quốc Hùng",Address="Quận 7", DOB =Convert.ToDateTime("05/29/1999"), Phone="05697924538", Sex="Nữ", Image="", Wallet =500000},
                new Customer{ID=5, Name="Mai Quốc Kiệt",Address="Quận 2", DOB =Convert.ToDateTime("05/29/1999"), Phone="02234569574", Sex="Nam", Image="", Wallet =500000},
                new Customer{ID=6, Name="Mai Minh Hùng",Address="Bình Dương", DOB =Convert.ToDateTime("05/29/1999"), Phone="07642869451", Sex="Nam", Image="", Wallet =100000},
                new Customer{ID=7, Name="Đỗ Văn Đạt",Address="Quận 9", DOB =Convert.ToDateTime("05/29/1999"), Phone="0902806674", Sex="Nữ", Image="", Wallet =300000},
                new Customer{ID=8, Name="Kim Mạnh Hải",Address="Quận 8", DOB =Convert.ToDateTime("05/29/1999"), Phone="09175864525", Sex="Nữ", Image="", Wallet =250000},
                new Customer{ID=9, Name="Nguyễn Thiên Thanh",Address="Quận 1", DOB =Convert.ToDateTime("05/29/1999"), Phone="0246121121", Sex="Nam", Image="", Wallet =200000},
                new Customer{ID=10, Name="Huỳnh Thanh Hiên",Address="Quận Thủ Đức", DOB =Convert.ToDateTime("05/29/1999"), Phone="04658561422", Sex="Nam", Image="", Wallet =500000},
                new Customer{ID=11, Name="Huỳnh Quốc Tâm",Address="Quận 3", DOB =Convert.ToDateTime("05/29/1999"), Phone="03937797456", Sex="Nữ", Image="", Wallet =100000},
                new Customer{ID=12, Name="Nguyễn Anh Đông",Address="Quận 11", DOB =Convert.ToDateTime("05/29/1999"), Phone="02862609558", Sex="Nữ", Image="", Wallet =350000},
                new Customer{ID=13, Name="Trần Thành Công",Address="Quận 10", DOB =Convert.ToDateTime("05/29/1999"), Phone="02839800428", Sex="Nam", Image="", Wallet =150000},
                new Customer{ID=14, Name="Nguyễn Văn Huy",Address="Quận 12", DOB =Convert.ToDateTime("05/29/1999"), Phone="0393971429", Sex="Nam", Image="", Wallet =100000},
                new Customer{ID=15, Name="Lương Anh Trúc ",Address="Quận 12", DOB =Convert.ToDateTime("05/29/1999"), Phone="07654253125", Sex="Nữ", Image="", Wallet =100000},
                new Customer{ID=16, Name="Kim Văn Đồng",Address="Quận Gò Vấp", DOB =Convert.ToDateTime("05/29/1999"), Phone="07418635956", Sex="Nữ", Image="", Wallet =500000},
                new Customer{ID=17, Name="Nhật Khanh Châu",Address="Quận Bình Tân", DOB =Convert.ToDateTime("05/29/1999"), Phone="03945267414", Sex="Nam", Image="", Wallet =400000},
                new Customer{ID=18, Name="Đình Ngọc Công ",Address="Quận Tân Bình", DOB =Convert.ToDateTime("05/29/1999"), Phone="03842561215", Sex="Nam", Image="", Wallet =400000},
                new Customer{ID=19, Name="Lương Phi Tài",Address="Quận 6", DOB =Convert.ToDateTime("05/29/1999"), Phone="07652364548", Sex="Nữ", Image="", Wallet =300000},
                new Customer{ID=20, Name="Đào Ngọc Minh",Address="Long An", DOB =Convert.ToDateTime("05/29/1999"), Phone="03226767856", Sex="Nữ", Image="", Wallet =450000},
            };
            context.Customers.AddRange(TempCustomer);


            List<Employee> TempEmployee = new List<Employee>()
            {
                new Employee { ID = 1, Name = "Ngô Hoàng Minh Tâm", Address = "Quận Thủ Đức", DOB = Convert.ToDateTime("05/29/1995"), Phone = "03226767856", Sex = "Nam", Image = "", HireDate = Convert.ToDateTime("11/21/2019")},
                new Employee { ID = 2, Name = "Đoàn Văn Long", Address = "Quận 1", DOB = Convert.ToDateTime("05/29/1997"), Phone = "03226767856", Sex = "Nam", Image = "", HireDate = Convert.ToDateTime("11/21/2019")},
                new Employee { ID = 3, Name = "Trần Nguyên Tài", Address = "Quận 5", DOB = Convert.ToDateTime("05/29/1996"), Phone = "03226767856", Sex = "Nam", Image = "", HireDate = Convert.ToDateTime("11/21/2019")},
            };
            context.Employees.AddRange(TempEmployee);


            //// Subject SeedData 
            IList<Category> TempCategory = new List<Category>();

            TempCategory.Add(new Category() {ID=1, Name = "Món Ăn Khô" });
            TempCategory.Add(new Category() {ID=2, Name = "Món Ăn Nước" });
            TempCategory.Add(new Category() {ID=3, Name = "Nước Giải Khát" });

            context.Categories.AddRange(TempCategory);

            List<Food> TempFood = new List<Food>()
            {
                new Food{ ID=1,Name= "Bánh mì thịt nướng",Price=10000,Unit="Cái",Category_ID=1},
                new Food{ ID=2,Name= "Bánh xèo",Price=10000,Unit="Dĩa",Category_ID=1},
                new Food{ ID=3,Name= "Bánh khọt nước dừa",Price=10000,Unit="Dĩa",Category_ID=1},
                new Food{ ID=4,Name= "Chả cá",Price=20000,Unit="Dĩa",Category_ID=1},
                new Food{ ID=5,Name= "Chuối nếp nướng",Price=5000,Unit="Cái",Category_ID=1},
                new Food{ ID=6,Name= "Gỏi sứa",Price=20000,Unit="Dĩa",Category_ID=1},
                new Food{ ID=7,Name= "Bánh cuốn",Price=10000,Unit="Ly",Category_ID=1},
                new Food{ ID=8,Name= "Bắp sào",Price=5000,Unit="Hộp",Category_ID=1},
                new Food{ ID=9,Name= "Gỏi tôm",Price=25000,Unit="Dĩa",Category_ID=1},
                new Food{ ID=10,Name= "Bún riêu",Price=25000,Unit="Bát",Category_ID=2},
                new Food{ ID=11,Name= "Súp cua",Price=10000,Unit="Bát",Category_ID=2},
                new Food{ ID=12,Name= "Hủ tiếu tôm",Price=22000,Unit="Bát",Category_ID=2},
                new Food{ ID=13,Name= "Phở bò",Price=20000,Unit="Bát",Category_ID=2},
                new Food{ ID=14,Name= "Bánh canh cua",Price=25000,Unit="Bát",Category_ID=2},
                new Food{ ID=15,Name= "Hủ tiếu chay",Price=15000,Unit="Bát",Category_ID=2},
                new Food{ ID=16,Name= "Nui hản sản",Price=30000,Unit="Bát",Category_ID=2},
                new Food{ ID=17,Name= "Mì hoành thánh",Price=18000,Unit="Bát",Category_ID=2},
                new Food{ ID=18,Name= "Cocacola",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=19,Name= "Fanta",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=20,Name= "Nước tăng lực Sting",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=21,Name= "7UP",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=22,Name= "Kem",Price=10000,Unit="Ly",Category_ID=3},
                new Food{ ID=23,Name= "Nước khoáng",Price=3000,Unit="Chai",Category_ID=3},
                new Food{ ID=24,Name= "Bia 333",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=25,Name= "Bia Heineken",Price=10000,Unit="Lon",Category_ID=3},
                new Food{ ID=26,Name= "Bia Tiger",Price=10000,Unit="Lon",Category_ID=3},
            };
            context.Foods.AddRange(TempFood);


            base.Seed(context); // không ghi lại dòng này

        }

    }
}
