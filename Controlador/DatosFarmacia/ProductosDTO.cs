using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADOR.DatosFarmacia
{
    public class ProductosDTO
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int precio;
        private int stock;

        public void setId(int valor)
        {
            this.id = valor;
        }

        public int getId()
        {
            return this.id;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setDescripcion(string des)
        {
            this.descripcion = des;
        }

        public string getDescripcion()
        {
            return this.descripcion;
        }

        public void setPrecio(int valor)
        {
            this.precio = valor;
        }

        public int getPrecio()
        {
            return this.precio;
        }

        public void setStock(int valor)
        {
            this.stock = valor;
        }

        public int getStock()
        {
            return this.stock;
        }
    }
}
