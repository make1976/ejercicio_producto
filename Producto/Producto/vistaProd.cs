using MG_Producto;
using System.Dynamic;
using System.Data.SqlClient;
using System.Data;
namespace Producto;


public partial class vistaProd : Form
{
    public vistaProd()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        actualizarProducto();
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void guardarProducto()
    {
        LN_producto objP = new LN_producto();
        try
        {
            //objP.gsCodigo = Convert.ToInt32(txtcodigo.Text);
            objP.gsNombre = txtnombre.Text;
            objP.gsCaracteristicas = txtcaracteristicas.Text;
            objP.gsCantidad = Convert.ToInt32(txtcantidad.Text);
            objP.gsValor = Convert.ToDouble(txtvalor.Text);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        if (!objP.guardarProducto())
        {
            MessageBox.Show(objP.gsError);
            return;
        }
        MessageBox.Show("grabado exitosamente");

    }

    private void actualizarProducto()
    {
        LN_producto objP = new LN_producto();
        try
        {
            //objP.gsCodigo = Convert.ToInt32(txtcodigo.Text);
            objP.gsNombre = txtnombre.Text;
            objP.gsCaracteristicas = txtcaracteristicas.Text;
            objP.gsCantidad = Convert.ToInt32(txtcantidad.Text);
            objP.gsValor = Convert.ToDouble(txtvalor.Text);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        if (!objP.actualizarProducto())
        {
            MessageBox.Show(objP.gsError);
            return;
        }
        MessageBox.Show("se actualizo correctamente");

    }

    private void EliminarProducto()

    {
        LN_producto objP = new LN_producto();
        try
        {
            objP.gsCodigo = Convert.ToInt32(txtCodigo.Text);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        if (!objP.eliminarProducto())
        {
            MessageBox.Show(objP.gsError);
            objP = null;
            return;
        }
        
    }
    private void ConsultarProducto()

    {
        LN_producto objP = new LN_producto();
        try
        {
            objP.gsCodigo = Convert.ToInt32(txtCodigo.Text);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        if (!objP.ConsultarProducto())
        {
            MessageBox.Show(objP.gsError);
            objP = null;
            return;
        }
        SqlDataReader ReaderP;
        ReaderP = objP.ObjReader;
        if (ReaderP.HasRows)
        {
            ReaderP.Read();
            txtnombre.Text = ReaderP.GetString(1);
            txtcaracteristicas.Text = ReaderP.GetString(2);
            txtvalor.Text = ReaderP.GetDouble(3).ToString();
            txtcantidad.Text = ReaderP.GetInt32(4).ToString();
            ReaderP.Close();
        }
    }

    private void bntguardar_Click(object sender, EventArgs e)
    {
        guardarProducto();
    }

    private void btnconsultar_Click(object sender, EventArgs e)
    {
        ConsultarProducto();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {

    }

    private void btneliminar_Click(object sender, EventArgs e)
    {
        EliminarProducto();
    }

    private void ListarProducto()
    {
        LN_producto objP = new LN_producto();
        if (!objP.listarProducto(dataGrid))
        {
            MessageBox.Show(objP.gsError);
            return;
        }
        return;
    }

    private void btnlistar_Click(object sender, EventArgs e)
    {
        ListarProducto();
    }
}