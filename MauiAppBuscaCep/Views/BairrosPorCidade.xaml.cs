using MauiAppBuscaCep.Models;
using MauiAppBuscaCep.Services;
using System.Collections.ObjectModel;

namespace MauiAppBuscaCep.Views;


public partial class BairrosPorCidade : ContentPage
{
    ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();

    ObservableCollection<Bairro>lista_bairros = new ObservableCollection<Bairro>();

	public BairrosPorCidade()
	{
		InitializeComponent();
        pck_cidade.ItemsSource = lista_cidades;
        lst_bairros.ItemsSource = lista_bairros;
	}

    private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Picker disparador = sender as Picker;

            string? estado_selecione = disparador.SelectedItem as string;

            List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(estado_selecione);

            lista_cidades.Clear();

            arr_cidades.ForEach(i => lista_cidades.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops",ex.Message,"OK");
        }
    }

    private void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}