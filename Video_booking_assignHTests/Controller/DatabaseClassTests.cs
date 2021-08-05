using Microsoft.VisualStudio.TestTools.UnitTesting;
using Video_booking_assignH.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Video_booking_assignH.Controller.Tests
{
    [TestClass()]
    public class DatabaseClassTests
    {
        [TestMethod()]
        public void addClientTest()
        {
            Controller.DatabaseClass db = new Controller.DatabaseClass();
            DataTable tbl = new DataTable();
            tbl = db.SelectQuery("select * from Video");
            if (tbl.Rows.Count > 0)
            {
                Assert.IsTrue(true);

            }
            else {
                Assert.IsTrue(false);

            }
        }

        [TestMethod()]
        public void addClientTest2()
        {
            Controller.DatabaseClass db = new Controller.DatabaseClass();
            DataTable tbl = new DataTable();
            tbl = db.SelectQuery("select * from Client");
            if (tbl.Rows.Count > 0)
            {
                Assert.IsTrue(true);

            }
            else
            {
                Assert.IsTrue(false);

            }
        }


    }
}