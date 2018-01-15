using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validador_de_funciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] elementos_funcion= new string[20];
        char[] funcion_;
        int[] val_numeros = new int[20];
        int f_;
        int tope = 0;
        private void Iniciar_Click(object sender, EventArgs e)
        {

            funcion_ = funcion.Text.ToCharArray();
            f_ = Int16.Parse(f.Text);

            Identifica_elemento();
            
            Realiza_operaciones();

            Asigna_valor();

            //for (int k = 0; k <= tope; k++)
            //{
            //    MessageBox.Show(elementos_funcion[k]);
            //    MessageBox.Show(val_numeros[k].ToString());
            //}

        }


        void Asigna_valor()
        {
            int acum = int.Parse(elementos_funcion[0]);
            int ind_arr=0;
            int[] arr = new int[20];
            int res = 0;
            for (int k=0;k<=tope;k++)
            {
               

                if (elementos_funcion[k] == "+" || elementos_funcion[k] == "-")
                {
                    arr[ind_arr] = val_numeros[k] * val_numeros[k + 1];
                    ind_arr++;
                    k++;
                }
                else if(elementos_funcion[k] != "+" && elementos_funcion[k] != "-")
                {
                    
                    

                    arr[ind_arr] = val_numeros[k];
                    ind_arr++;
                }
                
            }

            for (int k = 0; k < ind_arr; k++)
            {
                res = res+arr[k]  ;
            }

            MessageBox.Show(res.ToString());

        }

        void Realiza_operaciones()
        {

            char[] arraychar;
            int res = 1;

            int u_elemnto = 0;
            bool ban = false;
            for (int y=0;y<=tope;y++)
            {
               // MessageBox.Show(elementos_funcion[y]);
                res = 1;
                arraychar = elementos_funcion[y].ToCharArray();
                if (elementos_funcion[y] != "+" && elementos_funcion[y] != "-")
                {
                    ban = true;
                    for (int j = 0; j < arraychar.Length; j++)
                    {
                        if (arraychar[j] == 'x')
                        {
                            arraychar[j] =char.Parse(f_.ToString());
                        }
                        
                        res = res * (int.Parse(arraychar[j].ToString()));
                    }
                   
                }
                if (ban == true)
                {
                    val_numeros[u_elemnto] = res;   
                    elementos_funcion[u_elemnto] = res.ToString();
                    u_elemnto++;
                    ban = false;
                }
                else
                {
                    elementos_funcion[u_elemnto] = elementos_funcion[y];
                   


                    if (elementos_funcion[y] == "+")
                    {
                        val_numeros[u_elemnto] = 1;
                    }
                    if (elementos_funcion[y] == "-")
                    {
                        val_numeros[u_elemnto] = -1;
                    }
                    u_elemnto++;
                }

            }

        }

        void Identifica_elemento()
        {
            
            elementos_funcion[tope] = string.Empty;
            
            for (int k = 0; k < funcion_.Length; k++)
            {
                if (funcion_[k] != '+' && funcion_[k] != '-')
                {
                    elementos_funcion[tope]= elementos_funcion[tope] + funcion_[k].ToString();

                    
                }
                else //if (funcion_[k] == '+' || funcion_[k] == '-')
                {

                    tope++;
                    elementos_funcion[tope] = funcion_[k].ToString();
                    tope++;
                }
                
            }
            for (int k = 0; k <=tope; k++)
            {
                
                MessageBox.Show(elementos_funcion[k]);
            }


        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
