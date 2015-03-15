using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace AAngelov.Utilities.Test
{
    public class ReducedAutoMapperExtended
    {
            private static ReducedAutoMapperExtended instance;
            private Dictionary<Type, Type> mappingTypes;
            private readonly List<string> systemAssemlyPrivateKeys = new List<string>()
        {
            "b77a5c561934e089",
            "b03f5f7f11d50a3a",
            "31bf3856ad364e35"
        };

            public static ReducedAutoMapperExtended Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ReducedAutoMapperExtended();
                        instance.mappingTypes = new Dictionary<Type, Type>();
                    }
                    return instance;
                }
            }

            public Dictionary<Type, Type> MappingTypes
            {
                get
                {
                    return mappingTypes;
                }
                set
                {
                    mappingTypes = value;
                }
            }

            public void CreateMap<TSource, TDestination>()
                where TSource : new()
                where TDestination : new()
            {
                if (typeof(TSource).IsGenericType || typeof(TDestination).IsGenericType)
                {
                    throw new Exception("Generic types are not supported for map creation.");
                }
                if (!MappingTypes.ContainsKey(typeof(TSource)))
                {
                    MappingTypes.Add(typeof(TSource), typeof(TDestination));
                }
            }

            public TDestination Map<TSource, TDestination>(TSource realObject)
            {
                if (realObject == null)
                {
                    return default(TDestination);
                }
                var mapObject = (MappingTypes[realObject.GetType()]);
                var dtoObject = Activator.CreateInstance(mapObject);
                PropertyInfo[] properties = realObject.GetType().GetProperties();
                foreach (PropertyInfo currentRealProperty in properties)
                {
                    PropertyInfo currentDtoProperty = dtoObject.GetType().GetProperty(currentRealProperty.Name);
                    if (currentDtoProperty == null)
                    {
                        Debug.WriteLine("The property {0} was not found in the DTO object in order to be mapped. Because of that we skip to map it.", currentRealProperty.Name);
                    }
                    else
                    {
                        Type[] typeArguments;
                        if (MappingTypes.ContainsKey(currentRealProperty.PropertyType))
                        {
                            Type mapToObject = mappingTypes[currentRealProperty.PropertyType];
                            MethodInfo method = GetType().GetMethod("Map").MakeGenericMethod(new Type[] {
                          currentRealProperty.PropertyType,
                          mapToObject
                        });

                            var newProxyProperty = method.Invoke(this, new object[]
                        {
                            currentRealProperty.GetValue(realObject, null)
                        });
                            currentDtoProperty.SetValue(dtoObject, newProxyProperty);
                        }
                        else if (TryGetInterfaceGenericParameters(currentRealProperty.PropertyType, typeof(IList<>), out typeArguments))
                        {
                            if (typeArguments.Count() > 1)
                            {
                                throw new Exception("Currently generic types with more than 1 generic type are not supported. Please add the property top the ignore list.");
                            }
                            IList enumarableMapProperty = null;
                            Type currentMapType = GetMapTyped(typeArguments);
                            enumarableMapProperty = (IList)typeof(List<>)
                                                .MakeGenericType(currentMapType)
                                                .GetConstructor(Type.EmptyTypes)
                                                .Invoke(null);

                            var currentRealPropertyCollection = (ICollection)currentRealProperty.GetValue(realObject, null);
                            if (currentRealPropertyCollection != null)
                            {
                                foreach (var currentItem in currentRealPropertyCollection)
                                {
                                    if (MappingTypes.ContainsKey(currentItem.GetType()))
                                    {
                                        Type mapToObject = mappingTypes[currentItem.GetType()];
                                        MethodInfo method = GetType().GetMethod("Map").MakeGenericMethod(new Type[] {
                                  currentItem.GetType(),
                                  mapToObject
                                });

                                        var newProxyProperty = method.Invoke(this, new object[]
                                {
                                    currentItem
                                });
                                        enumarableMapProperty.Add(newProxyProperty);
                                    }
                                    else if (systemAssemlyPrivateKeys.Any(x => currentRealProperty.PropertyType.Assembly.FullName.Contains(x)))
                                    {
                                        enumarableMapProperty.Add(currentItem);
                                    }
                                    else
                                    {
                                        throw new Exception(string.Format("You should create a new map for object of type {0} in order to be mapped correctly.", currentRealProperty.PropertyType.FullName));
                                    }
                                }
                                if (currentDtoProperty.PropertyType.IsArray)
                                {
                                    MethodInfo method = GetType().GetMethod("ConvertArray").MakeGenericMethod(new Type[] { currentMapType });

                                    var newMappedArray = method.Invoke(this, new object[] { enumarableMapProperty });
                                    currentDtoProperty.SetValue(dtoObject, newMappedArray);
                                }
                                else
                                {
                                    currentDtoProperty.SetValue(dtoObject, enumarableMapProperty);
                                }
                            }
                            else
                            {
                                currentDtoProperty.SetValue(dtoObject, null);
                            }
                        }
                        // TODO add validation that another collections like Queues stacks, are not supported. Implement IEnumarable but not implement ICollection<T>
                        // Should test with another collection like list.
                        else if (systemAssemlyPrivateKeys.Any(x => currentRealProperty.PropertyType.Assembly.FullName.Contains(x)))
                        {
                            currentDtoProperty.SetValue(dtoObject, currentRealProperty.GetValue(realObject, null));
                        }
                        else
                        {
                            throw new Exception(string.Format("You should create a new map for object of type {0} in order to be mapped correctly.", currentRealProperty.PropertyType.FullName));
                        }
                    }
                }

                return (TDestination)dtoObject;
            }

            private Type GetMapTyped(Type[] typeArguments)
            {
                Type mapType = default(Type);
                if (!MappingTypes.ContainsKey(typeArguments.First()))
                {
                    mapType = typeArguments.First();
                }
                else
                {
                    mapType = MappingTypes[typeArguments.First()];
                }

                return mapType;
            }

            public T[] ConvertArray<T>(IEnumerable<T> input)
            {
                return input.ToArray();
            }

            public bool TryGetInterfaceGenericParameters(Type type, Type interfaceToCompare, out Type[] typeParameters)
            {
                typeParameters = null;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == interfaceToCompare)
                {
                    typeParameters = type.GetGenericArguments();
                    return true;
                }

                var implements = type.FindInterfaces((ty, obj) => ty.IsGenericType && ty.GetGenericTypeDefinition() == interfaceToCompare, null).FirstOrDefault();
                if (implements == null)
                {
                    return false;
                }

                typeParameters = implements.GetGenericArguments();
                return true;
            }
        }
    }