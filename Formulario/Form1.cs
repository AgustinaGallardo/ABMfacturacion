using ABMfacturacion.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ABMfacturacion
{    
    public partial class Form1 : Form
    {
        private iServicio gestor;

        Helper Helper = new Helper();
        DetalleFactura detalle = new DetalleFactura();
        private DataGridViewTextBoxColumn idARTICULO;
        private DataGridViewTextBoxColumn colArticulo;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewButtonColumn colAcciones;
        private Label label1;
        private Button button1;
        Factura nuevaFactura = new Factura();
        public Form1()
        {
            InitializeComponent();
            gestor = new Servicio();
        }       
     
        private void Form1_Load(object sender, EventArgs e)
        {
            FormasPagos();
            //cboArticulos();
            ProximaFactura();
        }

        private void ProximaFactura()
        {
            int next = gestor.ObtenerProximo();
            if (next > 0)
            {
                lblNroFactura.Text = next.ToString();
            }
            else
                MessageBox.Show("Error de datos, no s epuede obtener el nro de factura","ERROR",
                                                      MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        //private void cboArticulos()
        //{
        //    DataTable dt = Helper.ConectBD("sp_CargarArticulos");
        //    if(dt != null)
        //    {
        //        cboArticulo.DataSource = dt;
        //        cboArticulo.ValueMember ="id_articulo";
        //        cboArticulo.DisplayMember = "descripcion";
        //        cboArticulo.DropDownStyle=ComboBoxStyle.DropDownList;
        //    }
        //}

        private void FormasPagos()
        {

            cboFormaPago.DataSource = gestor.ObtenerTodos();
                cboFormaPago.ValueMember="IdFormaPago";
                cboFormaPago.DisplayMember="TipoFP";
                cboFormaPago.DropDownStyle=ComboBoxStyle.DropDownList;
           
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex == 5)
            {
                nuevaFactura.QuitarDetalle(dgv.CurrentRow.Index);
                dgv.Rows.Remove(dgv.CurrentRow);
                nuevaFactura.CalcularTotal();
                detalle.CalcularSubTotal();                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)cboArticulo.SelectedItem;

                int id_articulo = Convert.ToInt32(item.Row.ItemArray[0]);
                string articulo = item.Row.ItemArray[1].ToString();                
                double precio = Convert.ToDouble(item.Row.ItemArray[2]);    
                
                Articulo oArticulo = new Articulo(id_articulo,articulo, precio);

                int cantidad = Convert.ToInt32(txtCantidad.Text);

                DetalleFactura detalle = new DetalleFactura(oArticulo,cantidad);

                nuevaFactura.AgregarDetalle(detalle);

                dgv.Rows.Add(new object[] { item.Row.ItemArray[0],
                                            item.Row.ItemArray[1],
                                            item.Row.ItemArray[2],
                                               txtCantidad.Text });

                txtSubtotal.Text = detalle.CalcularSubTotal().ToString();
                txtTotal.Text = nuevaFactura.CalcularTotal().ToString();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            nuevaFactura.Cliente=txtCliente.Text;
            nuevaFactura.Fecha=Convert.ToDateTime (dtpFecha.Value);
            nuevaFactura.FormaPago= Convert.ToInt32(cboFormaPago.SelectedValue);
            gestor.ObtenerProximo();
            nuevaFactura.NroFactura =Convert.ToInt32( lblNroFactura.Text);

            if (Helper.ConfirmarFactura(nuevaFactura))
            {
                MessageBox.Show("Factura registrada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
            else
                MessageBox.Show("ERROR", "¡¡CARAJO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Reporte().ShowDialog();
        }

























        private Button btnSalir;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtTotal;
        private Label lblTotal;
        private TextBox txtSubtotal;
        private Label lblSubtotal;
        private DataGridView dgv;
        private Button btnAgregar;
        private TextBox txtCantidad;
        private Label lblCantidad;
        private Label lblArticulo;
        private ComboBox cboArticulo;
        private TextBox txtCliente;
        private ComboBox cboFormaPago;
        private DateTimePicker dtpFecha;
        private Label label4;
        private Label label3;
        private Label lblFecha;
        private Label lblNroFactura;


        private void Form1_Load_1(object sender, EventArgs e)
        {


        }
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idARTICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.cboArticulo = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(573, 424);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "Salir ";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(478, 424);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 38;
            this.btnAceptar.Text = "Aceptar ";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(440, 142);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(446, 371);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(127, 20);
            this.txtTotal.TabIndex = 36;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(374, 366);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 24);
            this.lblTotal.TabIndex = 35;
            this.lblTotal.Text = "Total";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(446, 340);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(127, 20);
            this.txtSubtotal.TabIndex = 34;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(347, 335);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(93, 24);
            this.lblSubtotal.TabIndex = 33;
            this.lblSubtotal.Text = "SubTotal";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idARTICULO,
            this.colArticulo,
            this.colPrecio,
            this.colCantidad,
            this.colAcciones});
            this.dgv.Location = new System.Drawing.Point(90, 192);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(550, 126);
            this.dgv.TabIndex = 32;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // idARTICULO
            // 
            this.idARTICULO.HeaderText = "idARTICULO";
            this.idARTICULO.Name = "idARTICULO";
            // 
            // colArticulo
            // 
            this.colArticulo.HeaderText = "ARTICULO";
            this.colArticulo.Name = "colArticulo";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "PRECIO";
            this.colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "CANTIDAD";
            this.colCantidad.Name = "colCantidad";
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "ACCION";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAcciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAcciones.Text = "Quitar";
            this.colAcciones.UseColumnTextForButtonValue = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(359, 142);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 31;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(259, 145);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(83, 20);
            this.txtCantidad.TabIndex = 30;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(158, 145);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(81, 20);
            this.lblCantidad.TabIndex = 29;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.Location = new System.Drawing.Point(374, 59);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(56, 16);
            this.lblArticulo.TabIndex = 28;
            this.lblArticulo.Text = "Articulo";
            // 
            // cboArticulo
            // 
            this.cboArticulo.FormattingEnabled = true;
            this.cboArticulo.Location = new System.Drawing.Point(440, 57);
            this.cboArticulo.Name = "cboArticulo";
            this.cboArticulo.Size = new System.Drawing.Size(200, 21);
            this.cboArticulo.TabIndex = 27;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(123, 58);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(200, 20);
            this.txtCliente.TabIndex = 26;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(123, 93);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(200, 21);
            this.cboFormaPago.TabIndex = 25;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(440, 93);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Forma de Pago";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(382, 94);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 21;
            this.lblFecha.Text = "Fecha";
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(158, 9);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(0, 24);
            this.lblNroFactura.TabIndex = 20;
            this.lblNroFactura.Click += new System.EventHandler(this.lblNroFactura_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "N° Factura:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 30);
            this.button1.TabIndex = 41;
            this.button1.Text = "Reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(714, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.cboArticulo);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNroFactura);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lblNroFactura_Click(object sender, EventArgs e)
        {

        }

        
    }
    
}
