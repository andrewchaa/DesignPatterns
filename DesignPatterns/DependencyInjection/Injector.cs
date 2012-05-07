using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DesignPatterns.DependencyInjection
{
    public class Injector
    {
        private Dictionary<Type, Func<Object>> _providers = new Dictionary<Type, Func<object>>(); 

        public void Bind<TKey, TConcrete>() where TConcrete : TKey
        {
            _providers[typeof(TKey)] = () => ResolveByType(typeof(TConcrete));
        }

        private object ResolveByType(Type type)
        {
            Console.WriteLine("Resolving... {0}", type);

            var constructor = type.GetConstructors().SingleOrDefault();
            if (constructor != null)
            {
                var arguments = constructor.GetParameters()
                    .Select(p => Resolve(p.ParameterType))
                    .ToArray();
                return constructor.Invoke(arguments);
            }

            var instanceField = type.GetField("Instance");
            return instanceField.GetValue(null);

        }

        public void Bind<T>(T instance)
        {
            _providers[typeof (T)] = () => instance;
        }

        public TKey Resolve<TKey>()
        {
            return (TKey) Resolve(typeof(TKey));
        }

        private object Resolve(Type type)
        {
            Func<object> provider;
            if (_providers.TryGetValue(type, out provider))
            {
                return provider();
            }

            return ResolveByType(type);
        }
    }
}
