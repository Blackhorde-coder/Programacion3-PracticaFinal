using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PracticaProgrmacion3.Models;

namespace PracticaProgrmacion3.GestorDatos
{
    public class GestorBD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public GestorBD()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            dr = null;
        }

        public List<Tipo> ListaTipos()
        {
            List<Tipo> lista = new List<Tipo>();

            string consultasql = "select * from tipos";
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            con.Open();
            cmd =new SqlCommand(consultasql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Tipo tipo = new Tipo();
                tipo.Idtipo = int.Parse(dr["idTipo"].ToString());
                tipo.Nombre = dr["nombre"].ToString();
                tipo.Precio = double.Parse(dr["precio"].ToString());
                lista.Add(tipo);
            }
            return lista;
        }
        public void cargarLavado(Lavado l)
        {
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            try
            {
                String consultasql = " insert into lavados(patente, taxi, habitual, idTipo) values(@patente, @taxi, @habitual, @idtipo)";
                con.Open();
                cmd = new SqlCommand(consultasql, con);

                cmd.Parameters.AddWithValue("@patente", l.Patente);
                cmd.Parameters.AddWithValue("@taxi", l.Taxi);
                cmd.Parameters.AddWithValue("@habitual", l.Habitual);
                cmd.Parameters.AddWithValue("@idtipo", l.Idtipo);

                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        public List<DTOlistado> listadoLavados()
        {
            List<DTOlistado> lista = new List<DTOlistado>();
            con.ConnectionString = @"Data Source = BLACKHORDENOT; Initial Catalog = Lavadero; Integrated Security = True";
            string consultasql = @"select l.patente 'patente', t.nombre'tipo', t.precio'costo'
                                    from lavados l
                                    join tipos t on t.idTipo = l.idTipo";
            con.Open();
            cmd = new SqlCommand(consultasql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DTOlistado dto = new DTOlistado();
                dto.nombre = dr["tipo"].ToString();
                dto.patente = dr["patente"].ToString();
                dto.precio = double.Parse(dr["costo"].ToString());
                lista.Add(dto);
            }
            dr.Close();
            con.Close();
            
            return lista;
        }
        
    }
}