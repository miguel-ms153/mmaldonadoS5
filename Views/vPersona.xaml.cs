using mmaldonadoS5.Models;

namespace mmaldonadoS5.Views;

public partial class vPersona : ContentPage
{
    public vPersona()
    {
        InitializeComponent();
        CargarPersonas();
    }

    private void CargarPersonas()
    {
        ListaPersonas.ItemsSource = App._PersonRepo.GetAllPerson();
        if (!string.IsNullOrWhiteSpace(App._PersonRepo.Message))
            lblMessage.Text = App._PersonRepo.Message;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        if (App._PersonRepo.AddNewPerson(txtNombre.Text))
            txtNombre.Text = string.Empty;
        lblMessage.Text = App._PersonRepo.Message;
        CargarPersonas();
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        CargarPersonas();
        if (string.IsNullOrWhiteSpace(App._PersonRepo.Message))
            lblMessage.Text = "Personas cargadas.";
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        string? id = await DisplayPromptAsync("Actualizar persona", "Ingrese el ID:", "Siguiente", "Cancelar", "ID");
        if (id is null)
            return;
        if (!int.TryParse(id, out int idPersona) || idPersona <= 0)
        {
            await DisplayAlert("Error", "Ingrese un ID válido.", "OK");
            return;
        }

        string? nombre = await DisplayPromptAsync("Actualizar persona", "Ingrese el nuevo nombre:", "Guardar", "Cancelar", "Nombre");
        if (nombre is null)
            return;

        App._PersonRepo.UpdatePerson(idPersona, nombre);
        lblMessage.Text = App._PersonRepo.Message;
        CargarPersonas();
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        string? id = await DisplayPromptAsync("Eliminar persona", "Ingrese el ID de la persona:", "Eliminar", "Cancelar", "ID");
        if (id is null)
            return;
        if (!int.TryParse(id, out int idPersona) || idPersona <= 0)
        {
            await DisplayAlert("Error", "Ingrese un ID válido.", "OK");
            return;
        }

        App._PersonRepo.DeletePerson(idPersona);
        lblMessage.Text = App._PersonRepo.Message;
        CargarPersonas();
    }
}
