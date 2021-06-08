using EjPrestamo.Entidades.Dominio;
using EjPrestamo.Entidades.Modelos;
using EjPrestamo.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjPrestamo.GUI
{
    public partial class FormPrestamo : System.Windows.Forms.Form
    {
        PrestamoNegocio _prestamoNegocio;
        TipoPrestamoNegocio _tipoPrestamoNegocio;
        public FormPrestamo()
        {
            this._prestamoNegocio = new PrestamoNegocio();
            this._tipoPrestamoNegocio = new TipoPrestamoNegocio();
            InitializeComponent();
        }

        private void FormPrestamo_Load(object sender, EventArgs e)
        {
            CargarListaTipoPrestamo();
            CargarListaPrestamos();
        }

        private void CargarListaPrestamos()
        {
            Operador operador = this._prestamoNegocio.Traer();
            lstPrestamos.DataSource = null;
            lstPrestamos.DataSource = operador.Prestamos;
            txtComisionTotal.Text = operador.Comision.ToString("0.00");
        }

        private void CargarListaTipoPrestamo()
        {
            lstTipoPrestamos.DataSource = null;
            lstTipoPrestamos.DataSource = this._tipoPrestamoNegocio.Traer();
            LimpiarCampos();
        }

        private void lstTipoPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTipoPrestamos.DataSource!=null)
            {
                LimpiarCampos();
                TipoPrestamo tipoPrestamoSeleccionado = (TipoPrestamo)lstTipoPrestamos.SelectedItem;
                txtLinea.Text = tipoPrestamoSeleccionado.Linea;
                txtTNA.Text = tipoPrestamoSeleccionado.TNA.ToString();
            }
                
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTipoPrestamos.SelectedItem == null)
                    throw new Exception("No hay tipo de préstamo seleccionado");

                Validar();

                TipoPrestamo tipoPrestamoSeleccionado = (TipoPrestamo)lstTipoPrestamos.SelectedItem;
                Prestamo simulacionPrestamo = new Prestamo();
                simulacionPrestamo.TipoPrestamo = tipoPrestamoSeleccionado;
                simulacionPrestamo.Monto = double.Parse(txtMonto.Text);
                simulacionPrestamo.Plazo = int.Parse(txtPlazo.Text);

                txtCuotaCapital.Text = simulacionPrestamo.CuotaCapital.ToString("0.00");
                txtCuotaInteres.Text = simulacionPrestamo.CuotaInteres.ToString("0.00");
                txtCuotaTotal.Text = simulacionPrestamo.Cuota.ToString("0.00");

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtLinea.Text = string.Empty;
            txtTNA.Text = string.Empty;
            txtMonto.Text = string.Empty;
            txtPlazo.Text = string.Empty;
            txtCuotaCapital.Text = string.Empty;
            txtCuotaInteres.Text = string.Empty;
            txtCuotaTotal.Text = string.Empty;
        }

        private void Validar()
        {
            if(!double.TryParse(txtMonto.Text, out double monto))
                throw new Exception("Monto: Debe ingresar un número");

            if (!int.TryParse(txtPlazo.Text, out int plazo))
                throw new Exception("Plazo: Debe ingresar un plazo en meses");
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstTipoPrestamos.SelectedItem == null)
                    throw new Exception("No hay tipo de préstamo seleccionado");

                Validar();

                TipoPrestamo tipoPrestamoSeleccionado = (TipoPrestamo)lstTipoPrestamos.SelectedItem;
                Prestamo prestamo = new Prestamo(tipoPrestamoSeleccionado.id, int.Parse(txtPlazo.Text), double.Parse(txtMonto.Text), tipoPrestamoSeleccionado);
                ResultadoTransaccion resultado = this._prestamoNegocio.Agregar(prestamo);
                MessageBox.Show(resultado.ToString());
                LimpiarCampos();
                CargarListaPrestamos();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
    }
}
