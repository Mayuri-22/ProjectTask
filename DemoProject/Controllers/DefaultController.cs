using DemoProject.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            List<User> users = new List<User>();
            DataTable dtdata = SqlHelper.ExecuteDataTable("Select * from [User]");
            if (dtdata.Rows.Count > 0)
            {
                for (int i = 0; i < dtdata.Rows.Count; i++)
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(dtdata.Rows[i]["UserId"]);
                    user.FirstName = dtdata.Rows[i]["FirstName"].ToString();
                    user.LastName = dtdata.Rows[i]["LastName"].ToString();
                    user.MobileNo = dtdata.Rows[i]["MobileNo"].ToString();
                    user.EmailId = dtdata.Rows[i]["EmailId"].ToString();
                    users.Add(user);
                }
            }
            return View(users);
        }
        public ActionResult add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add(User user)
        {
            if (ModelState.IsValid)
            {
                string Query = $"Insert Into [User](FirstName,LastName,MobileNo,EmailId)Values('{user.FirstName}','{user.LastName}','{user.MobileNo}','{user.EmailId}')";
                int Result = SqlHelper.ExecuteNonQuery(Query);
                if (Result > 0)
                    return RedirectToAction("Index");
            }
            return View(user);

        }
        public ActionResult Edit(int? UserId)
        {
            if (UserId != 0)
            {
                string Query = $"Select * from [User] Where UserId={UserId}";
                DataTable dtdata = SqlHelper.ExecuteDataTable(Query);
                if (dtdata.Rows.Count > 0)
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(dtdata.Rows[0]["UserId"]);
                    user.FirstName = dtdata.Rows[0]["FirstName"].ToString();
                    user.LastName = dtdata.Rows[0]["LastName"].ToString();
                    user.MobileNo = dtdata.Rows[0]["MobileNo"].ToString();
                    user.EmailId = dtdata.Rows[0]["EmailId"].ToString();
                    return View(user);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int? UserId, User user)
        {
            if (ModelState.IsValid)
            {
                string Query = $"update [User] Set FirstName='{user.FirstName}',LastName='{user.LastName}',MobileNo='{user.MobileNo}',EmailId='{user.EmailId}' Where UserId={UserId}";
                int Result = SqlHelper.ExecuteNonQuery(Query);
                if (Result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult DeleteUser(int? UserId)
        {
            if (UserId != 0)
            {
                string Query = $"Delete From [User] Where UserId={UserId}";
                int Result = SqlHelper.ExecuteNonQuery(Query);
                if (Result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}