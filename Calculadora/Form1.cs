using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        decimal valor1 = 0, valor2 = 0;
        string operacao = "";

        // Cultura brasileira: usa vírgula como separador decimal
        CultureInfo ptBR = new CultureInfo("pt-BR");

        //Indica se o último comando foi o botão =
        bool novoCalculo = false;


        public Form1()
        {
            InitializeComponent();
        }


        private void btnZero_Click(object sender, EventArgs e)
        {
            AdicionarNumero("0");
        }

        private void txtResultado_TextChanged(object sender, EventArgs e)
        {
        }

        //Números 
        private void AdicionarNumero(String numero)
        {
            //Se acabou de calcular, começa um novo número
            if (novoCalculo)
            {
                txtResultado.Text = "";
                novoCalculo = false;
            }
            txtResultado.Text += numero;
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            AdicionarNumero("1");
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            AdicionarNumero("2");
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            AdicionarNumero("3");
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            AdicionarNumero("4");
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AdicionarNumero("5");
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            AdicionarNumero("6");
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            AdicionarNumero("7");
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            AdicionarNumero("8");
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            AdicionarNumero("9");
        }

        // VÍRGULA
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            //Se acabou de calcular, começa um novo número
            if (novoCalculo)
            {
                txtResultado.Text = "";
                novoCalculo = false;
            }

            //Não permite duas vírgulas
            if (!txtResultado.Text.Contains(","))
            {
                // Se clicar na vírgula sem nenhum número, começa com 0,
                if (txtResultado.Text == "")
                {
                    txtResultado.Text = "0,";
                }
                else
                {
                    txtResultado.Text += ",";
                }
            }
        }

        //RETROCEDER
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 0)
            {
                txtResultado.Text =
                    txtResultado.Text.Remove(txtResultado.Text.Length - 1);
            }
        }

        //OPERAÇÕES

        //ADIÇÃO
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);
                txtResultado.Text = "";
                operacao = "SOMA";
                lblResultado.Text = "+";
                novoCalculo = false;
            }
        }

        //Subtração
        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);
                txtResultado.Text = "";
                operacao = "SUBTRACAO";
                lblResultado.Text = "-";
                novoCalculo = false;
            }
        }

        //MULTIPLICAÇÃO
        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
                valor1 = decimal.Parse(txtResultado.Text, ptBR);
            txtResultado.Text = "";
            operacao = "MULTIPLICACAO";
            lblResultado.Text = "x";
            novoCalculo = false;
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "")
            {
                valor1 = decimal.Parse(txtResultado.Text, ptBR);
                txtResultado.Text = "";
                operacao = "DIVISAO";
                lblResultado.Text = "/";
                novoCalculo = false;
            }
        }

        //IGUAL
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "" && operacao != "")
            {
                valor2 = decimal.Parse(txtResultado.Text, ptBR);
                decimal resultado = 0;
                if (operacao == "SOMA")
                {
                    resultado = valor1 + valor2;
                }
                else if (operacao == "SUBTRACAO")
                {
                    resultado = valor1 - valor2;
                }
                else if (operacao == "MULTIPLICACAO")
                {
                    resultado = valor1 * valor2;
                }
                else if (operacao == "DIVISAO")
                {
                    // Impede divisão por zero
                    if (valor2 == 0)
                    {
                        MessageBox.Show(
                           "Não é possível dividir por zero.",
                           "Erro",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                        );

                        return;
                    }

                    resultado = valor1 / valor2;
                }

                // Mostra o resultado usando a cultura brasileira
                txtResultado.Text = resultado.ToString(ptBR);

                // Limpa a operação exibida
                lblResultado.Text = "";

                // Indica que acabamos de calcular
                novoCalculo = true;

            }
        }

        //LIMPAR TUDO - C
        private void btnC_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";

            valor1 = 0;
            valor2 = 0;

            operacao = "";

            lblResultado.Text = "";

            novoCalculo = false;
        }

        //LIMPAR ENTRADA - CE
        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "";
            novoCalculo = false;
        }
    }
}



