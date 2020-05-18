using System;
using System.Collections.Generic;
using UserValidation.Updated.ViewModels.BaseViewModel;
using Xamarin.Forms;

namespace UserValidatation.Updated.IOC
{
	public static class SimpleIoC
	{
        #region PROPERTIES

        static readonly Dictionary<Type, Type> RegisteredTypes = new Dictionary<Type, Type>();
		static readonly Dictionary<Type, object> Singletons = new Dictionary<Type, object>();

        #endregion

        #region METHODS

        public static void RegisterPage<TType, TType1>() where TType1 : Page where TType : ViewModelBase
		{
			RegisteredTypes[typeof(TType)] = typeof(TType1);
		}        

		public static Page GetPage(Type type, bool singleton = true) // A
		{
			return GetObject<Page>(type, singleton);
		}
        
		public static T GetObject<T>(Type type, bool singleton = true) // CALLED FROM 'A'
		{
			Type objectType;
		
			if (!RegisteredTypes.TryGetValue(type, out objectType))
				return default(T);

			if (!singleton)
				return (T)Activator.CreateInstance(objectType);

            object item;
			if (!Singletons.TryGetValue(objectType, out item))
			{
				Singletons[objectType] = item = (T)Activator.CreateInstance(objectType);
			}

			return (T)item;
		}

        #endregion
    }
}

