using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Threading.Tasks;

namespace SegundoParcialElipses.Datos
{
    using Entidades;

    public class RepositorioElipses
    {
        private List<Elipse> elipses = new List<Elipse>();


        public int Cantidad => elipses.Count;


        public bool AgregarElipse(Elipse elipse)
        {
            if (!elipses.Contains(elipse))
            {
                elipses.Add(elipse);
                return true;
            }
            return false;
        }


        public List<Elipse> ObtenerElipses() => new List<Elipse>(elipses);


        public void GuardarEnArchivo(string ruta)
        {
            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (var elipse in elipses)
                {
                    sw.WriteLine($"{elipse.SemiejeMayor},{elipse.SemiejeMenor},{(int)elipse.Borde},{(int)elipse.Color}");
                }
            }
        }


        public void LeerDesdeArchivo(string Windows)
        {
            elipses.Clear();
            if (File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(Windows))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        var datos = linea.Split(',');
                        int semiejeMayor = int.Parse(datos[0]);
                        int semiejeMenor = int.Parse(datos[1]);
                        Bordes borde = (Bordes)int.Parse(datos[2]);
                        ColorElipse color = (ColorElipse)int.Parse(datos[3]);
                        elipses.Add(new Elipse(semiejeMayor, semiejeMenor, borde, color));
                    }
                }
            }
        }


        public bool BorrarElipse(Elipse elipse)
        {
            return elipses.Remove(elipse);
        }


        public List<Elipse> OrdenarPorArea(bool ascendente = true)
        {
            return ascendente ? elipses.OrderBy(e => e.CalcularArea()).ToList() : elipses.OrderByDescending(e => e.CalcularArea()).ToList();
        }


        public List<Elipse> FiltrarPorBorde(Bordes borde)
        {
            return elipses.Where(e => e.Borde == borde).ToList();
        }

        public List<Elipse> ObtenerElipses() => new List<Elipse>(elipses);


        public List<Elipse> ObtenerElipsesOrdenadasPorAreaAscendente()
        {
            return elipses.OrderBy(e => e.CalcularArea()).ToList();
        }


        public List<Elipse> ObtenerElipsesOrdenadasPorAreaDescendente()
        {
            return elipses.OrderByDescending(e => e.CalcularArea()).ToList();
        }

        public void GuardarEnArchivo()
        {
            try
            {
                string json = JsonSerializer.Serialize(elipses, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}");
            }
        }

        public void CargarDesdeArchivo()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    elipses = JsonSerializer.Deserialize<List<Elipse>>(json) ?? new List<Elipse>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}");
                }
            }

        }
    }
}