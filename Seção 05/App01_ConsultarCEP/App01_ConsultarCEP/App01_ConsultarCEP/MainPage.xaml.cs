using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(Object Sender, EventArgs args)
        {

            String cep = CEP.Text.Trim();

            if(isValidCep(cep))
            {

                try
                {

                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if(end != null)
                    {

                        RESULTADO.Text = String.Format("Endereço: {2}, {3}, {0}-{1}", end.localidade, end.uf, end.logradouro, end.bairro);

                    }
                    else
                    {

                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");

                    }


                }
                catch (Exception e)
                {

                    DisplayAlert("Erro Crítico", e.Message, "OK");

                }


            }

        }

        private bool isValidCep(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;

            if (cep.Length != 8)
            {

                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;

            }
            else if (!int.TryParse(cep, out NovoCEP))
            {

                DisplayAlert("Erro", "CEP inválido! O CEP deve conter apenas números.", "OK");
                valido = false;

            }

            return valido;
        }

	}
}
