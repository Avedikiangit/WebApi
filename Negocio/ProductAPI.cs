using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelo_;

namespace Negocio
{
    public class ProductsAPI
    {
        string connStr = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";



        public List<Products> GetAll()
        {
            List<Products> products = new List<Products>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                
                
                    conn.Open();
                    string sql = "SELECT * FROM Products";
                    products = conn.Query<Products>(sql).ToList();
               
                
                    
                
            }
            return products;
        }

        public Products GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Products WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Products>(sql, new { Id = id });
            }
        }
                
         
        public void Update(Products producto) { }
        public int Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "DELETE FROM Products WHERE Id = @Id";

                int filasafectadas = conn.Execute(sql, new { Id = id });

                return filasafectadas;
            }

        }
       
        public Products Put(Products prod)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "UPDATE Products SET Title = @Title, Price = @price, description = @description, category = @category WHERE Id = @Id";
                int rowsAffected = conn.Execute(sql, prod);
                
                    
                    
                

                if (rowsAffected > 0)
                {
                    return prod;
                }
                else
                {
                    return null;
                }
            }
        }

        public Products Post(Products producto)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string sql = "INSERT INTO Products (Title, Price,description,category) VALUES (@Title, @Price,@description,@category)";
                conn.Execute(sql, new { Title = producto.Title, Price = producto.price, description=producto.description, category=producto.category });

                return producto;
            }
        }

        public List<string> GetAllCategories()
        {
            List<string> listaProductos = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {               
                    conn.Open();
                    string sql = "SELECT Category FROM Categories"; 
                    listaProductos = conn.Query<string>(sql).ToList();               
            }
            return listaProductos;
        }



    }



}