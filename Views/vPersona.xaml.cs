using mmaldonadoS5.Models;

namespace mmaldonadoS5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        App._PersonRepo.AddNewPerson(txtNombre.Text);
        lblMessage.Text = App._PersonRepo.Message;
    }

    private void btnMostrat_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        List<Persona> people = App._PersonRepo.GetAllPerson();
        ListaPersonas.ItemsSource = people;
    }
}