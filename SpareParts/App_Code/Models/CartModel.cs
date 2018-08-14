using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            db.Carts.Add(cart);
            db.SaveChanges();

            return cart.DatePurchased + " Was successfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            //Fetch object from db
            Cart p = db.Carts.Find(id);
            p.DatePurchased = cart.DatePurchased;
            p.ClientID = cart.ClientID;
            p.Amount = cart.Amount;
            p.IsInCart = cart.IsInCart;
            p.ProductID = cart.ProductID;

            db.SaveChanges();
            return cart.DatePurchased + " Was successfully Updated";
        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            Cart cart = db.Carts.Find(id);
            db.Carts.Attach(cart);
            db.Carts.Remove(cart);

            db.SaveChanges();
            return cart.DatePurchased + " Was successfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }

    public List<Cart> GetOrdersInCart(string userId)
    {
        GarageDbEntities2 db = new GarageDbEntities2();
        List<Cart> orders = (from x in db.Carts
                             where x.ClientID == userId
                             && x.IsInCart
                             orderby x.DatePurchased
                             select x).ToList();
        return orders;
    }

    public int GetAmountOfOrders(string userId)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            int amount= (from x in db.Carts
                         where x.ClientID==userId
                         && x.IsInCart
                         select x.Amount).Sum();
            return amount;
        }
        catch
        {
            return 0;
        }
    }

    public void UpdateQuality(int id, int quantity)
    {
        GarageDbEntities2 db = new GarageDbEntities2();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;

        db.SaveChanges();
    }

    public void markOrderAsPaid(List<Cart> carts)
    {
        GarageDbEntities2 db = new GarageDbEntities2();
        if (carts != null)
        {
            foreach (Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.ID);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.IsInCart = false;
            }
            db.SaveChanges();

        }
    }
}