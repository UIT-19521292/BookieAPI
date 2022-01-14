using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace BKStore_API.Controllers
{
    public class ServiceController : ApiController
    {
        // GET api/ServiceController/GetBookList
        [Route("api/ServiceController/GetBookList")]
        [HttpGet]
        public IHttpActionResult GetBookList()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetBookList");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetUserList
        [Route("api/ServiceController/GetUserList")]
        [HttpGet]
        public IHttpActionResult GetUserList()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetUserList");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddUser
        [Route("api/ServiceController/AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(string UserName, string UserPhone, string UserEmail, string UserGender, string UserDob, string UserPassword)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserName", UserName);
                param.Add("UserPhone", UserPhone);
                param.Add("UserEmail", UserEmail);
                param.Add("UserGender", UserGender);
                param.Add("UserDob", UserDob);
                param.Add("UserPassword", UserPassword);

                int key = Database.Database.InsertValue("Proc_AddUser", param);
                if (key != 0)
                    return Ok(key);
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/ServiceController/UpdateUser
        [Route("api/ServiceController/UpdateUser")]
        [HttpPut]
        public IHttpActionResult UpdateUser(int UserID, string UserName, string UserGender, string UserDob)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("UserName", UserName);
                param.Add("UserGender", UserGender);
                param.Add("UserDob", UserDob);

                if (Database.Database.UpdateValue("Proc_UpdateUser", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetLikedByUserID
        [Route("api/ServiceController/GetLikedByUserID")]
        [HttpGet]
        public IHttpActionResult GetLikedByUserID(int UserID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);

                DataTable result = Database.Database.ReadTable("Proc_GetLikedByUserID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetViewedByUserID
        [Route("api/ServiceController/GetViewedByUserID")]
        [HttpGet]
        public IHttpActionResult GetViewedByUserID(int UserID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);

                DataTable result = Database.Database.ReadTable("Proc_GetViewedByUserID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetOrderByUserID
        [Route("api/ServiceController/GetOrderByUserID")]
        [HttpGet]
        public IHttpActionResult GetOrderByUserID(int UserID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);

                DataTable result = Database.Database.ReadTable("Proc_GetOrderByUserID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddBookToCart
        [Route("api/ServiceController/AddBookToCart")]
        [HttpPost]
        public IHttpActionResult AddBookToCart(int UserID, int BookID, int Quantity)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("BookID", BookID);
                param.Add("Quantity", Quantity);

                int key = Database.Database.InsertValue("Proc_AddBookToCart", param);
                if (key != 0)
                    return Ok("Success");
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetCartByUserID
        [Route("api/ServiceController/GetCartByUserID")]
        [HttpGet]
        public IHttpActionResult GetCartByUserID(int UserID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);

                DataTable result = Database.Database.ReadTable("Proc_GetCartByUserID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/ServiceController/RemoveFromCart
        [Route("api/ServiceController/RemoveFromCart")]
        [HttpDelete]
        public IHttpActionResult RemoveFromCart(int UserID, int BookID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("BookID", BookID);

                if (Database.Database.DeleteValue("Proc_RemoveFromCart", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/ServiceController/UpdateBookQuantity
        [Route("api/ServiceController/UpdateBookQuantity")]
        [HttpPut]
        public IHttpActionResult UpdateBookQuantity(int UserID, int BookID, int Quantity)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("BookID", BookID);
                param.Add("Quantity", Quantity);

                if (Database.Database.UpdateValue("Proc_UpdateBookQuantity", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddToViewed
        [Route("api/ServiceController/AddToViewed")]
        [HttpPost]
        public IHttpActionResult AddToViewed(int UserID, int BookID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("BookID", BookID);

                int key = Database.Database.InsertValue("Proc_AddToViewed", param);
                if (key != 0)
                    return Ok("Success");
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddToLiked
        [Route("api/ServiceController/AddToLiked")]
        [HttpPost]
        public IHttpActionResult AddToLiked(int UserID, int BookID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("BookID", BookID);

                int key = Database.Database.InsertValue("Proc_AddToLiked", param);
                if (key != 0)
                    return Ok("Success");
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddOrder
        [Route("api/ServiceController/AddOrder")]
        [HttpPost]
        public IHttpActionResult AddOrder(string ShipAddress, float OrderTotal, int UserID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ShipAddress", ShipAddress);
                param.Add("OrderTotal", OrderTotal);
                param.Add("UserID", UserID);

                int key = Database.Database.InsertValue("Proc_AddOrder", param);
                if (key != 0)
                    return Ok(key);
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/ServiceController/AddOrderDetail
        [Route("api/ServiceController/AddOrderDetail")]
        [HttpPost]
        public IHttpActionResult AddOrderDetail(int OrderID, int BookID, int Quantity)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", OrderID);
                param.Add("BookID", BookID);
                param.Add("Quantity", Quantity);

                int key = Database.Database.InsertValue("Proc_AddOrderDetail", param);
                if (key != 0)
                    return Ok("Success");
                else
                    return Ok("Failed");
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetBookByBookTitle
        [Route("api/ServiceController/GetBookByBookTitle")]
        [HttpGet]
        public IHttpActionResult GetBookByBookTitle(string BookTitle)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("BookTitle", BookTitle);

                DataTable result = Database.Database.ReadTable("Proc_GetBookByBookTitle", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetBookByBookID
        [Route("api/ServiceController/GetBookByBookID")]
        [HttpGet]
        public IHttpActionResult GetBookByBookID(int BookID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("BookID", BookID);

                DataTable result = Database.Database.ReadTable("Proc_GetBookByBookID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/ServiceController/GetOrderDetailByOrderID
        [Route("api/ServiceController/GetOrderDetailByOrderID")]
        [HttpGet]
        public IHttpActionResult GetOrderDetailByOrderID(int OrderID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", OrderID);

                DataTable result = Database.Database.ReadTable("Proc_GetOrderDetailByOrderID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/ServiceController/UpdateCancelledOrderByOrderID
        [Route("api/ServiceController/UpdateCancelledOrderByOrderID")]
        [HttpPut]
        public IHttpActionResult UpdateCancelledOrderByOrderID(int OrderID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", OrderID);

                if (Database.Database.UpdateValue("Proc_UpdateCancelledOrderByOrderID", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/ServiceController/UpdateCompleteOrderByOrderID
        [Route("api/ServiceController/UpdateCompleteOrderByOrderID")]
        [HttpPut]
        public IHttpActionResult UpdateCompleteOrderByOrderID(int OrderID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", OrderID);

                if (Database.Database.UpdateValue("Proc_UpdateCompleteOrderByOrderID", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/ServiceController/UpdatePassword
        [Route("api/ServiceController/UpdatePassword")]
        [HttpPut]
        public IHttpActionResult UpdatePassword(int UserID, string UserPassword)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("UserID", UserID);
                param.Add("UserPassword", UserPassword);

                if (Database.Database.UpdateValue("Proc_UpdatePassword", param))
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
