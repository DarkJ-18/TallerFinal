using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODELO;

namespace CONTROLADOR.DatosFarmacia
{
    public class ProductosDAO
    {
        ClsDatos clsDatos = null;
        ProductosDTO productosDTO = null;
        DataTable listaDatos = null;

        public ProductosDAO(ProductosDTO productosDTO)
        {
            this.productosDTO = productosDTO;
        }



        public DataTable ListarProductos()
        {
            listaDatos = new DataTable();

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.productosDTO == null)
                {
                    parametros = new SqlParameter[5];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@Id";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = productosDTO.getId();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@Nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 100;
                    parametros[1].SqlValue = productosDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@Descripcion";
                    parametros[2].SqlDbType = SqlDbType.VarChar;
                    parametros[2].Size = 100;
                    parametros[2].SqlValue = productosDTO.getDescripcion();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@Precio";
                    parametros[3].SqlDbType = SqlDbType.Int;
                    parametros[3].SqlValue = productosDTO.getPrecio();

                    parametros[4] = new SqlParameter();
                    parametros[4].ParameterName = "@Stock";
                    parametros[4].SqlDbType = SqlDbType.Int;
                    parametros[4].SqlValue = productosDTO.getStock();
                }
                else
                {
                    parametros = null;
                }


                listaDatos = clsDatos.RetornaTabla(parametros, "spConsultaProductos");

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return listaDatos;

        }     


        public void GuardarProductos()
        {
            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = new SqlParameter[4];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@Nombre";
                parametros[0].SqlDbType = SqlDbType.VarChar;
                parametros[0].Size = 100;
                parametros[0].SqlValue = productosDTO.getNombre();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Descripcion";
                parametros[1].SqlDbType = SqlDbType.VarChar;
                parametros[1].Size = 100;
                parametros[1].SqlValue = productosDTO.getDescripcion();

                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@Precio";
                parametros[2].SqlDbType = SqlDbType.Int;
                parametros[2].SqlValue = productosDTO.getPrecio();

                parametros[3] = new SqlParameter();
                parametros[3].ParameterName = "@Stock";
                parametros[3].SqlDbType = SqlDbType.Int;
                parametros[3].SqlValue = productosDTO.getStock();

                clsDatos.EjecutarSP(parametros, "spNuevoProducto");

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }


        public void GuardarCambiosProductos()
        {
            clsDatos = new ClsDatos();
            SqlParameter[] parametros = new SqlParameter[5];

            try
            {
                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@Id";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = productosDTO.getId();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Nombre";
                parametros[1].SqlDbType = SqlDbType.VarChar;
                parametros[1].Size = 100;
                parametros[1].SqlValue = productosDTO.getNombre();

                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@Descripcion";
                parametros[2].SqlDbType = SqlDbType.VarChar;
                parametros[2].Size = 100;
                parametros[2].SqlValue = productosDTO.getDescripcion();

                parametros[3] = new SqlParameter();
                parametros[3].ParameterName = "@Precio";
                parametros[3].SqlDbType = SqlDbType.Int;
                parametros[3].SqlValue = productosDTO.getPrecio();

                parametros[4] = new SqlParameter();
                parametros[4].ParameterName = "@Stock";
                parametros[4].SqlDbType = SqlDbType.Int;
                parametros[4].SqlValue = productosDTO.getStock();

                clsDatos.EjecutarSP(parametros, "spGuarCambiosPodructos");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }


        public void EliminarProducto()
        {
           
            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = new SqlParameter[1];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@Id";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = productosDTO.getId();

                clsDatos.EjecutarSP(parametros, "spEliminarProductos");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

    }
}
