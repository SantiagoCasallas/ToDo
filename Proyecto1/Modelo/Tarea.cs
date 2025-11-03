namespace Proyecto1.Modelo
{

    public class Tarea

    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        public String Estado { get; set; }
        public Tarea(int id, String descripcion, String estado)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            if (string.IsNullOrWhiteSpace(estado))
            {
                this.Estado = "Pendiente";
            }
            else
            {
                this.Estado = estado;
            }
        }

        public void mostrarTarea()
        {
            View.Vista.print("Tarea ID: " + Id + ", Descripcion: " + Descripcion+ ", Estado: "+Estado);
        }

        public String getTarea()
        {
            return Id + ", " + Descripcion+", "+Estado;
        }
    }
}
