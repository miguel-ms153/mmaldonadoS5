using mmaldonadoS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mmaldonadoS5.Repositories
{
    public class PersonRepository
    {
        string _dbpath;// ruta
        private SQLiteConnection _conn;
        public string Message { get; set; } 
        public void Init()
        {
            if (_conn is not null)
                return;
            _conn = new(_dbpath);
            _conn.CreateTable<Persona>();
        }

        public PersonRepository (string path)
        {
            _dbpath = path;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona person = new() { Name = name };
                result = _conn.Insert(person);
                Message = string.Format("Dato ingresado", result, name);
            }
            catch (Exception ex)
            {

                Message = string.Format("Error" + ex.Message);
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                Message = string.Format("Error" + ex.Message);
            }
            return new List<Persona>();
        }
    }
}
