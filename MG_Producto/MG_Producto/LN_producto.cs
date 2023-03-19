using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LibConexionBD;
using System.Dynamic;
using System.Windows.Forms;
using LibLlenarGrid;
using System.Runtime.Serialization;

namespace MG_Producto

{
    public class LN_producto
    {
        
        
        #region ATRIBUTOS
        private int codigo;
        private string nombre;
        private string caracteristicas;
        private double valor;
        private int cantidad;
        private string error;
        SqlDataReader objReader;
        #endregion

        #region PROPIEDADES
        public int gsCodigo { get => codigo; set => codigo = value; }
        public string gsNombre { get => nombre; set => nombre = value; }
        public string gsCaracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public double gsValor { get => valor; set => valor = value; }
        public int gsCantidad { get => cantidad; set => cantidad = value; }
        public string gsError { get => error; set => error = value; }
        public SqlDataReader ObjReader { get => objReader; set => objReader = value; }

        #endregion

        #region METODOS PUBLICOS
        public LN_producto()
        {
            codigo = 0;
            nombre = "";
            caracteristicas = "";
            valor = 0;
            cantidad = 0;
            error = "";
        }

        //metodo guardar
        public bool guardarProducto()
        {
            //instanciar la clase conexion
            ClsConexion objP = new ClsConexion();
            string sentencia = "execute usp_guardar_producto '" + nombre + "','" + caracteristicas + "'," + valor + "," + cantidad;
            if (!objP.EjecutarSentencia(sentencia, false))
            {
                error = objP.Error;
                objP = null;
                return false;
            }
            else
            {
                objP = null;
                return true;
            }

        }
        public bool actualizarProducto()
        {
            ClsConexion objP = new ClsConexion();
            string sentencia = "execute usp_actualizar_producto'" + codigo + "','" + nombre + "','" + caracteristicas + "'," + valor + "," + cantidad;
            if (!objP.EjecutarSentencia(sentencia, false))
            {
                error = objP.Error;
                objP = null;
                return false;
            }
            else
            {
                objP = null;
                return true;
            }

        }
        public bool eliminarProducto()
        {
            ClsConexion objP = new ClsConexion();
            string sentencia = "execute usp_eliminar_Producto'" + codigo + "'";
            if (!objP.EjecutarSentencia(sentencia, false))
            {
                error = objP.Error;
                objP = null;
                return false;
            }
            else
            {
                objP = null;
                return true;
            }

        }
        public bool ConsultarProducto()
        {

            string sentencia = "execute usp_consultar_Producto " + codigo;
            ClsConexion objP = new ClsConexion();
            if (objP.Consultar(sentencia, false))
            {
                objReader = objP.Reader;
                objP = null;
                return true;
            }
            else
            {
                error = objP.Error;
                objP = null;
                return false;
            }
        }
        public bool listarProducto(DataGridView GRWdatos)
        {
            ClsLlenarGrid objG = new ClsLlenarGrid();
            objG.NombreTabla = "datos";
            objG.SQL = "execute usp_listar_producto";
            if (!objG.LlenarGrid(GRWdatos))
            {
                error = objG.Error;
                objG = null;
                return false;
            }
            objG = null;
            return true;
        }
        #endregion



    }

}
