using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ABMfacturacion
{
    internal class Helper
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection cnn = new SqlConnection(Properties.Resources.cnnABMfacturacion);

        public DataTable ConectBD(string query)
        {
            DataTable table = new DataTable();

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            table.Load(cmd.ExecuteReader());
            cnn.Close();
            return table;
        }

        public int ProximaFactura()
        {
           SqlCommand cmd = new SqlCommand();
            cnn.Open();
            cmd.Connection=cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_nextFactura";
            
            SqlParameter OutPut = new SqlParameter();
            OutPut.DbType = DbType.Int32;
            OutPut.Direction = ParameterDirection.Output;
            OutPut.ParameterName = "@Next";
            cmd.Parameters.Add(OutPut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            return (int)OutPut.Value;
        }

        public bool ConfirmarFactura(Factura oFactura)
        {
            bool ok = true;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t=cnn.BeginTransaction();
                cmd.Connection=cnn;
                cmd.Transaction=t;
                cmd.CommandText="insertFactura";
                cmd.CommandType=CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@id_formaPago", oFactura.FormaPago);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);

                SqlParameter outPut = new SqlParameter();
                outPut.DbType = DbType.Int32;
                outPut.Direction = ParameterDirection.Output;
                outPut.ParameterName = "@nro_factura";
                cmd.Parameters.Add(outPut);
                cmd.ExecuteNonQuery();

                int nroFactura = (int)outPut.Value;

                SqlCommand cmdDetalle;

                foreach (DetalleFactura item in oFactura.ListDetalles)
                {
                    cmdDetalle = new SqlCommand("insertMaestro", cnn, t);
                    cmdDetalle.CommandType=CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_articulo", item.Articulo.idArticulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@nro_factura", nroFactura);
                    cmdDetalle.ExecuteNonQuery();

                }
                t.Commit();

            }

            catch (Exception)
            {
                if (t != null)
                {
                    t.Rollback();
                    ok=false;
                }
            }

             finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }
            return ok;

        }
    }
}





 