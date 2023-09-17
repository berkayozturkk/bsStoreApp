using Entities.Models;
using Services.Contracs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataShaper<T> : IDataShaper<T>
        where T : class
    {
        public PropertyInfo[] Properties { get; set; }
        public DataShaper()
        {
            Properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);  
        }

        public IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string filedString)
        {
            var requiredFileds = GetRequiredProperties(filedString);

            return FetchData(entities, requiredFileds);
        }

        public ShapedEntity ShapeData(T entity, string filedString)
        {
            var requiredProperties = GetRequiredProperties(filedString);

            return FetchDataForEntity(entity,requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string filedString)
        {
            var requiredFields =  new List<PropertyInfo>();

            if (!string.IsNullOrWhiteSpace(filedString))
            {
                var fileds = filedString.Split(',',
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var field in fileds)
                {
                    var property = Properties.FirstOrDefault(p => p.Name.Equals(
                        field.Trim(),
                        StringComparison.InvariantCultureIgnoreCase
                        ));

                    if (property is null)
                        continue; 
                    
                    requiredFields.Add(property);
                }
            }
            else
            {
                requiredFields = Properties.ToList();
            }

            return requiredFields;
        }
    
        private ShapedEntity FetchDataForEntity(T entity,
            IEnumerable<PropertyInfo> requiredProperties) 
        {
            var shapedObject = new ShapedEntity();

            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.Entity.TryAdd(property.Name, objectPropertyValue);
            }

            var objectProperty = entity.GetType().GetProperty("Id");
            shapedObject.Id = (int)objectProperty.GetValue(entity);

            return shapedObject;
        }
   
        private IEnumerable<ShapedEntity> FetchData(IEnumerable<T> entities,
            IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ShapedEntity>();

            foreach (var entity in entities)
            {
                var shapedObject = FetchDataForEntity(entity, requiredProperties);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }
    }
}
