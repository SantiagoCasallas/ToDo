namespace Proyecto1.Modelo
{

    public class Tarea

    {
        int Id { get; set; }
        String Descripcion { get; set; }

        public Tarea(int id, String descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;


        }

        public void mostrarTarea()
        {
            Console.WriteLine("Tarea ID: " + Id + ", Descripcion: " + Descripcion);
        }

        public String getTarea()
        {
            return Id + ", " + Descripcion;
        }
    }
}
