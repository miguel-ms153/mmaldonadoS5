using mmaldonadoS5.Models;
using SQLite;

namespace mmaldonadoS5.Repositories
{
    public class PersonRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection? _conn;
        public string? Message { get; private set; }

        public PersonRepository(string path)
        {
            _dbPath = path;
        }

        private void Init()
        {
            if (_conn is not null)
                return;

            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Persona>();
        }

        public bool AddNewPerson(string? name)
        {
            try
            {
                Init();
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("El nombre es requerido.");

                _conn!.Insert(new Persona { Name = name.Trim() });
                Message = "Persona agregada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                Message = "Error al agregar: " + ex.Message;
                return false;
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                Message = null;
                return _conn!.Table<Persona>().OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                Message = "Error al consultar: " + ex.Message;
                return new List<Persona>();
            }
        }

        public bool UpdatePerson(int id, string? name)
        {
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("El ID debe ser válido.");
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("El nombre es requerido.");

                var person = _conn!.Find<Persona>(id);
                if (person is null)
                    throw new Exception("No se encontró una persona con ese ID.");

                person.Name = name.Trim();
                if (_conn.Update(person) == 0)
                    throw new Exception("No se pudo actualizar la persona.");

                Message = "Persona actualizada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                Message = "Error al actualizar: " + ex.Message;
                return false;
            }
        }

        public bool DeletePerson(int id)
        {
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("El ID debe ser válido.");

                if (_conn!.Delete<Persona>(id) == 0)
                    throw new Exception("No se encontró una persona con ese ID.");

                Message = "Persona eliminada correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                Message = "Error al eliminar: " + ex.Message;
                return false;
            }
        }
    }
}
