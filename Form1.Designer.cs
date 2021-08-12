using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace test_wf{
    partial class Form1{
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing){
            if (disposing && (components != null)){
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent(){
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 760);
            this.Text = "Расчет по методам"; 
            this.BackColor = Color.FromArgb(0, 128, 160);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private Button help;

        public void Button_help(){
            help = new Button();
            help.Text = "!?";
            help.Font = new Font(Font.Name, 12);
            help.Location = new Point(5,5);
            help.Size = new Size(30,30);
            this.Controls.Add(help);
            help.Click += new EventHandler(Help);
        }

        public DataGridView table = new DataGridView();
        public void Table_setup(){
            table.ColumnCount = 12;
            table.Name = "Таблица данных";
            table.Location = new Point(100,8);
            table.Size = new Size(800, 500);

            table.Columns[0].Name = "id";
            table.Columns[1].Name = "t_opt";
            table.Columns[2].Name = "t_moda";
            table.Columns[3].Name = "t_pis";
            table.Columns[4].Name = "t_delta_pert";
            table.Columns[5].Name = "t_delta_mc";
            table.Columns[6].Name = "ES";
            table.Columns[7].Name = "EF";
            table.Columns[8].Name = "LS";
            table.Columns[9].Name = "LF";
            table.Columns[10].Name = "downtime";
            table.Columns[11].Name = "Links";

            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            table.RowHeadersVisible = false;
           
            table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            table.MultiSelect = false;
            table.Dock = DockStyle.None;

            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.Columns[0].Width = 30;                            table.Columns[0].ReadOnly = true;
            table.Columns[1].Width = (table.Size.Width-30)/11;      
            table.Columns[2].Width = (table.Size.Width-30)/11;      
            table.Columns[3].Width = (table.Size.Width-30)/11;      
            table.Columns[4].Width = (table.Size.Width-30)/11;      table.Columns[4].ReadOnly = true;
            table.Columns[5].Width = (table.Size.Width-30)/11;      table.Columns[5].ReadOnly = true;
            table.Columns[6].Width = (table.Size.Width-30)/11;      table.Columns[6].ReadOnly = true;
            table.Columns[7].Width = (table.Size.Width-30)/11;      table.Columns[7].ReadOnly = true;
            table.Columns[8].Width = (table.Size.Width-30)/11;      table.Columns[8].ReadOnly = true;
            table.Columns[9].Width = (table.Size.Width-30)/11;      table.Columns[9].ReadOnly = true;
            table.Columns[10].Width = (table.Size.Width-30)/11;     table.Columns[10].ReadOnly = true;
            table.Columns[11].Width = (table.Size.Width-30)/11;     //table.Columns[10].ReadOnly = true;
            table.AllowUserToAddRows = false;
        }

        private Label t_opt, t_pis, t_moda, t_pert, t_mc, way, t_f;
        private TextBox t_opt_v, t_pis_v, t_moda_v, t_pert_v, t_mc_v, way_v, t_f_v;
        private Panel panel_Colculate =new Panel();
        private Button button_opt, button_pis, button_moda, button_pert, button_mc;
        public void Panel_Colculate(){
            panel_Colculate.Location= new Point(100, 520);
            panel_Colculate.Size = new Size(800, 150);
            panel_Colculate.BackColor = Color.FromArgb(245,245,245);

            button_opt = new Button();
            button_opt.Text = "Opt";
            button_opt.Font = new Font(Font.Name, 12);
            button_opt.Location = new Point(20, 10);
            button_opt.Size = new Size(136, 30);
            button_opt.Click += new EventHandler(Check_opt);
            panel_Colculate.Controls.Add(button_opt);
            
            button_moda = new Button();
            button_moda.Text = "Moda";
            button_moda.Font = new Font(Font.Name, 12);
            button_moda.Location = new Point((136+20)+20, 10);
            button_moda.Size = new Size(136, 30);
            button_moda.Click += new EventHandler(Check_moda);
            panel_Colculate.Controls.Add(button_moda); 

            button_pis = new Button();
            button_pis.Text = "Pis";
            button_pis.Font = new Font(Font.Name, 12);
            button_pis.Location = new Point((136+20)*2+20, 10);
            button_pis.Size = new Size(136, 30);
            button_pis.Click += new EventHandler(Check_pis);
            panel_Colculate.Controls.Add(button_pis); 

            button_pert = new Button();
            button_pert.Text = "Pert";
            button_pert.Font = new Font(Font.Name, 12);
            button_pert.Location = new Point((136+20)*3+20, 10);
            button_pert.Size = new Size(136, 30);
            button_pert.Click += new EventHandler(Check_pert);
            panel_Colculate.Controls.Add(button_pert); 

            button_mc = new Button();
            button_mc.Text = "MC";
            button_mc.Font = new Font(Font.Name, 12);
            button_mc.Location = new Point((136+20)*4+20, 10);
            button_mc.Size = new Size(136, 30);
            button_mc.Click += new EventHandler(Check_mc);
            panel_Colculate.Controls.Add(button_mc); 

            t_opt = new Label();
            t_opt.Text = "t_opt";
            t_opt.Font = new Font(Font.Name, 14);
            t_opt.Location = new Point(5,50);
            t_opt.Size = new Size(55,30);
            panel_Colculate.Controls.Add(t_opt);
            
            t_opt_v = new TextBox();
            t_opt_v.Location = new Point(60, 50);
            t_opt_v.Size = new Size(70,30);
            t_opt_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_opt_v);
            
            t_moda = new Label();
            t_moda.Text = "t_moda";
            t_moda.Font = new Font(Font.Name, 14);
            t_moda.Location = new Point(150,50);
            t_moda.Size = new Size(75,30);
            panel_Colculate.Controls.Add(t_moda);
            
            t_moda_v = new TextBox();
            t_moda_v.Location = new Point(225, 50);
            t_moda_v.Size = new Size(70,30);
            t_moda_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_moda_v);

            t_pis = new Label();
            t_pis.Text = "t_pis";
            t_pis.Font = new Font(Font.Name, 14);
            t_pis.Location = new Point(315,50);
            t_pis.Size = new Size(55,30);
            panel_Colculate.Controls.Add(t_pis);
            
            t_pis_v = new TextBox();
            t_pis_v.Location = new Point(370, 50);
            t_pis_v.Size = new Size(70,30);
            t_pis_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_pis_v);

            t_pert = new Label();
            t_pert.Text = "t_pert";
            t_pert.Font = new Font(Font.Name, 14);
            t_pert.Location = new Point(460,50);
            t_pert.Size = new Size(70,30);
            panel_Colculate.Controls.Add(t_pert);
            
            t_pert_v = new TextBox();
            t_pert_v.Location = new Point(530, 50);
            t_pert_v.Size = new Size(70,30);
            t_pert_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_pert_v);

            t_mc = new Label();
            t_mc.Text = "t_mc";
            t_mc.Font = new Font(Font.Name, 14);
            t_mc.Location = new Point(610,50);
            t_mc.Size = new Size(60,30);
            panel_Colculate.Controls.Add(t_mc);
            
            t_mc_v = new TextBox();
            t_mc_v.Location = new Point(670, 50);
            t_mc_v.Size = new Size(70,30);
            t_mc_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_mc_v);
            
            way = new Label();
            way.Text = "Way: ";
            way.Font = new Font(Font.Name, 14);
            way.Location = new Point(5,100);
            way.Size = new Size(60,30);
            panel_Colculate.Controls.Add(way);
            
            way_v = new TextBox();
            way_v.Location = new Point(65, 100);
            way_v.Size = new Size(200,30);
            way_v.ReadOnly = true;
            panel_Colculate.Controls.Add(way_v);

            t_f = new Label();
            t_f.Text = "t_f: ";
            t_f.Font = new Font(Font.Name, 14);
            t_f.Location = new Point(300,100);
            t_f.Size = new Size(60,30);
            panel_Colculate.Controls.Add(t_f);
            
            t_f_v = new TextBox();
            t_f_v.Location = new Point(360, 100);
            t_f_v.Size = new Size(80,30);
            t_f_v.Text = "0";
            //t_f_v.ReadOnly = true;
            panel_Colculate.Controls.Add(t_f_v);

            this.Controls.Add(panel_Colculate);
        }

        public void Red_button(Button red){
            button_opt.BackColor = Color.FromArgb(245,245,245);
            button_pis.BackColor = Color.FromArgb(245,245,245);
            button_moda.BackColor = Color.FromArgb(245,245,245);
            button_pert.BackColor = Color.FromArgb(245,245,245);
            button_mc.BackColor = Color.FromArgb(245,245,245);
            red.BackColor = Color.FromArgb(178,34,34);
        }


        
        private Button button_exit, button_add_raw, button_delete_raw, button_Remove_All, button_Calculate;
        private Panel buttonPanel = new Panel();
        public void Buttons_add_delete_remove_calculate_exit(){
            button_add_raw = new Button();
            button_add_raw.Text = "Add Row";
            button_add_raw.Font = new Font(Font.Name, 14);
            button_add_raw.Location = new Point(20, 20);
            button_add_raw.Size = new Size(176, 40);
            button_add_raw.Click += new EventHandler(Add_New_Row);

            button_delete_raw = new Button();
            button_delete_raw.Text = "Delete Row";
            button_delete_raw.Font = new Font(Font.Name, 14);
            button_delete_raw.Location = new Point((176+20)*1+20, 20);
            button_delete_raw.Size = new Size(176, 40);
            button_delete_raw.Click += new EventHandler(Delete_Row);

            button_Remove_All = new Button();
            button_Remove_All.Text = "Remove All";
            button_Remove_All.Font = new Font(Font.Name, 14);
            button_Remove_All.Location = new Point((176+20)*2+20, 20);
            button_Remove_All.Size = new Size(176, 40);
            button_Remove_All.Click += new EventHandler(Remove_All_Rows);

            button_Calculate = new Button();
            button_Calculate.Text = "Calculate";
            button_Calculate.Font = new Font(Font.Name, 14);
            button_Calculate.Location = new Point((176+20)*3+20, 20);
            button_Calculate.Size = new Size(176, 40);
            button_Calculate.Click += new EventHandler(Calculate_all);
            
            button_exit = new Button();
            button_exit.Text = "Exit";
            button_exit.Font = new Font(Font.Name, 14);
            button_exit.Location = new Point((176+20)*4+20, 20);
            button_exit.Size = new Size(176, 40);
            button_exit.Click += new EventHandler(Button_exit_click);

            buttonPanel.Controls.Add(button_add_raw);
            buttonPanel.Controls.Add(button_delete_raw);
            buttonPanel.Controls.Add(button_Remove_All);
            buttonPanel.Controls.Add(button_Calculate);
            buttonPanel.Controls.Add(button_exit);
            buttonPanel.Height = 80;
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.BackColor = Color.FromArgb(112,128,144);
            this.Controls.Add(buttonPanel);
        }

        #endregion
    }
}