using ASP_FinalExam_Net6.Data;
using ASP_FinalExam_Net6.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_FinalExam_Net6.Test
{
    public class BasicTest
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        public BasicTest()
        {
            DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _opts = dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "Data Source=SQL8004.site4now.net;Initial Catalog=db_a8a75f_aspdb;User Id=db_a8a75f_aspdb_admin;Password=Pc*021#B").Options;
        }
        protected List<Department> MakeFakeJobs(int i)
        {

            var jobs = new List<Department>();
            for (int j = 0; j < i; j++)
            {

                jobs.Add(new Department
                {

                    Id = j,
                    Name = $"testDes{j}",
                    EmployeeCount = j
                });
            }
            return jobs;
        }

    }
}

