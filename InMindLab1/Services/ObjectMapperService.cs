using System;
using System.Linq;
using System.Reflection;

namespace InMindLab1.Services
{
    public class ObjectMapperService
    {
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            TDestination destination = new TDestination();

            // Get all properties of source and destination
            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var destProp = destinationProperties.FirstOrDefault(p =>
                    p.Name.Equals(sourceProp.Name, StringComparison.OrdinalIgnoreCase) &&
                    p.PropertyType == sourceProp.PropertyType);

                if (destProp != null && destProp.CanWrite)
                {
                    destProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }

            return destination;
        }
    }
}