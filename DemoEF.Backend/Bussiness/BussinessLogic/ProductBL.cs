using DemoEF.Backend.Bussiness.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoEF.Backend.Bussiness.BussinessLogic
{
    public class ProductBL
    {

        #region Singleton 
        // Crear una única instancia para evitar generar muchas instancias que sobrecarguen la memoria
        private static ProductBL instance;
        public static ProductBL getInstance()
        {
            if (instance == null)
            {
                instance = new ProductBL();
            }
            return instance;
        }
        #endregion

        public void Insertar(Product myProduct)
        {
            using (var en = new NORTHWNDEntities())
            {
                en.Products.Add(myProduct);
                en.SaveChanges();
            }
        }
        public void Actualizar(Product myProduct)
        {
            using (var en = new NORTHWNDEntities())
            {
                var ProductInBD = en.Products.FirstOrDefault(x => x.ProductID == myProduct.ProductID);
                en.Entry(ProductInBD).State = EntityState.Modified;
                en.Entry(ProductInBD).CurrentValues.SetValues(myProduct);
                en.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            using (var en = new NORTHWNDEntities())
            {
                var ProductInBD = en.Products.FirstOrDefault(x => x.ProductID == id);
                en.Entry(ProductInBD).State = EntityState.Deleted;
                en.SaveChanges();
            }
        }
        public List<Product> Listar()
        {
            using (var en = new NORTHWNDEntities())
            {
                var query = from p in en.Products
                                       select p;
                return query.ToList();
            }
        }
        public Product Detalle(int id)
        {
            using (var en = new NORTHWNDEntities())
            {
                var query = from p in en.Products
                            where p.ProductID == id
                            select p;
                return query.FirstOrDefault();
            }
        }
    }
}
