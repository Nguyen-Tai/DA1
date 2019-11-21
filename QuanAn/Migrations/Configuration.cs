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
            accounts.Add(new Account() { Username = "minhtam", Password = "1234567890", IsAdmin = false, Name = "Minh Tâm", DOB = Convert.ToDateTime("12/10/1999"), Sex = "Nữ" });
            accounts.Add(new Account() { Username = "vanlong", Password = "1234567890", IsAdmin = false, Name = "Văn Long", DOB = Convert.ToDateTime("12/10/1999"), Sex = "Nam" });
            accounts.Add(new Account() { Username = "nguyentai", Password = "1234567890", IsAdmin = false, Name = "Nguyên Tài", DOB = Convert.ToDateTime("10/27/1999"), Sex = "Nam" });

            context.Accounts.AddRange(accounts);

            base.Seed(context); // không ghi lại dòng này
        }
    }
}
