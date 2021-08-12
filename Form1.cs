using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_wf{
    public partial class Form1 : Form{
        public class Node{
            public int id;
            public double ES;
            public double EF;
            public double LS;
            public double LF;
            public double downtime;
            public double time;
            public Node(int id, double ES, double EF, double LS, double LF, double time, double downtime){
                this.id = id;
                this.ES = ES;
                this.EF = EF;
                this.LS = LS;
                this.LF = LF;
                this.time = time;
            }            
            public void DisplayInfo(){
                Console.WriteLine($"id: {id}  ES: {ES}  EF: {ES}  LS: {ES}  LS: {LF}");
            }
        }

        public class Link{
            public int inside;
            public int outside;
            public Link(int inside, int outside){
                this.inside = inside;
                this.outside = outside;
            }
        }

        static int Read_number(){
            bool flag=int.TryParse(Console.ReadLine(), out int x);
            if(flag!=true || x<=0){
                Console.WriteLine("число не положительное целочисленное!");
                x=Read_number();
            }
            return x;
        }

            List <Node> time_opt = new List<Node>();
            List <Node> time_moda = new List<Node>();
            List <Node> time_pis = new List<Node>();
            List <Node> time_pert = new List<Node>();
            List <Node> time_mc = new List<Node>();
            List <Link> links = new List<Link>();

        public Form1(){
            InitializeComponent();
            
            Button_help();//кнопка помощь

            Table_setup();//стили таблицы
            Table();//вывод таблицы
            Add_to_table();//пример ввода

            Panel_Colculate();//проверка текста
            Buttons_add_delete_remove_calculate_exit();//кнопки нижнего бара
        }        

        private void Table(){   
            this.Controls.Add(table);   
        }
        private void Add_to_table(){
            String[] a={"1", "1", "3", "5", null, null, null, null, null, null, null, "2;3"};
            String[] b={"2", "2", "4", "6", null, null, null, null, null, null, null, "4;5;6"};
            String[] c={"3", "3", "5", "8", null, null, null, null, null, null, null, "4;5;6"};
            String[] d={"4", "4", "5", "7", null, null, null, null, null, null, null, "10;7;8"};
            String[] e={"5", "10", "12", "20", null, null, null, null, null, null, null, "7;8"};
            String[] f={"6", "8", "9", "15", null, null, null, null, null, null, null, "8;7"};
            String[] g={"7", "4", "6", "8", null, null, null, null, null, null, null, "9"};
            String[] h={"8", "2", "3", "6", null, null, null, null, null, null, null, "9"};
            String[] j={"9", "8", "9", "12", null, null, null, null, null, null, null, null};
            String[] k={"10", "6", "7", "9", null, null, null, null, null, null, null, null};
            String[] l={"11", "22", "23", "30", null, null, null, null, null, null, null, "3;6"};
           

            table.Rows.Add(a);
            table.Rows.Add(b);
            table.Rows.Add(c);
            table.Rows.Add(d);
            table.Rows.Add(e);
            table.Rows.Add(f);
            table.Rows.Add(g);
            table.Rows.Add(h);
            table.Rows.Add(j);
            table.Rows.Add(k);
            table.Rows.Add(l);
            //Console.WriteLine(table[0,0].Value.ToString());
        }

        private void Check_opt(object sender, EventArgs e){
            Red_button(button_opt);
            In_table(time_opt);
            Critical_way(time_opt);
        }

        private void Check_moda(object sender, EventArgs e){ 
            Red_button(button_moda);
            In_table(time_moda);
            Critical_way(time_moda);
        }
        
        private void Check_pis(object sender, EventArgs e){
            Red_button(button_pis);
            In_table(time_pis);
            Critical_way(time_pis);
        }

        private void Check_pert(object sender, EventArgs e){ 
            Red_button(button_pert);
            In_table(time_pert);
            Critical_way(time_pert);
        }

        private void Check_mc(object sender, EventArgs e){ 
            Red_button(button_mc);
            In_table(time_mc);
            Critical_way(time_mc);
        }

        private void Add_New_Row(object sender, EventArgs e){
            this.table.Rows.Add(table.Rows.Count+1, 0);
        }

        private void Delete_Row(object sender, EventArgs e){
            if (this.table.SelectedRows.Count > 0 && this.table.SelectedRows[0].Index != this.table.Rows.Count - 1){
                this.table.Rows.RemoveAt(this.table.SelectedRows[0].Index);
            }
        }

        private void Remove_All_Rows(object sender, EventArgs e){
            this.table.Rows.Clear();
            Add_New_Row(sender, e);        
        }
        
        private void Build_links(){
            links.Clear();
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                if(table[11,i].Value != null){
                    string[] parse = table[11,i].Value.ToString().Split(";");
                    for(int j=0; j<parse.Length;j++){
                        links.Add(new Link(int.Parse(table[0,i].Value.ToString()), int.Parse(parse[j])));
                    }
                }
            }
            for(int i=0; i<links.Count;i++){
                list.Add(links[i].inside);
            }
            for(int i=0; i<links.Count;i++){
                for(int j=0; j<list.Count;j++){
                    if(links[i].outside==list[j]){
                        list.RemoveAt(j);
                        j=0;
                        i=0;
                    }
                }
            }
            for (int i=0; i<list.Count; i++){
                for(int j=0; j<list.Count;j++){
                    if(j!=i && (list[i]==list[j])){
                        list.RemoveAt(j);
                    }
                }
            }
            for(int i=0; i<list.Count;i++){
                links.Add(new Link(0, list[i]));
            }
            for(int i=0; i<table.Rows.Count; i++){
                if (table[11,i].Value == null){
                    links.Add(new Link(i+1, table.Rows.Count+1));
                }
            }  
        } 

        private void Time_opt(){
            time_opt.Clear();
            time_opt.Add(new Node(0, 0, 0, 0, 0, 0, 0));
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                time_opt.Add(new Node(i+1, -1, -1, -1, -1, double.Parse(table[1,i].Value.ToString()), -1));
            }
            time_opt.Add(new Node(-1, -1, -1, -1, -1, 0, 0));
        }        

        private void Time_moda(){
            time_moda.Clear();
            time_moda.Add(new Node(0, 0, 0, 0, 0, 0, 0));
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                time_moda.Add(new Node(i+1, -1, -1, -1, -1, double.Parse(table[2,i].Value.ToString()), -1));
            }
            time_moda.Add(new Node(-1, -1, -1, -1, -1, 0, 0));
        } 

        private void Time_pis(){
            time_pis.Clear();
            time_pis.Add(new Node(0, 0, 0, 0, 0, 0, 0));
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                time_pis.Add(new Node(i+1, -1, -1, -1, -1, double.Parse(table[3,i].Value.ToString()), -1));
            }
            time_pis.Add(new Node(-1, -1, -1, -1, -1, 0, 0));
        } 

        private void Time_delta_pert(){
            time_pert.Clear();
            time_pert.Add(new Node(0, 0, 0, 0, 0, 0, 0));
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                time_pert.Add(new Node(i+1, -1, -1, -1, -1, double.Parse(table[4,i].Value.ToString()), -1));
            }
            time_pert.Add(new Node(-1, -1, -1, -1, -1, 0, 0));
        }

        private void Time_delta_mc(){
            time_mc.Clear();
            time_mc.Add(new Node(0, 0, 0, 0, 0, 0, 0));
            List <int> list = new List<int>();
            for(int i = 0; i<table.Rows.Count; i++){
                time_mc.Add(new Node(i+1, -1, -1, -1, -1, double.Parse(table[5,i].Value.ToString()), -1));
            }
            time_mc.Add(new Node(-1, -1, -1, -1, -1, 0, 0));
        }

        private void Calculate_ES_EF(List <Node> time_buf){
            List <Link> buf_links = new List<Link>();
            List <Link> buf_parse = new List<Link>();
            List <double> parse_max_EF = new List<double>();
            buf_links = links.GetRange(0, links.Count);
            double max = 0;
            for(int i=0; i<buf_links.Count;){
                if (buf_links[i].outside == (table.Rows.Count+1)){
                    buf_parse.Add(new Link(buf_links[i].inside, buf_links[i].outside));
                    buf_links.RemoveAt(i);
                }
                else{
                    i++;
                }
            }
            for(int i=0; i<buf_parse.Count; i++){
                for(int j=0; j<buf_links.Count;){
                    if(buf_links[j].outside == buf_parse[i].inside){
                        buf_parse.Add(new Link(buf_links[j].inside, buf_links[j].outside));
                        buf_links.RemoveAt(j);
                    }
                    else{
                        j++;
                    }
                }
            }
            buf_parse.Reverse();
            for(int i=0;i<buf_parse.Count;i++){
                if(buf_parse[i].inside != 0){
                    for(int j=0;j<buf_parse.Count;j++){
                        if(buf_parse[i].inside==buf_parse[j].outside){
                            parse_max_EF.Add(time_buf[buf_parse[j].inside].EF);
                        }
                    }
                    max = parse_max_EF.Max();
                    time_buf[buf_parse[i].inside].ES = max;
                    time_buf[buf_parse[i].inside].EF = time_buf[buf_parse[i].inside].ES + time_buf[buf_parse[i].inside].time;
                    parse_max_EF.Clear();
                }
            }
            for(int i=0; i<buf_parse.Count; i++){
                if(buf_parse[i].outside == time_buf.Count-1){
                    parse_max_EF.Add(time_buf[buf_parse[i].inside].EF);
                }
            }
            max = parse_max_EF.Max();
            time_buf[time_buf.Count-1].ES = max;
            time_buf[time_buf.Count-1].EF = time_buf[time_buf.Count-1].ES + time_buf[time_buf.Count-1].time;
            parse_max_EF.Clear();
            buf_links.Clear();
            buf_parse.Clear();
        }

        private void Last_node_phantom(List <Node> time_buf){
            if(time_buf[time_buf.Count-1].EF < float.Parse(t_f_v.Text)){
                time_buf[time_buf.Count-1].LF = float.Parse(t_f_v.Text);
            }
            else{
                time_buf[time_buf.Count-1].LF=time_buf[time_buf.Count-1].EF;
            }
            time_buf[time_buf.Count-1].LS=time_buf[time_buf.Count-1].LF-time_buf[time_buf.Count-1].time;
        }

        private void Calculate_LS_LF(List <Node> time_buf){
            List <Link> buf_links = new List<Link>();
            List <Link> buf_parse = new List<Link>();
            List <double> parse_min_LS = new List<double>();
            buf_links = links.GetRange(0, links.Count);
            double min = 0;
            for(int i=0; i<buf_links.Count;){
                if (buf_links[i].inside == 0){
                    buf_parse.Add(new Link(buf_links[i].inside, buf_links[i].outside));
                    buf_links.RemoveAt(i);
                }
                else{
                    i++;
                }
            }
            for(int i=0; i<buf_parse.Count; i++){
                for(int j=0; j<buf_links.Count;){
                    if(buf_links[j].inside == buf_parse[i].outside){
                        buf_parse.Add(new Link(buf_links[j].inside, buf_links[j].outside));
                        buf_links.RemoveAt(j);
                    }
                    else{
                        j++;
                    }
                }
            }
            buf_parse.Reverse();
            for(int i=0;i<buf_parse.Count;i++){
                if(buf_parse[i].outside != table.Rows.Count+1){
                    for(int j=0;j<buf_parse.Count;j++){
                        if(buf_parse[i].outside==buf_parse[j].inside){
                            parse_min_LS.Add(time_buf[buf_parse[j].outside].LS);
                        }
                    }
                    min = parse_min_LS.Min();
                    time_buf[buf_parse[i].outside].LF = min;
                    time_buf[buf_parse[i].outside].LS = time_buf[buf_parse[i].outside].LF - time_buf[buf_parse[i].outside].time;
                    parse_min_LS.Clear();
                }
            }
            for(int i=0; i<buf_parse.Count; i++){
                if(buf_parse[i].inside == 0){
                    parse_min_LS.Add(time_buf[buf_parse[i].inside].LS);
                }
            }
            min = parse_min_LS.Min();
            time_buf[0].LF = min;
            time_buf[0].LS = time_buf[0].LF - time_buf[0].time;
            parse_min_LS.Clear();
            buf_links.Clear();
            buf_parse.Clear();
        }    

        private void In_table(List <Node> time_buf){
                for(int i =0; i<table.Rows.Count; i++){
                this.table[6,i].Value = Math.Round(time_buf[i+1].ES, 3);
                this.table[7,i].Value = Math.Round(time_buf[i+1].EF, 3);
                this.table[8,i].Value = Math.Round(time_buf[i+1].LS, 3);
                this.table[9,i].Value = Math.Round(time_buf[i+1].LF, 3);
                this.table[10,i].Value = Math.Round(time_buf[i+1].downtime, 3);
            }
        }

        private void Calculate(List <Node> time_buf){
            Calculate_ES_EF(time_buf);
            Last_node_phantom(time_buf);
            Calculate_LS_LF(time_buf);
            Downtime(time_buf);
        }
        
        private void Time_pert(){
            for(int i=0; i<table.Rows.Count; i++){
                table[4,i].Value=Math.Round(((double.Parse(table[1,i].Value.ToString()) + 4*double.Parse(table[2,i].Value.ToString()) + double.Parse(table[3,i].Value.ToString()))/6), 5);
            }
        }

        private void Time_mc(){
            for(int i=0; i<table.Rows.Count; i++){
                table[5,i].Value = Math.Round(Integral(double.Parse(table[1,i].Value.ToString()), double.Parse(table[2,i].Value.ToString()), double.Parse(table[3,i].Value.ToString())), 5);
            }
        }

        private double Integral(double a, double yMax, double b){
            double total = 0;
            double x;
            double funct;
            //yMax=0;
            int i = 0;
            int n = 100000;
            do{
                x=GetRandomNumber(a,b);
                funct=Math.Abs(Math.Cos(x));
                if(yMax>funct){
                    total+=funct;
                    i++;
                }
                else{
                    yMax=funct*2;
                    i=0;
                }
            }while(i<n);
            return ((b-a)*total)/n;
        }

        private double GetRandomNumber(double minimum, double maximum){
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void Downtime(List <Node> time_buf){
            for(int i=1; i<time_buf.Count-1;i++){
                time_buf[i].downtime=time_buf[i].LF-time_buf[i].EF;
            }
        }
       
        private void Critical_way(List <Node> time_buf){
            this.way_v.Text = null;
            int buf = 0;
            double rem;
            List <int> buf_id = new List<int>();
            List <int> critical_path = new List<int>();
            while(buf!=time_buf.Count-1){
                for(int j=0; j<links.Count; j++){
                    if(links[j].inside == buf){
                        buf_id.Add(links[j].outside);
                    } 
                }
                rem = 9999999;
                for(int i=0; i<buf_id.Count; i++){
                    if(time_buf[buf_id[i]].downtime<rem){
                        rem = time_buf[buf_id[i]].downtime;
                        buf = buf_id[i];
                    }
     
                }
                critical_path.Add(buf);
                buf_id.Clear();
            }
            critical_path.RemoveAt(critical_path.Count-1);
            for(int i=0; i<critical_path.Count; i++){
                this.way_v.Text += critical_path[i].ToString() + " ";
            }
        }

        private void Calculate_all(object sender, EventArgs e){
            Red_button(button_opt);
            
            Time_opt();
            Time_moda();
            Time_pis();

            Time_pert();
            Time_delta_pert();
            
            Time_mc();
            Time_delta_mc();

            Build_links();

            Calculate(time_opt);
            Calculate(time_moda);
            Calculate(time_pis);
            Calculate(time_pert);
            Calculate(time_mc);
                        
            In_table(time_opt);
            Critical_way(time_opt);
            this.t_opt_v.Text = Math.Round(time_opt[time_opt.Count-1].EF, 3).ToString();
            this.t_moda_v.Text = Math.Round(time_moda[time_moda.Count-1].EF, 3).ToString();
            this.t_pis_v.Text = Math.Round(time_pis[time_pis.Count-1].EF, 3).ToString();
            this.t_pert_v.Text = Math.Round(time_pert[time_pert.Count-1].EF, 3).ToString();
            this.t_mc_v.Text = Math.Round(time_mc[time_mc.Count-1].EF, 3).ToString();
        }
        
        private void Help(object sender, EventArgs e){
            MessageBox.Show("я помощник");
        }

        private void Button_exit_click(object sender, EventArgs e){
            this.Close();
        }
    }
}