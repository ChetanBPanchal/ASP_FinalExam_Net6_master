using Microsoft.AspNetCore.Mvc;
using ASP_FinalExam_Net6.Controllers;
using ASP_FinalExam_Net6.Data;
using ASP_FinalExam_Net6.Models;
using Xunit;

namespace ASP_FinalExam_Net6.Test
{
    public class DepartmentControllerTest : BasicTest
    {
        [Fact]
        public async Task Index_Basic_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new DepartmentsController(testDb);
                var res = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(res);
                Assert.IsAssignableFrom<IEnumerable<Task>>(resVr.ViewData.Model);
            }
        }

        [Fact]
        public async Task Add_And_Remove_Test()
        {
            using (var testDb = new ApplicationDbContext(this._opts))
            {
                var testCtrl = new DepartmentsController(testDb);
                var fakeJobs = MakeFakeJobs(3);

                foreach (var job in fakeJobs)
                {
                    var res = await testCtrl.Create(job);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }

                var idxRes = await testCtrl.Index();
                var idxResVr = Assert.IsType<ViewResult>(idxRes);
                var returnedJobs = Assert.IsAssignableFrom<IEnumerable<Department>>(idxResVr.ViewData.Model);
                
                foreach (var job in fakeJobs){

                    Assert.Contains(job, returnedJobs);
                }

                foreach (var dept in returnedJobs){

                    var res = await testCtrl.DeleteConfirmed(dept.Id);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }
            }
        }
    }
}
