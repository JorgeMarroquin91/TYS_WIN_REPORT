using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TYS_WIM_REPORT.Modelos;

namespace TYS_WIM_REPORT.Data
{
    public static class SetValueRepository<TEntity>
    {
        public static TEntity SetValueOne(IDataReader reader)
        {
            TEntity entity = Activator.CreateInstance<TEntity>();                       //Creamos la instancia de la clase que pasamos

            while (reader.Read())
            {
                foreach (var property in typeof(TEntity).GetProperties())               //Obtenemos las propiedades de la clase que se pasa
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))             //Verificamos que el dato que se trae de la base no sea null
                    {
                        property.SetValue(entity, reader[property.Name]);               //Modificamos el valor a la instancia segun la propiedad
                    }
                }
            }
            return entity;
        }

        public static IList<TEntity> SetValueAll(IDataReader reader) 
        {
            IList<TEntity> entities = new List<TEntity>();

            while (reader.Read())
            {
                TEntity entity = Activator.CreateInstance<TEntity>();                   //Creamos la instancia de la clase que pasamos

                foreach (var property in typeof(TEntity).GetProperties())               //Obtenemos las propiedades de la clase que se pasa
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))             //Verificamos que el dato que se trae de la base no sea null
                    {
                        property.SetValue(entity, reader[property.Name]);               //Modificamos el valor a la instancia segun la propiedad
                    }
                }
                entities.Add(entity);                                                   //Agregamos la instancia a la lista de instancias de la clase que se pasa
            }

            return entities;
        }
    }
}
