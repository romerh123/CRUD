﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Attributes;
using Domain.Crud;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;//poder iniciar los botones  
        }


        //variables
        Cpersona personas = new Cpersona();
        AttribuitesPeople attributes = new AttribuitesPeople();
        bool edit = false;  
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();//cerrar
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void getData()
        {
            Cpersona cpersona = new Cpersona();
            DvgDatos.DataSource = cpersona.Mostar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;   
            btnGuardar.Enabled = false;
            getData();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre") txtNombre.Text = "";
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") txtNombre.Text = "Nombre";
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "Apellido") txtApellido.Text = "";
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "") txtApellido.Text = "Apellido";
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            if (txtID.Text == "ID") txtID.Text = "";
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text == "") txtID.Text = "ID";
        }
        private void ClearTextBoxs()//borrar los textbox cuando se da al boton nuevo
        {
            txtID.Text = "ID";
            txtApellido.Text = "Apellido";
            txtNombre.Text = "Nombre";
        }
           
            
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(edit == false)
            {
                try
                {
                    attributes.ID1 = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cbSexo.Text;
                    personas.Insertar(attributes);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("Insertado", " Se guardo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                catch (Exception ex) 
                
                {
                    MessageBox.Show("Error", $"Se ha producido un error; {ex.ToString()}" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Inserta
            }else if(edit == true)  
            {
                //actualizar
                try
                {
                    attributes.ID1 = Convert.ToInt32(txtID.Text);
                    attributes.Nombre = txtNombre.Text;
                    attributes.Apellido = txtApellido.Text;
                    attributes.Sexo = cbSexo.Text;
                    personas.Modificar(attributes);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("Insertado", " Se Modifico correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Error", $"Se ha producido un error; {ex.ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ;
            if(DvgDatos.SelectedRows.Count > 0) 
            {
                txtID.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;

                //Cargar datos
                txtID.Text = DvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DvgDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = DvgDatos.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar....") txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar....";
                getData();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DvgDatos.SelectedRows.Count > 0)
                
            
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("¿Desea eliminar el registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    try 
                    {
                        attributes.ID1 = Convert.ToInt32(DvgDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(attributes);
                        getData();
                        MessageBox.Show("Registro eliminado");
                    }
                    catch(Exception ex) 
                    
                    {
                        MessageBox.Show("Error", $"Se ha producido un error; {ex.ToString()}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally 
                    { 

                    }


                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cpersona cpersona = new Cpersona();
            DvgDatos.DataSource = cpersona.Buscar(txtBuscar.Text);
        }
    }
}
