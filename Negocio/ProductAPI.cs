using Negocio.Modelo_;

namespace Negocio
{
    public class ProductsAPI
    {
        public List<Products> GetAll()
        {
            return Datos.listaProductos.OrderBy(item => item.id).ToList();
        }
        public Products GetById(int id)
        {
            return Datos.listaProductos.Where(item => item.id == id).First();
        }
        public void Update(Products producto) { }
        public int Delete(int id)
        {
            return Datos.listaProductos.RemoveAll(item => item.id == id);
        }
        public Products Put(Products prod)
        {
         
                var product = Datos.listaProductos.Where(item => item.id == prod.id).First();
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return product;
        }
        public Products Post(Products producto)
        {
            Datos.listaProductos.Add(producto);

            return producto;
        }
    }
}