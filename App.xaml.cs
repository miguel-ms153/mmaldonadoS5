using Microsoft.Extensions.DependencyInjection;

namespace mmaldonadoS5
{
   
    public partial class App : Application
    {

        public static Repositories.PersonRepository _PersonRepo {  get; set; }

        public App(Repositories.PersonRepository personRepository)
        {
            InitializeComponent();
            _PersonRepo = personRepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}