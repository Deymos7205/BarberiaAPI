
using System.Data;
using MySqlConnector;
namespace BarberiaAPI.Services
{
    public class BarberiaConexion
    {
        private readonly string _cadena;

        public BarberiaConexion(string cadenaConexion)
        {
            _cadena = cadenaConexion ?? throw new ArgumentNullException(nameof(cadenaConexion));
        }

        private MySqlConnection AbrirConexion()
        {
            var cn = new MySqlConnection(_cadena);
            cn.Open();
            return cn;
        }

        public DataTable EjecutarConsulta(string sql, MySqlParameter[]? parametros = null)
        {
            using var cn = AbrirConexion();
            using var cmd = new MySqlCommand(sql, cn);
            if (parametros is not null) cmd.Parameters.AddRange(parametros);
            using var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;

        }

        public int EjecutarComando(string sql, MySqlParameter[]? parametros = null)
        {
            using var cn = AbrirConexion();
            using var cmd = new MySqlCommand(sql, cn);
            if (parametros is not null) cmd.Parameters.AddRange(parametros);
            return cmd.ExecuteNonQuery();
        }

        public object? EjecutarEscalar(string sql, MySqlParameter[]? parametros = null)
        {
            using var cn = AbrirConexion();
            using var cmd = new MySqlCommand(sql, cn);
            if (parametros is not null) cmd.Parameters.AddRange(parametros);
            return cmd.ExecuteScalar();
        }
    }
}



/*
using System;
using System.Data.SqlClient;

namespace BarberiaAPI.Services
{
   
    public class ConexionBD
    {
        
        private string cadenaConexion = "Server=localhost;Database=barberia;Trusted_Connection=True;";
        
        private SqlConnection conexion;

     
        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

  
        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                    Console.WriteLine("✅ Conexión abierta correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al abrir la conexión: " + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    Console.WriteLine("🔒 Conexión cerrada correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al cerrar la conexión: " + ex.Message);
            }
        }

        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }
}


*/