using Dapper;
using MySql.Data.MySqlClient;
using Negocio.Modelo_;

namespace Negocio
{
    public class ProductsAPI
    {
        string connStr = "Server=sql10.freemysqlhosting.net;Database=sql10739703;Uid=sql10739703;Pwd=d4q6qAjJg6;";
        public List<Products> GetAll()
        {
            List<Products> products = new List<Products>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                products= conn.Query<Products>(sql).ToList();
                

            }
            return products;
        }
        public Products GetById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Id, Name, Price FROM Products WHERE Id = @Id";
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

                string sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @Id";
                int rowsAffected = conn.Execute(sql, new { Name = prod.Name, Price = prod.price, Id = prod.id });


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

                string sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                conn.Execute(sql, new { Name = producto.Name, Price = producto.price });

                return producto;
            }
        }
    }
}