using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2008M_UWP_Prj.Models;
using T2008M_UWP_Prj.Adapters;
using SQLitePCL;
using System.Diagnostics;

namespace T2008M_UWP_Prj.Services
{
    // Repository pattern
    interface ICartService
    {
        List<CartItem> GetCart();

        int ItemCount(int id); // return how many of this item
        bool AddToCart(CartItem item);
        bool RemoveItem(int id);
        bool UpdateItem(int id, int qty);
        bool ClearCart();

        int GetTotalAmount();
    }

    class CartService : ICartService
    {

        public int ItemCount(int id)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "select * from Cart where id=?";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, id);                
                while (SQLiteResult.ROW == statement.Step())
                {
                    CartItem item = new CartItem()
                    {
                        id = Convert.ToInt32(statement[0]),
                        name = statement[1] as string,
                        image = statement[2] as string,
                        price = Convert.ToInt32(statement[3]),
                        qty = Convert.ToInt32(statement[4]),
                    };
                    return item.qty;
                }
                return 0;
            } 
            catch (Exception e)
            {
                return 0;
            }
        }
        public bool AddToCart(CartItem item)
        {
            try
            {
                int NumberOfThisItem = ItemCount(item.id);
                if (NumberOfThisItem > 0)
                {
                    return UpdateItem(item.id, NumberOfThisItem + item.qty);
                }
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "insert into Cart(Id,Name,Image,Price,Qty) values(?,?,?,?,?)";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, item.id);
                statement.Bind(2, item.name);
                statement.Bind(3, item.image);
                statement.Bind(4, item.price);
                statement.Bind(5, item.qty);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ClearCart()
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "delete from Cart";
                var statement = connection.Prepare(sql_txt);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> list = new List<CartItem>();
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "select * from Cart";
                var statement = connection.Prepare(sql_txt);
                while (SQLiteResult.ROW == statement.Step())
                {
                    CartItem item = new CartItem()
                    {
                        id = Convert.ToInt32(statement[0]),
                        name = statement[1] as string,
                        image = statement[2] as string,
                        price = Convert.ToInt32(statement[3]),
                        qty = Convert.ToInt32(statement[4]),
                    };
                    list.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return list;
        }

        public bool RemoveItem(int id)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "delete from Cart where Id = ?";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateItem(int id, int qty)
        {
            try
            {
                if (qty < 1) return false;
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "update Cart set Qty=? where Id = ?";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, qty);
                statement.Bind(2, id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int GetTotalAmount()
        {            
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "select Sum(Price*Qty) as Result from Cart";
                var statement = connection.Prepare(sql_txt);
                var rs = statement.Step();
                return Convert.ToInt32(statement[0]);
            }
            catch (Exception e)
            {
                return 0;
            }            
        }
    }
}