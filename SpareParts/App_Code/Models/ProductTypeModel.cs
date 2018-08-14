using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return productType.Name + " Was successfully inserted";
        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            //Fetch object from db
            ProductType p = db.ProductTypes.Find(id);
            p.Name = productType.Name;

            db.SaveChanges();
            return productType.Name + " Was successfully Updated";
        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            GarageDbEntities2 db = new GarageDbEntities2();
            ProductType productType = db.ProductTypes.Find(id);
            db.ProductTypes.Attach(productType);
            db.ProductTypes.Remove(productType);

            db.SaveChanges();
            return productType.Name + " Was successfully deleted";

        }
        catch (Exception e)
        {
            return "Error:" + e;

        }
    }
}